using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.Domain.Entities.Logic.Common;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.PolicyManager.Domain;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Context.Common;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;
using Yanbal.SFT.Presentation.Web.Source.Models.Freight;
using Yanbal.SFT.Presentation.Web.Source.Models.Policy;
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Source.Context.Freight.Formula
{
    /// <summary>
    /// Contexto de la vista de Fórmula
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140911 <br />
    /// Modificación:          <br />
    /// </remarks>
    public class FormulaContext
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
        public FormulaContext(YanbalSession yanbalSession)
        {
            this.yanbalSession = yanbalSession;
            environment = BaseContext.EnvironmentAdapter(yanbalSession);
            this.policyDomain = new PolicyDomain(environment);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Permite generar el Modelo de la ventana de Fórmula
        /// </summary>
        /// <returns>Modelo a aplicar en la vista</returns>
        public FormulaModel Index()
        {
            FormulaModel formulaModel = new FormulaModel();
            string controllerName = "Formula";

            formulaModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;

            formulaModel.Search = new ButtonControl();
            formulaModel.Search.Id = "btnSearch";
            BaseContext.GetAccessControl(formulaModel.Search.Id, controllerName, formulaModel.Search);

            formulaModel.Create = new ButtonControl();
            formulaModel.Create.Id = "btnCreate";
            BaseContext.GetAccessControl(formulaModel.Create.Id, controllerName, formulaModel.Create);

            formulaModel.Edit = new ImageControl();
            formulaModel.Edit.Id = "ibtEdit";
            BaseContext.GetAccessControl(formulaModel.Edit.Id, controllerName, formulaModel.Edit);

            formulaModel.ListParameter = GetListParameter();
            return formulaModel;
        }

        /// <summary>
        /// Permite realizar la búsqueda de Fórmula
        /// </summary>
        /// <param name="formulaRequest">Filtro de Fórmula</param>
        /// <returns>Lista de resultado de Fórmula</returns>
        public List<FormulaEL> Search(FormulaRequest formulaRequest)
        {
            List<FormulaEL> resultFormula = new List<FormulaEL>();
            if (yanbalSession.ListRegistrationStatus != null && yanbalSession.ListRegistrationStatus.Count > 0)
            {
                formulaRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                resultFormula = policyDomain.FormulaSearch(formulaRequest).Result;
            }
            return resultFormula;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para registrar Fórmula
        /// </summary>
        /// <returns>Modelo a aplicar en la vista</returns>
        public FormulaModel Create()
        {
            FormulaModel formulaModel = new FormulaModel();
            string controllerName = "Formula";

            formulaModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;
            formulaModel.LabelRegistrationStatus = ((formulaModel.ListRegistrationStatus.Count <= 0) ? "" : formulaModel.ListRegistrationStatus.OrderByDescending(item => item.Id).FirstOrDefault().Name.ToString());

            formulaModel.Save = new ButtonControl();
            formulaModel.Save.Id = "btnSaveCreate";
            BaseContext.GetAccessControl(formulaModel.Save.Id, controllerName, formulaModel.Save);

            formulaModel.Cancel = new ButtonControl();
            formulaModel.Cancel.Id = "btnCancelCreate";
            BaseContext.GetAccessControl(formulaModel.Cancel.Id, controllerName, formulaModel.Cancel);

            //var valuesSendType = policyDomain.ParameterValueSearch(new ParameterValueRequest()
            //{
            //    BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
            //    Code = Enumerated.Parameter.AmountRange,
            //    RegistrationStatus = Enumerated.RegistrationStatus.Active
            //}).Result;

            var valuesSendType = policyDomain.ParameterValueSearch(new ParameterValueRequest()
            {
                BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                Code = Enumerated.Parameter.SendType,
                CodeSection = 1,
                //Value = freightRequest.TypeOrder,
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result.FirstOrDefault();

            formulaModel.ListSendType = GetListParameterValue(valuesSendType.CodeParameter);
            formulaModel.ListParameter = GetListParameter();

            return formulaModel;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para modificar Fórmula
        /// </summary>
        /// <param name="formulaCode">Código de Formula</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public FormulaModel Edit(int formulaCode)
        {
            FormulaModel formulaModel = new FormulaModel();
            string controllerName = "Formula";

            formulaModel.Save = new ButtonControl();
            formulaModel.Save.Id = "btnSaveEdit";
            BaseContext.GetAccessControl(formulaModel.Save.Id, controllerName, formulaModel.Save);

            formulaModel.Cancel = new ButtonControl();
            formulaModel.Cancel.Id = "btnCancelEdit";
            BaseContext.GetAccessControl(formulaModel.Cancel.Id, controllerName, formulaModel.Cancel);

            FormulaEL formulaEl = policyDomain.FormulaSearch(new FormulaRequest() { BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode, FormulaCode = formulaCode }).Result.FirstOrDefault();

            var valuesSendType = policyDomain.ParameterValueSearch(new ParameterValueRequest()
            {
                BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                Code = Enumerated.Parameter.SendType,
                CodeSection = 1,
                //Value = freightRequest.TypeOrder,
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result.FirstOrDefault();

            formulaModel.ListSendType = GetListParameterValue(valuesSendType.CodeParameter);
            formulaModel.ListParameter = GetListParameter();
            formulaModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;

            if (formulaEl != null)
            {
                formulaModel.ValueSendType = formulaEl.ValueSendType;
                formulaModel.FormulaCode = formulaEl.FormulaCode;
                formulaModel.ParameterCode = formulaEl.ParameterCode;
                formulaModel.Value = formulaEl.Value;
                formulaModel.Operation = formulaEl.Operation;
                formulaModel.FactorString = formulaEl.FactorString;
                formulaModel.FactorType = formulaEl.FactorType;
                formulaModel.ListParameterValue = GetListParameterValue(formulaEl.ParameterCode);
                formulaModel.RegistrationStatus = formulaEl.RegistrationStatus;
            }

            return formulaModel;
        }

        /// <summary>
        /// Permite el registro de Fórmula
        /// </summary>
        /// <param name="formulaRequest">Fórmula</param>
        /// <returns>Indicador de Conformidad</returns>
        public string RegisterFormula(FormulaRequest formulaRequest)
        {
            formulaRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
            formulaRequest.UserCreation = yanbalSession.User.Login;
            formulaRequest.TerminalCreation = yanbalSession.User.Ip;
            var result = policyDomain.FormulaRegister(formulaRequest).Result;
            return result;
        }

        /// <summary>
        /// Permite la modificación de Fórmula
        /// </summary>
        /// <param name="formulaRequest">Fórmula</param>
        /// <returns>Indicador de Conformidad</returns>
        public string ModifyFormula(FormulaRequest formulaRequest)
        {
            formulaRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
            formulaRequest.UserModification = yanbalSession.User.Login;
            formulaRequest.TerminalModification = yanbalSession.User.Ip;
            var result = policyDomain.FormulaUpdate(formulaRequest).Result;
            return result;
        }
        #endregion

        #region Adapters
        /// <summary>
        /// Adaptador de lista de opciones a lista de combos
        /// </summary>
        /// <returns>Lista con opciones</returns>
        private List<SelectType> GetListParameter()
        {
            List<SelectType> listSelect = new List<SelectType>();
            var listResult = policyDomain.ParameterSearch(new ParameterRequest()
            {
                ParameterSystemIndicator = false,
                BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result;

            foreach (var item in listResult)
            {
                listSelect.Add(new SelectType() { Id = Convert.ToString(item.CodeParameter), Name = item.NameParameter });
            }
            return listSelect;
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
    }
}
