using System;
using System.Collections.Generic;
using System.Linq;
using Yanbal.SFT.Domain.Entities.Logic.Common;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.PolicyManager.Domain;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Context.Common;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;
using Yanbal.SFT.Presentation.Web.Source.Models.Freight;
using Yanbal.SFT.Presentation.Web.Source.Models.Report;
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Source.Context.Freight.Combination
{
    /// <summary>
    /// Contexto de la vista de Combinación
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140905 <br />
    /// Modificación: 
    /// </remarks>
    public class CombinationContext
    {
        #region Properties
        //Inicio Sonar 15/08/2016
        readonly IPolicyDomain policyDomain;
        readonly YanbalSession yanbalSession;
        readonly EnvironmentEL environment;
        //Fin Sonar
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de implementación de la clase
        /// </summary>
        /// <param name="yanbalSession">Objeto mantenido en Sesión</param>
        public CombinationContext(YanbalSession yanbalSession)
        {
            this.yanbalSession = yanbalSession;
            environment = BaseContext.EnvironmentAdapter(yanbalSession);
            this.policyDomain = new PolicyDomain(environment);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Permite generar el Modelo de la ventana de Combinación
        /// </summary>
        /// <returns>Modelo a aplicar en la vista</returns>
        public CombinationModel Index()
        {
            CombinationModel combinationModel = new CombinationModel();
            string controllerName = "Combination";

            combinationModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;

            combinationModel.Parameter = new ImageControl();
            combinationModel.Parameter.Id = "lnkParameter";
            BaseContext.GetAccessControl(combinationModel.Parameter.Id, controllerName, combinationModel.Parameter);

            combinationModel.Visualize = new ButtonControl();
            combinationModel.Visualize.Id = "btnVisualize";
            BaseContext.GetAccessControl(combinationModel.Visualize.Id, controllerName, combinationModel.Visualize);

            combinationModel.Search = new ButtonControl();
            combinationModel.Search.Id = "btnSearch";
            BaseContext.GetAccessControl(combinationModel.Search.Id, controllerName, combinationModel.Search);

            combinationModel.Create = new ButtonControl();
            combinationModel.Create.Id = "btnCreate";
            BaseContext.GetAccessControl(combinationModel.Create.Id, controllerName, combinationModel.Create);
            
            combinationModel.Edit = new ImageControl();
            combinationModel.Edit.Id = "ibtEdit";
            BaseContext.GetAccessControl(combinationModel.Edit.Id, controllerName, combinationModel.Edit);

            combinationModel.ListParameter = GetListParameter();
            return combinationModel;
        }

        /// <summary>
        /// Permite realizar la búsqueda de Combinación
        /// </summary>
        /// <param name="combinationRequest">Filtro de Combinación</param>
        /// <returns>Lista de resultado de Combinación</returns>
        public List<CombinationEL> Search(CombinationRequest combinationRequest)
        {
            List<CombinationEL> resultCombination = new List<CombinationEL>();
            if (yanbalSession.ListRegistrationStatus != null && yanbalSession.ListRegistrationStatus.Count > 0)
            {
                combinationRequest.GetParametersCombination = true;
                combinationRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                resultCombination = policyDomain.CombinationSearch(combinationRequest).Result;
            }
            return resultCombination;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para registrar Combinación
        /// </summary>
        /// <returns>Modelo a aplicar en la vista</returns>
        public CombinationModel Create()
        {
            CombinationModel combinationModel = new CombinationModel();
            string controllerName = "Combination";

            combinationModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;
            combinationModel.LabelRegistrationStatus = ((combinationModel.ListRegistrationStatus.Count <= 0) ? "" : combinationModel.ListRegistrationStatus.OrderByDescending(item => item.Id).FirstOrDefault().Name.ToString());

            combinationModel.Add = new ButtonControl();
            combinationModel.Add.Id = "btnAddCreate";
            BaseContext.GetAccessControl(combinationModel.Add.Id, controllerName, combinationModel.Add);

            combinationModel.Save = new ButtonControl();
            combinationModel.Save.Id = "btnSaveCreate";
            BaseContext.GetAccessControl(combinationModel.Save.Id, controllerName, combinationModel.Save);

            combinationModel.Cancel = new ButtonControl();
            combinationModel.Cancel.Id = "btnCancelCreate";
            BaseContext.GetAccessControl(combinationModel.Cancel.Id, controllerName, combinationModel.Cancel);

            combinationModel.Delete = new ImageControl();
            combinationModel.Delete.Id = "ibtDelete";
            BaseContext.GetAccessControl(combinationModel.Delete.Id, controllerName, combinationModel.Delete);

            combinationModel.ListParameter = GetListParameter();
            combinationModel.ListCodeParameter = new List<int>();

            combinationModel.ListParameterValue = (combinationModel.ListParameter != null) ? GetListParameterValue(Convert.ToInt32(combinationModel.ListParameter.FirstOrDefault().ParameterCode)) : new List<SelectType>();
            return combinationModel;


        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para registrar Combinación de Parámetros
        /// </summary>
        /// <returns>Modelo a aplicar en la vista</returns>
        public CombinationModel CreateParameterCombination()
        {
            CombinationModel combinationModel = new CombinationModel();
            string controllerName = "Combination";

            combinationModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;
            combinationModel.LabelRegistrationStatus = ((combinationModel.ListRegistrationStatus.Count <= 0) ? "" : combinationModel.ListRegistrationStatus.OrderByDescending(item => item.Id).FirstOrDefault().Name.ToString());

            combinationModel.Add = new ButtonControl();
            combinationModel.Add.Id = "btnAddPCCreate";
            BaseContext.GetAccessControl(combinationModel.Add.Id, controllerName, combinationModel.Add);

            combinationModel.Save = new ButtonControl();
            combinationModel.Save.Id = "btnSavePCCreate";
            BaseContext.GetAccessControl(combinationModel.Save.Id, controllerName, combinationModel.Save);

            combinationModel.Cancel = new ButtonControl();
            combinationModel.Cancel.Id = "btnCancelPCCreate";
            BaseContext.GetAccessControl(combinationModel.Cancel.Id, controllerName, combinationModel.Cancel);

            combinationModel.Delete = new ImageControl();
            combinationModel.Delete.Id = "ibtDelete";
            BaseContext.GetAccessControl(combinationModel.Delete.Id, controllerName, combinationModel.Delete);

            combinationModel.ListParameter = GetListParameter();
            combinationModel.ListCodeParameter = new List<int>();

            combinationModel.ListParameterValue = GetListParameterValue(Convert.ToInt32(combinationModel.ListParameter.FirstOrDefault().ParameterCode));
            return combinationModel;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para modificar Combinación
        /// </summary>
        /// <param name="codeCombination">Código de Combinación</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public CombinationModel Edit(int codeCombination)
        {
            CombinationModel combinationModel = new CombinationModel();
            string controllerName = "Combination";

            combinationModel.Save = new ButtonControl();
            combinationModel.Save.Id = "btnSaveEdit";
            BaseContext.GetAccessControl(combinationModel.Save.Id, controllerName, combinationModel.Save);

            combinationModel.Cancel = new ButtonControl();
            combinationModel.Cancel.Id = "btnCancelEdit";
            BaseContext.GetAccessControl(combinationModel.Cancel.Id, controllerName, combinationModel.Cancel);

            CombinationEL combinationEL = policyDomain.CombinationSearch(new CombinationRequest() { BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode, CombinationCode = codeCombination }).Result.FirstOrDefault();

            if (combinationEL != null)
            {
                combinationModel.CodeCombination = combinationEL.CombinationCode;
                combinationModel.AmountFreightString = combinationEL.AmountFreightString;
                combinationModel.RegistrationStatus = combinationEL.RegistrationStatus;
            }

            combinationModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;
            
            return combinationModel;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para modificar Combinación de Parámetros
        /// </summary>
        /// <param name="codeCombination">Código de Combinación</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public CombinationModel EditParameterCombination(int codeCombination)
        {
            CombinationModel combinationModel = new CombinationModel();
            string controllerName = "Combination";

            combinationModel.Add = new ButtonControl();
            combinationModel.Add.Id = "btnAddEdit";
            BaseContext.GetAccessControl(combinationModel.Add.Id, controllerName, combinationModel.Add);

            combinationModel.Save = new ButtonControl();
            combinationModel.Save.Id = "btnSaveEdit";
            BaseContext.GetAccessControl(combinationModel.Save.Id, controllerName, combinationModel.Save);

            combinationModel.Cancel = new ButtonControl();
            combinationModel.Cancel.Id = "btnCancelEdit";
            BaseContext.GetAccessControl(combinationModel.Cancel.Id, controllerName, combinationModel.Cancel);

            combinationModel.Delete = new ImageControl();
            combinationModel.Delete.Id = "ibtDelete";
            BaseContext.GetAccessControl(combinationModel.Delete.Id, controllerName, combinationModel.Delete);

            var combinationEL = policyDomain.CombinationSearch(new CombinationRequest() { BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode, CombinationCode = codeCombination, GetParametersCombination = true }).Result.FirstOrDefault();

            if (combinationEL != null)
            {
                combinationModel.CodeCombination = combinationEL.CombinationCode;
                combinationModel.AmountFreightString = combinationEL.AmountFreightString;
                combinationModel.RegistrationStatus = combinationEL.RegistrationStatus;
            }

            combinationModel.ListParameter = GetListParameter();

            combinationModel.ListCodeParameter = new List<int>();

            combinationModel.ListParameterCombination = combinationEL.ListParameterCombination;
            
            return combinationModel;
        }

        /// <summary>
        /// Permite el registro de Combinación
        /// </summary>
        /// <param name="combinationRequest">Combinación</param>
        /// <returns>Indicador de Conformidad</returns>
        public string RegisterCombination(CombinationRequest combinationRequest)
        {
            combinationRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
            combinationRequest.UserCreation = yanbalSession.User.Login;
            combinationRequest.TerminalCreation = yanbalSession.User.Ip;
            var result = policyDomain.CombinationRegister(combinationRequest).Result;
            return result;
        }

        /// <summary>
        /// Permite la modificación de Combinación
        /// </summary>
        /// <param name="register">Combinación</param>
        /// <returns>Indicador de Conformidad</returns>
        public string ModifyCombination(CombinationRequest register)
        {
            register.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
            register.UserModification = yanbalSession.User.Login;
            register.TerminalModification = yanbalSession.User.Ip;
            var result = policyDomain.CombinationUpdate(register).Result;
            return result;
        }

        /// <summary>
        /// Permite la modificación de Combinación
        /// </summary>
        /// <param name="register">Combinación</param>
        /// <returns>Indicador de Conformidad</returns>
        public string ModifyParameterCombination(CombinationRequest register)
        {
            register.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
            register.UserModification = yanbalSession.User.Login;
            register.TerminalModification = yanbalSession.User.Ip;
            var result = policyDomain.ParameterCombinationUpdate(register).Result;
            return result;
        }
        
        #endregion

        #region Adapters
        /// <summary>
        /// Obtiene las lista de Parámetros de Combinación
        /// </summary>
        /// <returns>Lista con opciones</returns>
        private List<CombinationOrderEL> GetListParameter()
        {
            var listResult = policyDomain.CombinationOrderSearch(new CombinationOrderRequest()
            {
                BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result;

            return listResult;
        }

        /// <summary>
        /// Adaptador de lista de opciones a lista de combos
        /// </summary>
        /// <param name="codeParameter">Código de Parámetro</param>
        /// <returns>Lista con opciones</returns>
        public List<SelectType> GetListParameterValue(int codeParameter)
        {
            List<SelectType> listSelect = new List<SelectType>();

            var listResult = policyDomain.ParameterValueSearch(new ParameterValueRequest()
            {
                BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                CodeParameter = codeParameter,
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
        public ReportModel Report(CombinationRequest filter)
        {
            var yanbalSession = SessionContext.GetYanbalSession();
            var reportingSessionWorkspacePathPolicy = yanbalSession != null ? yanbalSession.ReportingWorkspacePathPolicy : "";
            ReportModel reportModel = new ReportModel();            
            reportModel.PathReport = String.Format("{0}{1}", reportingSessionWorkspacePathPolicy, Enumerated.ReportFileName.PolicyCombination);
            reportModel.AddParameter("USUARIO", this.yanbalSession.User.Login);
            reportModel.AddParameter("AREA", "FLETES");
            reportModel.AddParameter("CODIGO_LENGUAJE", "");
            reportModel.AddParameter("NOMBRE_REPORTE", Resources.Freight.Combination.IndexResource.LabelTitleCombinationReport.ToUpper());
            reportModel.AddParameter("CODIGO_UNIDAD_NEGOCIO", this.yanbalSession.BusinessUnit.BusinessUnitCode.ToString());
            reportModel.AddParameter("ETIQUETA_SYSTEM", Resources.Shared.GeneralResource.LabelSystem);

            reportModel.AddParameter("CODIGO_PARAMETRO", filter.ParameterCode);
            reportModel.AddParameter("DESCRIPCION_PARAMETRO", filter.DescriptionParameterCode);
            reportModel.AddParameter("VALOR", (filter.ParameterValue != null) ? filter.ParameterValue.ToString() : null);
            reportModel.AddParameter("DESCRIPCION_PARAMETRO_VALOR", filter.DescriptionParameterValue);
            reportModel.AddParameter("ESTADO_REGISTRO", filter.RegistrationStatus ?? string.Empty);
            reportModel.AddParameter("DESCRIPCION_ESTADO_REGISTRO", filter.DescriptionRegistrationStatus ?? string.Empty);

            reportModel.AddParameter("FORMATO_FECHA_CORTA", this.yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionShortDateFormat);
            reportModel.AddParameter("FORMATO_FECHA_LARGA", this.yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionLongDateFormat);
            reportModel.AddParameter("FORMATO_HORA_CORTA", this.yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionShortTimeFormat);
            reportModel.AddParameter("FORMATO_HORA_LARGA", this.yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionLongTimeFormat);
            reportModel.AddParameter("FORMATO_NUMERO_ENTERO", this.yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionFormatIntegerNumber);
            reportModel.AddParameter("FORMATO_NUMERO_DECIMAL", this.yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionFormatDecimalNumber);

            reportModel.AddParameter("COLUMNA_CODIGO", Resources.Freight.Combination.IndexResource.ColumnCode ?? string.Empty);
            reportModel.AddParameter("COLUMNA_COMBINACION", Resources.Freight.Combination.IndexResource.ColumnCombination ?? string.Empty);
            reportModel.AddParameter("COLUMNA_IMPORTE", Resources.Freight.Combination.IndexResource.ColumnAmount ?? string.Empty);
            reportModel.AddParameter("COLUMNA_ESTADO_REGISTRO", Resources.Freight.Combination.IndexResource.ColumnRegistrationStatus ?? string.Empty);
            reportModel.AddParameter("COLUMNA_TODOS", Resources.Shared.GeneralResource.LabelSelectAll ?? string.Empty);

            reportModel.AddParameter("ETIQUETA_PARAMETRO", Resources.Freight.Combination.IndexResource.LabelParameter ?? string.Empty);
            reportModel.AddParameter("ETIQUETA_VALOR_PARAMETRO", Resources.Freight.Combination.IndexResource.LabelParameterValue ?? string.Empty);            
            reportModel.AddParameter("ETIQUETA_ESTADO_REGISTRO", Resources.Freight.Combination.IndexResource.LabelRegistrationStatus ?? string.Empty);
            reportModel.AddParameter("ETIQUETA_HORA", Resources.Freight.Combination.IndexResource.LabelHour ?? string.Empty);
            reportModel.AddParameter("ETIQUETA_FECHA", Resources.Freight.Combination.IndexResource.LabelDate ?? string.Empty);
            reportModel.AddParameter("COLUMNA_USUARIO", Resources.Shared.GeneralResource.LabelUser ?? string.Empty);
            reportModel.AddParameter("COLUMNA_AREA", Resources.Shared.GeneralResource.LabelArea ?? string.Empty);

            reportModel.AddParameter("ETIQUETA_PAGINA", Resources.Freight.Combination.IndexResource.LabelPage ?? string.Empty);
            reportModel.AddParameter("ETIQUETA_PAGINA_DE", Resources.Freight.Combination.IndexResource.LabelPageOf ?? string.Empty);
            reportModel.AddParameter("PIE_REPORTE", string.Format(Resources.Shared.GeneralResource.LabelReportEndOf, (Resources.Freight.Combination.IndexResource.LabelTitleCombinationReport.ToUpper())));
            return reportModel;
        }
        #endregion

    }
}
