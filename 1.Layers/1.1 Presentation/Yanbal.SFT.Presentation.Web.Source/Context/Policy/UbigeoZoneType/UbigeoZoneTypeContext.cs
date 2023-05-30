using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.FreightManagement.Common.Custom;
using Yanbal.SFT.FreightManagement.Common.Response;
using Yanbal.SFT.Infrastructure.CrossCutting.Log;
using Yanbal.SFT.Infrastructure.CrossCutting.Log4Net;
using Yanbal.SFT.PolicyManager.Domain;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Context.Common;
using Yanbal.SFT.Presentation.Web.Source.Context.Policy.Culture;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using Yanbal.SFT.Presentation.Web.Source.Models.Report;
using Yanbal.SFT.Presentation.Web.Source.Session;
using static Yanbal.SFT.Infrastructure.CrossCutting.Log.Logging;

namespace Yanbal.SFT.Presentation.Web.Source.Context.Policy.UbigeoZoneType
{
    /// <summary>
    /// Contexto de la vista de Tipo de Zona de Ubigeo
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140827 <br />
    /// Modificación: 
    /// </remarks>
    public class UbigeoZoneTypeContext
    {
        #region Properties
        //Inicio Sonar 15/08/2016
        readonly IPolicyDomain policyDomain;
        readonly YanbalSession yanbalSession;
        readonly List<ParameterValueEL> geoLevel;
        //Fin Sonar
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de implementación de la clase
        /// </summary>
        /// <param name="yanbalSession">YanbalSession</param>
        public UbigeoZoneTypeContext(YanbalSession yanbalSession)
        {
            this.yanbalSession = yanbalSession;
            this.policyDomain = new PolicyDomain();

            this.geoLevel = policyDomain.ParameterValueSearch(new ParameterValueRequest()
            {
                BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                Code = Enumerated.Parameter.LevelGeoZone,
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Permite generar el Modelo de la ventana de Asignación de Zonas
        /// </summary>
        /// <returns>Modelo a aplicar en la vista</returns>
        public UbigeoZoneTypeModel Index()
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            UbigeoZoneTypeModel ubigeoZoneTypeModel = new UbigeoZoneTypeModel();
           
            try
            {
                string controllerName = "UbigeoZoneType";

                ubigeoZoneTypeModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;

                ubigeoZoneTypeModel.Search = new ButtonControl();
                ubigeoZoneTypeModel.Search.Id = "btnSearch";
                BaseContext.GetAccessControl(ubigeoZoneTypeModel.Search.Id, controllerName, ubigeoZoneTypeModel.Search);

                ubigeoZoneTypeModel.Create = new ButtonControl();
                ubigeoZoneTypeModel.Create.Id = "btnCreate";
                BaseContext.GetAccessControl(ubigeoZoneTypeModel.Create.Id, controllerName, ubigeoZoneTypeModel.Create);

                ubigeoZoneTypeModel.Visualize = new ButtonControl();
                ubigeoZoneTypeModel.Visualize.Id = "btnVisualize";
                BaseContext.GetAccessControl(ubigeoZoneTypeModel.Visualize.Id, controllerName, ubigeoZoneTypeModel.Visualize);

                ubigeoZoneTypeModel.Edit = new ImageControl();
                ubigeoZoneTypeModel.Edit.Id = "ibtEdit";
                BaseContext.GetAccessControl(ubigeoZoneTypeModel.Edit.Id, controllerName, ubigeoZoneTypeModel.Edit);

                ubigeoZoneTypeModel.ListTypeZone = GetListTypeZone();
                ubigeoZoneTypeModel.ListZoneLevel1 = GetListProvince();

                if (geoLevel.Count == 3)
                {
                    ubigeoZoneTypeModel.LabelGeoLevel1 = geoLevel[0].RecordValueString["2"];
                    ubigeoZoneTypeModel.LabelGeoLevel2 = geoLevel[1].RecordValueString["2"];
                    ubigeoZoneTypeModel.LabelGeoLevel3 = geoLevel[2].RecordValueString["2"];
                }
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }

            return ubigeoZoneTypeModel;
        }

        /// <summary>
        /// Permite realizar la búsqueda de Asignación de Zonas
        /// </summary>
        /// <param name="ubigeoZoneTypeRequest">Filtro de Busqueda</param>
        /// <returns>Lista de resultado de la búsqueda</returns>
        public List<UbigeoZoneTypeEL> Search(UbigeoZoneTypeRequest ubigeoZoneTypeRequest)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            List<UbigeoZoneTypeEL> resultUbigeoZoneType = new List<UbigeoZoneTypeEL>();

            try
            {
                if (yanbalSession.ListRegistrationStatus != null && yanbalSession.ListRegistrationStatus.Count > 0)
                {
                    ubigeoZoneTypeRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                    ubigeoZoneTypeRequest.CodeCountry = yanbalSession.BusinessUnit.CountryZoneCode;
                    ubigeoZoneTypeRequest.CodeLevel1 = (ubigeoZoneTypeRequest.CodeLevel1 != null && ubigeoZoneTypeRequest.CodeLevel1.Trim() != "") ? ubigeoZoneTypeRequest.CodeLevel1.Trim() : null;
                    ubigeoZoneTypeRequest.CodeLevel2 = (ubigeoZoneTypeRequest.CodeLevel2 != null && ubigeoZoneTypeRequest.CodeLevel2.Trim() != "") ? ubigeoZoneTypeRequest.CodeLevel2.Trim() : null;
                    ubigeoZoneTypeRequest.CodeLevel3 = (ubigeoZoneTypeRequest.CodeLevel3 != null && ubigeoZoneTypeRequest.CodeLevel3.Trim() != "") ? ubigeoZoneTypeRequest.CodeLevel3.Trim() : null;

                    resultUbigeoZoneType = policyDomain.UbigeoZoneTypeSearch(ubigeoZoneTypeRequest).Result;
                }
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return resultUbigeoZoneType;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para registrar Asignación de Zonas
        /// </summary>
        /// <returns>Modelo a aplicar en la vista</returns>
        public UbigeoZoneTypeModel Create()
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            UbigeoZoneTypeModel ubigeoZoneTypeModel = new UbigeoZoneTypeModel();
            
            try
            {
                string controllerName = "UbigeoZoneType";

                ubigeoZoneTypeModel.Save = new ButtonControl();
                ubigeoZoneTypeModel.Save.Id = "btnSaveCreate";
                BaseContext.GetAccessControl(ubigeoZoneTypeModel.Save.Id, controllerName, ubigeoZoneTypeModel.Save);

                ubigeoZoneTypeModel.Cancel = new ButtonControl();
                ubigeoZoneTypeModel.Cancel.Id = "btnCancelCreate";
                BaseContext.GetAccessControl(ubigeoZoneTypeModel.Cancel.Id, controllerName, ubigeoZoneTypeModel.Cancel);

                ubigeoZoneTypeModel.CodeCountry = yanbalSession.BusinessUnit.CountryZoneCode;
                ubigeoZoneTypeModel.NameCountry = yanbalSession.BusinessUnit.CountryName;

                ubigeoZoneTypeModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;
                ubigeoZoneTypeModel.LabelRegistrationStatus = ((ubigeoZoneTypeModel.ListRegistrationStatus.Count <= 0) ? "" : ubigeoZoneTypeModel.ListRegistrationStatus.OrderByDescending(item => item.Id).FirstOrDefault().Name.ToString());
                ubigeoZoneTypeModel.ListTypeZone = GetListTypeZone();
                ubigeoZoneTypeModel.ListZoneLevel1 = GetListProvince();

                if (geoLevel.Count == 3)
                {
                    ubigeoZoneTypeModel.LabelGeoLevel1 = geoLevel[0].RecordValueString["2"];
                    ubigeoZoneTypeModel.LabelGeoLevel2 = geoLevel[1].RecordValueString["2"];
                    ubigeoZoneTypeModel.LabelGeoLevel3 = geoLevel[2].RecordValueString["2"];
                }
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return ubigeoZoneTypeModel;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para modificar Asignación de Zonas
        /// </summary>
        /// <param name="codeTypeZoneUbigeo">Código de Tipo de Zona de Ubigeo</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public UbigeoZoneTypeModel Edit(int codeTypeZoneUbigeo)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            UbigeoZoneTypeModel ubigeoZoneTypeModel = new UbigeoZoneTypeModel();
            
            try
            {
                string controllerName = "UbigeoZoneType";

                ubigeoZoneTypeModel.Save = new ButtonControl();
                ubigeoZoneTypeModel.Save.Id = "btnSaveEdit";
                BaseContext.GetAccessControl(ubigeoZoneTypeModel.Save.Id, controllerName, ubigeoZoneTypeModel.Save);

                ubigeoZoneTypeModel.Cancel = new ButtonControl();
                ubigeoZoneTypeModel.Cancel.Id = "btnCancelEdit";
                BaseContext.GetAccessControl(ubigeoZoneTypeModel.Cancel.Id, controllerName, ubigeoZoneTypeModel.Cancel);

                UbigeoZoneTypeEL ubigeoZoneTypeEL = policyDomain.UbigeoZoneTypeSearch(new UbigeoZoneTypeRequest() { BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode, CodeTypeZoneUbigeo = codeTypeZoneUbigeo }).Result.FirstOrDefault();

                ubigeoZoneTypeModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;
                ubigeoZoneTypeModel.ListTypeZone = GetListTypeZone();
                ubigeoZoneTypeModel.ListZoneLevel1 = GetListProvince();

                if (geoLevel.Count == 3)
                {
                    ubigeoZoneTypeModel.LabelGeoLevel1 = geoLevel[0].RecordValueString["2"];
                    ubigeoZoneTypeModel.LabelGeoLevel2 = geoLevel[1].RecordValueString["2"];
                    ubigeoZoneTypeModel.LabelGeoLevel3 = geoLevel[2].RecordValueString["2"];
                }

                if (ubigeoZoneTypeEL != null)
                {
                    ubigeoZoneTypeModel.CodeTypeZoneUbigeo = ubigeoZoneTypeEL.CodeTypeZoneUbigeo;
                    ubigeoZoneTypeModel.CodeZone = ubigeoZoneTypeEL.CodeZone;
                    ubigeoZoneTypeModel.CodeCountry = ubigeoZoneTypeEL.CodeCountry;
                    ubigeoZoneTypeModel.NameCountry = ubigeoZoneTypeEL.DescriptionCountry;
                    ubigeoZoneTypeModel.CodeLevel1 = ubigeoZoneTypeEL.CodeLevel1;
                    ubigeoZoneTypeModel.CodeLevel2 = ubigeoZoneTypeEL.CodeLevel2;
                    ubigeoZoneTypeModel.CodeLevel3 = ubigeoZoneTypeEL.CodeLevel3;
                    ubigeoZoneTypeModel.CodeTypeZone = ubigeoZoneTypeEL.CodeTypeZone;
                    if (ubigeoZoneTypeModel.CodeLevel1 != null && !ubigeoZoneTypeModel.CodeLevel1.Equals(string.Empty))
                    {
                        ubigeoZoneTypeModel.ListZoneLevel2 = GetListCity(ubigeoZoneTypeModel.CodeLevel1);
                    }
                    if (ubigeoZoneTypeModel.CodeLevel2 != null && !ubigeoZoneTypeModel.CodeLevel2.Equals(string.Empty))
                    {
                        ubigeoZoneTypeModel.ListZoneLevel3 = GetListDistrict(ubigeoZoneTypeModel.CodeLevel1, ubigeoZoneTypeModel.CodeLevel2);
                    }
                    ubigeoZoneTypeModel.DescriptionTypeZone = ubigeoZoneTypeEL.DescriptionTypeZone;
                    ubigeoZoneTypeModel.RegistrationStatus = ubigeoZoneTypeEL.RegistrationStatus;
                }
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return ubigeoZoneTypeModel;
        }

        /// <summary>
        /// Permite el registro de Asignación de Zonas
        /// </summary>
        /// <param name="register">Tipo de Zonas de Ubigeo</param>
        /// <returns>Indicador de Conformidad</returns>
        public string RegisterUbigeoZoneType(UbigeoZoneTypeRequest register)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            ProcessResult<string> result = new ProcessResult<string>();
            try
            {
                register.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                register.CodeLevel1 = (register.CodeLevel1 != null && register.CodeLevel1.Trim() != "") ? register.CodeLevel1.Trim() : null;
                register.CodeLevel2 = (register.CodeLevel2 != null && register.CodeLevel2.Trim() != "") ? register.CodeLevel2.Trim() : null;
                register.CodeLevel3 = (register.CodeLevel3 != null && register.CodeLevel3.Trim() != "") ? register.CodeLevel3.Trim() : null;
                register.UserCreation = yanbalSession.User.Login;
                register.TerminalCreation = yanbalSession.User.Ip;
                result = policyDomain.UbigeoZoneTypeRegister(register);
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return result.Result;
        }

        /// <summary>
        /// Permite la modificación de Asignación de Zonas
        /// </summary>
        /// <param name="register">Tipo de Zonas de Ubigeo</param>
        /// <returns>Indicador de Conformidad</returns>
        public string ModifyUbigeoZoneType(UbigeoZoneTypeRequest register)
        {
            ILogging ilog4Net = new Logging();
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = string.IsNullOrEmpty(yanbalSession?.IdTransaccionLog) ? Guid.NewGuid().ToString() : yanbalSession.IdTransaccionLog;
            string CodigoPais = string.IsNullOrEmpty(yanbalSession?.BusinessUnit?.CountryCode) ? string.Empty : yanbalSession.BusinessUnit.CountryCode;
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, CodigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(CultureContext).FullName);

            ProcessResult<string> result = new ProcessResult<string>();
        
            try
            {
                register.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                register.CodeLevel1 = (register.CodeLevel1 != null && register.CodeLevel1.Trim() != "") ? register.CodeLevel1.Trim() : null;
                register.CodeLevel2 = (register.CodeLevel2 != null && register.CodeLevel2.Trim() != "") ? register.CodeLevel2.Trim() : null;
                register.CodeLevel3 = (register.CodeLevel3 != null && register.CodeLevel3.Trim() != "") ? register.CodeLevel3.Trim() : null;
                register.UserModification = yanbalSession.User.Login;
                register.TerminalModification = yanbalSession.User.Ip;
                result = policyDomain.UbigeoZoneTypeUpdate(register);
            }
            catch (Exception ex)
            {
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            return result.Result;
        }
        #endregion

        #region Adapters
        /// <summary>
        /// Adaptador de lista de Zonas de Nivel 1
        /// </summary>
        /// <returns>Lista con opciones</returns>
        private List<SelectType> GetListProvince()
        {
            List<SelectType> listSelect = new List<SelectType>();

            var provinceEl = policyDomain.ProvinceSearch(new ProvinceRequest() { CountryCode = yanbalSession.BusinessUnit.CountryCode }).Result;
            foreach (var item in provinceEl)
            {
                SelectType selectType = new SelectType()
                {
                    Id = item.ProvinceCode,
                    Name = item.ProvinceName
                };

                listSelect.Add(selectType);
            }
            return listSelect;
        }

        /// <summary>
        /// Adaptador de lista de Zonas de Nivel 2
        /// </summary>
        /// <param name="codeZoneLevel1">Código de Nivel 1</param>
        /// <returns>Lista con opciones</returns>
        public List<SelectType> GetListCity(string codeZoneLevel1)
        {
            List<SelectType> listSelect = new List<SelectType>();

            var cityEl = policyDomain.CitySearch(new CityRequest() { ProvinceCode = codeZoneLevel1 }).Result;
            foreach (var item in cityEl)
            {
                SelectType selectType = new SelectType()
                {
                    Id = item.CityCode,
                    Name = item.CityName
                };

                listSelect.Add(selectType);
            }
            return listSelect;
        }

        /// <summary>
        /// Adaptador de lista de Zonas de Nivel 3
        /// </summary>
        /// <param name="codeZoneLevel1">Código de Nivel 1</param>
        /// <param name="codeZoneLevel2">Código de Nivel 2</param>
        /// <returns>Lista con opciones</returns>
        public List<SelectType> GetListDistrict(string codeZoneLevel1, string codeZoneLevel2)
        {
            List<SelectType> listSelect = new List<SelectType>();

            var provinceEl = policyDomain.DistrictSearch(new DistrictRequest() { CityCode = codeZoneLevel2 }).Result;
            foreach (var item in provinceEl)
            {
                SelectType selectType = new SelectType()
                {
                    Id = item.DistrictCode,
                    Name = item.DistrictName
                };

                listSelect.Add(selectType);
            }
            return listSelect;
        }

        /// <summary>
        /// Adaptador de lista de opciones a lista de combos
        /// </summary>
        /// <returns>Lista con opciones</returns>
        private List<SelectType> GetListTypeZone()
        {
            List<SelectType> listSelect = new List<SelectType>();

            var listResult = policyDomain.ParameterValueSearch(new ParameterValueRequest()
            {
                BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                Code = Enumerated.Parameter.ZoneType.ToString(),
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result;

            foreach (var item in listResult.Select(itemResult => itemResult.RecordValueString))
            {
                listSelect.Add(new SelectType() { Id = item["1"], Name = item["2"] });
            }
            return listSelect;
        }
        #endregion

        #region Reporte
        /// <summary>
        /// Permite generar el Modelo del Reporte
        /// </summary>
        /// <param name="filter">Reporte de Auditoría</param>
        /// <returns>Modelo a aplicar al Reporte</returns>
        public ReportModel Report(UbigeoZoneTypeRequest filter)
        {
            ReportModel reportModel = new ReportModel();

            string labelGeoLevel1 = "", labelGeoLevel2 = "", labelGeoLevel3 = "";

            if (geoLevel.Count == 3)
            {
                labelGeoLevel1 = geoLevel[0].RecordValueString["2"];
                labelGeoLevel2 = geoLevel[1].RecordValueString["2"];
                labelGeoLevel3 = geoLevel[2].RecordValueString["2"];
            }

            var yanbalSession = SessionContext.GetYanbalSession();
            var reportingSessionWorkspacePathPolicy = yanbalSession != null ? yanbalSession.ReportingWorkspacePathPolicy : "";
            reportModel.PathReport = String.Format("{0}{1}", reportingSessionWorkspacePathPolicy, Enumerated.ReportFileName.PolicyAllocationAreas);
            reportModel.AddParameter("USUARIO", this.yanbalSession.User.Login);
            reportModel.AddParameter("AREA", "FLETES");
            reportModel.AddParameter("CODIGO_LENGUAJE", "");
            reportModel.AddParameter("NOMBRE_REPORTE", Resources.Policy.UbigeoZoneType.IndexResource.LabelTitleUbigeoZoneTypeReport.ToUpper());
            reportModel.AddParameter("CODIGO_UNIDAD_NEGOCIO", this.yanbalSession.BusinessUnit.BusinessUnitCode.ToString());
            reportModel.AddParameter("ETIQUETA_SYSTEM", Resources.Shared.GeneralResource.LabelSystem);

            reportModel.AddParameter("CODIGO_NIVEL_1", (filter.CodeLevel1 != null && filter.CodeLevel1.Trim() != "") ? filter.CodeLevel1.Trim() : null);
            reportModel.AddParameter("CODIGO_NIVEL_2", (filter.CodeLevel2 != null && filter.CodeLevel2.Trim() != "") ? filter.CodeLevel2.Trim() : null);
            reportModel.AddParameter("CODIGO_NIVEL_3", (filter.CodeLevel3 != null && filter.CodeLevel3.Trim() != "") ? filter.CodeLevel3.Trim() : null);

            reportModel.AddParameter("NIVEL_1", filter.Level1);
            reportModel.AddParameter("NIVEL_2", filter.Level2);
            reportModel.AddParameter("NIVEL_3", filter.Level3);

            reportModel.AddParameter("CODIGO_TIPO_ZONA", filter.CodeTypeZone);
            reportModel.AddParameter("DESCRIPCION_TIPO_ZONA", filter.TypeZoneDescription);

            reportModel.AddParameter("ESTADO_REGISTRO", filter.RegistrationStatus ?? string.Empty);
            reportModel.AddParameter("DESCRIPCION_ESTADO_REGISTRO", filter.DescriptionRegistrationStatus ?? string.Empty);

            reportModel.AddParameter("FORMATO_FECHA_CORTA", this.yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionShortDateFormat);
            reportModel.AddParameter("FORMATO_FECHA_LARGA", this.yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionLongDateFormat);
            reportModel.AddParameter("FORMATO_HORA_CORTA", this.yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionShortTimeFormat);
            reportModel.AddParameter("FORMATO_HORA_LARGA", this.yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionLongTimeFormat);
            reportModel.AddParameter("FORMATO_NUMERO_ENTERO", this.yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionFormatIntegerNumber);
            reportModel.AddParameter("FORMATO_NUMERO_DECIMAL", this.yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionFormatDecimalNumber);

            reportModel.AddParameter("COLUMNA_PAIS", Resources.Policy.UbigeoZoneType.IndexResource.LabelGridCountry ?? string.Empty);
            reportModel.AddParameter("COLUMNA_DEPARTAMENTO", labelGeoLevel1 ?? string.Empty);
            reportModel.AddParameter("COLUMNA_CIUDAD", labelGeoLevel2 ?? string.Empty);
            reportModel.AddParameter("COLUMNA_ZONA", labelGeoLevel3 ?? string.Empty);
            reportModel.AddParameter("COLUMNA_TIPO_ZONA", Resources.Policy.UbigeoZoneType.IndexResource.ColumnTypeArea ?? string.Empty);
            reportModel.AddParameter("COLUMNA_ESTADO_REGISTRO", Resources.Policy.UbigeoZoneType.IndexResource.ColumnRegistrationStatus ?? string.Empty);
            reportModel.AddParameter("COLUMNA_TODOS", Resources.Shared.GeneralResource.LabelSelectAll ?? string.Empty);

            reportModel.AddParameter("ETIQUETA_DEPARTAMENTO", labelGeoLevel1 ?? string.Empty);
            reportModel.AddParameter("ETIQUETA_CIUDAD", labelGeoLevel2 ?? string.Empty);
            reportModel.AddParameter("ETIQUETA_ZONA", labelGeoLevel3 ?? string.Empty);
            reportModel.AddParameter("ETIQUETA_TIPO_ZONA", Resources.Policy.UbigeoZoneType.IndexResource.LabelTypeArea ?? string.Empty);
            reportModel.AddParameter("ETIQUETA_ESTADO_REGISTRO", Resources.Policy.UbigeoZoneType.IndexResource.LabelRegistrationStatus ?? string.Empty);
            reportModel.AddParameter("ETIQUETA_HORA", Resources.Policy.UbigeoZoneType.IndexResource.LabelHour ?? string.Empty);
            reportModel.AddParameter("ETIQUETA_FECHA", Resources.Policy.UbigeoZoneType.IndexResource.LabelDate ?? string.Empty);
            reportModel.AddParameter("COLUMNA_USUARIO", Resources.Shared.GeneralResource.LabelUser ?? string.Empty);
            reportModel.AddParameter("COLUMNA_AREA", Resources.Shared.GeneralResource.LabelArea ?? string.Empty);

            reportModel.AddParameter("ETIQUETA_PAGINA", Resources.Policy.UbigeoZoneType.IndexResource.LabelPage ?? string.Empty);
            reportModel.AddParameter("ETIQUETA_PAGINA_DE", Resources.Policy.UbigeoZoneType.IndexResource.LabelPageOf ?? string.Empty);
            reportModel.AddParameter("PIE_REPORTE", string.Format(Resources.Shared.GeneralResource.LabelReportEndOf, (Resources.Policy.UbigeoZoneType.IndexResource.LabelTitleUbigeoZoneTypeReport.ToUpper())));
            return reportModel;
        }
        #endregion
    }
}
