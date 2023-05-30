using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.Infrastructure.CrossCutting.Common;
using Yanbal.SFT.Infrastructure.CrossCutting.Log4Net;

namespace Yanbal.SFT.Infrastructure.CrossCutting.Log
{
    /// <summary>
    /// Clase de Carga
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20140922 <br />
    /// Modificación:            <br />
    /// </remarks>
    public interface ILogging
    {
        /// <summary>
        /// Add
        /// </summary>
        void Add(String logMessage, TraceEventType severity, String title);
        /// <summary>
        /// Add
        /// </summary>
        void Add(ErrorManagerType errorManager, String requestType, TraceEventType severity, String title);

        /// <summary>
		/// AddLog4Net
		/// </summary>
		/// <param name="mensaje"></param>
		/// <param name="traces"></param>
		/// <param name="nivellog"></param>
		void AddLog4Net(object mensaje, Traza traces, string nivellog);
    }
}
