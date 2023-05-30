using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.FreightManagement.Common.Models;
using Yanbal.SFT.Infrastructure.CrossCutting.Log4Net;
using Yanbal.SFT.Infrastructure.CrossCutting.Logging;

namespace Yanbal.SFT.Infrastructure.CrossCutting.Log
{
	/// <summary>
	/// Clase de Contexto de Carga
	/// </summary>
	/// <remarks>
	/// Creación:   GMD 20140922 <br />
	/// Modificación:            <br />
	/// </remarks>
	public class Logging : ILogging
	{
		private static readonly log4net.ILog Lognet = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		readonly Log4NetConfig log4NetConfigBD = null;

		/// <summary>
		/// Constructor por Defecto de implementación de la clase
		/// </summary>
		public Logging()
		{
			SingletonConfigurator.InicializarConfiguracion();
		}

		/// <summary>
		/// Constructor por Defecto de implementación de la clase
		/// </summary>
		/// <param name="log4NetConfig"></param>
		public Logging(Log4NetConfig log4NetConfig)
		{
			SingletonConfigurator.InicializarConfiguracion();
			if (log4NetConfig != null)
			{
				this.log4NetConfigBD = log4NetConfig;
				if (log4NetConfigBD.InternalDebug && log4NetConfigBD.RutasArchivoLog.Any())
				{
					int NodoComponente = 1;
					if (ConfigurationManager.AppSettings.AllKeys.Contains("NodoCluster"))
					{
						int valorNumerico = 0;
						if (int.TryParse(ConfigurationManager.AppSettings["NodoCluster"], out valorNumerico))
						{
							NodoComponente = Convert.ToInt32(ConfigurationManager.AppSettings["NodoCluster"]);
						}
					}
					string RutaArchivoLog = log4NetConfigBD.RutasArchivoLog.Where(x => x.IdNodo == NodoComponente).AsEnumerable().FirstOrDefault().RutaArchivoLog;
					if (!string.IsNullOrWhiteSpace(RutaArchivoLog))
					{
						Trace.Listeners.Clear();
						Trace.Close();
						TextWriterTraceListener myTextListener = new TextWriterTraceListener(RutaArchivoLog);
						Trace.Listeners.Add(myTextListener);
						log4net.Util.LogLog.InternalDebugging = log4NetConfigBD.InternalDebug;
						log4net.Config.XmlConfigurator.Configure();
					}
				}
			}
		}

		/// <summary>
		/// Permite añadir el logging de entrada
		/// </summary>
		/// <param name="logMessage">Mensaje de Logueo</param>
		/// <param name="severity"></param>
		/// <param name="title">Titúlo</param>
		private static void AddLogEntry(string logMessage, System.Diagnostics.TraceEventType severity, string title)
		{
			LogEntry logEntry = new LogEntry();

			logEntry.Categories.Clear();
			Logger.SetLogWriter(new LogWriterFactory().Create(), false);


			if (severity == TraceEventType.Critical)
				Logger.Write(logMessage, "EventLogCategory", 0, 5100, severity, title);
			else if (severity == TraceEventType.Error)
				Logger.Write(logMessage, "EventLogCategory", 1, 5200, severity, title);
			else if (severity == TraceEventType.Information)
				Logger.Write(logMessage, "DebugCategory", 2, 5300, severity, title);
			else if (severity == TraceEventType.Warning)
				Logger.Write(logMessage, "EventLogCategory", 3, 5400, severity, title);
			else
				Logger.Write(logMessage, "EventLogCategory", 4, 5400, severity, title);
		}
		/// <summary>
		/// Permire añadir logging
		/// </summary>
		/// <param name="errorManager">Administrador de error</param>
		/// <param name="requestType">Tipo de pedido</param>
		/// <param name="severity"></param>
		/// <param name="title">Titúlo</param>
		private static void AddLogging(Common.ErrorManagerType errorManager, string requestType, System.Diagnostics.TraceEventType severity, string title)
		{
			String strLogMessage = String.Format("ErrorManager: \nErrorNumber = {0} \nDescription = {1} \nSeverity = {2}-{3} \nRequestType = {4}",
									errorManager.ErrorNumber,
									errorManager.Description,
									errorManager.Severity,
									severity,
									requestType);

			Logging.AddLogEntry(strLogMessage, TraceEventType.Error, title);
		}

		/// <summary>
		/// Permite añadir mensaje en el visor de eventos según el tipo
		/// </summary>
		/// <param name="logMessage">Administrador de error</param>
		/// <param name="severity">Tipo de mensaje</param>
		/// <param name="title">Titúlo</param>
		public void Add(string logMessage, System.Diagnostics.TraceEventType severity, string title)
		{
			try
			{
				AddLogEntry(logMessage, severity, title);
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
		}

		/// <summary>
		/// Permite añadir mensaje 
		/// </summary>
		/// <param name="errorManager">Administrador de error</param>
		/// <param name="requestType">Tipo de pedido</param>
		/// <param name="severity">Tipo de mensaje</param>
		/// <param name="title">Titúlo</param>
		public void Add(Common.ErrorManagerType errorManager, string requestType, System.Diagnostics.TraceEventType severity, string title)
		{
			AddLogging(errorManager, requestType, severity, title);
		}

		/// <summary>
		/// AddLog4Net
		/// </summary>
		/// <param name="mensaje"></param>
		/// <param name="traces"></param>
		/// <param name="nivellog"></param>
		public void AddLog4Net(object mensaje, Traza traces, string nivellog)
		{
			try
			{
				if (this.log4NetConfigBD != null)
				{
					traces.Componente = log4NetConfigBD.Componente;
					if (nivellog == LogLevel.INFO.ToString() && log4NetConfigBD.Info)
					{
						traces.TramaRequest = "";
						traces.TramaResponse = "";
						VariablesLog(traces);
						Lognet.Info(mensaje);
					}
					else if (nivellog == LogLevel.ERROR.ToString() && log4NetConfigBD.Error)
					{
						VariablesLog(traces);
						Lognet.Error(mensaje);
					}
					else if (nivellog == LogLevel.DEBUG.ToString() && log4NetConfigBD.Debug)
					{
						VariablesLog(traces);
						Lognet.Debug(mensaje);
					}

					if (this.log4NetConfigBD.InternalDebug)
					{
						Trace.Close();
					}
				}
				else
				{
					traces.Componente = ConfigurationManager.AppSettings["NombreComponente"];
					if (nivellog == LogLevel.INFO.ToString() && ConfigurationManager.AppSettings.AllKeys.Contains("log4netFlagDefault")
						&& ConfigurationManager.AppSettings["log4netFlagDefault"] == Enumerated.EstadoLoggingFlag.Activo)
					{
						traces.TramaRequest = "";
						traces.TramaResponse = "";
						VariablesLog(traces);
						Lognet.Info(mensaje);
					}
					if (nivellog == LogLevel.ERROR.ToString() && ConfigurationManager.AppSettings.AllKeys.Contains("log4netFlagDefault") &&
							ConfigurationManager.AppSettings["log4netFlagDefault"] == Enumerated.EstadoLoggingFlag.Activo)
					{
						VariablesLog(traces);
						Lognet.Error(mensaje);
					}
				}
			}
			catch (Exception)
			{
				Debug.Write("");
			}
		}

		/// <summary>
		/// Variables Log
		/// </summary>
		/// <param name="traza"></param>
		public void VariablesLog(Traza traza)
		{
			log4net.ThreadContext.Stacks["tramarequest"].Clear();
			log4net.ThreadContext.Stacks["tramaresponse"].Clear();
			log4net.ThreadContext.Stacks["codigopais"].Clear();
			log4net.ThreadContext.Stacks["componente"].Clear();
			log4net.ThreadContext.Stacks["idtransaccion"].Clear();
			log4net.ThreadContext.Stacks["usuario"].Clear();
			log4net.ThreadContext.Stacks["metodo"].Clear();
			log4net.ThreadContext.Stacks["clase"].Clear();

			log4net.ThreadContext.Stacks["tramarequest"].Push(traza.TramaRequest != null ? traza.TramaRequest : "");
			log4net.ThreadContext.Stacks["tramaresponse"].Push(traza.TramaResponse != null ? traza.TramaResponse : "");
			log4net.ThreadContext.Stacks["codigopais"].Push(traza.CodigoPais);
			log4net.ThreadContext.Stacks["componente"].Push(traza.Componente);
			log4net.ThreadContext.Stacks["idtransaccion"].Push(traza.IdTransaccion);
			log4net.ThreadContext.Stacks["usuario"].Push(traza.Cliente);
			log4net.ThreadContext.Stacks["metodo"].Push(traza.Metodo);
			log4net.ThreadContext.Stacks["clase"].Push(traza.Clase);
			log4net.ThreadContext.Stacks["codigo_interno"].Push(traza.codigo_interno ?? string.Empty);
			log4net.ThreadContext.Stacks["codigo_general"].Push(traza.codigo_general ?? string.Empty);
			log4net.ThreadContext.Stacks["nodocluster"].Push(traza.NodoCluster ?? string.Empty);
		}


		/// <summary>
		/// Clase para devuelve los valores para el log
		/// </summary>
		public static class TraceFactory
		{
			/// <summary>
			/// Clase donde se envia datos para el log
			/// </summary>
			/// <param name="IdTransaccion">Codigo de transaccion</param>
			/// <param name="cliente">Usuario del servicio</param>
			/// <param name="pais">Codigo del Pais</param>
			/// <param name="metodo">Nombre Metodo</param>
			/// <param name="clase">Nombre de la clase</param>
			/// <returns></returns>
			public static Traza Create(string IdTransaccion, string cliente, string pais, string metodo, string clase)
			{
				return new Traza
				{
					IdTransaccion = string.IsNullOrWhiteSpace(IdTransaccion) ? Guid.NewGuid().ToString() : IdTransaccion,
					Cliente = string.IsNullOrWhiteSpace(cliente) ? ConfigurationManager.AppSettings["NombreComponente"] : cliente,
					CodigoPais = string.IsNullOrWhiteSpace(pais) ? Enumerated.UnidadNegocio.NombreUnidadNegocio : pais,
					NodoCluster = ConfigurationManager.AppSettings.AllKeys.Contains("NodoCluster") ? ConfigurationManager.AppSettings["NodoCluster"] : string.Empty,
					Metodo = metodo,
					Clase = clase
				};
			}
		}
	}
}
