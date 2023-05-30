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
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Source.Context.Freight.FormulaOrder
{
    /// <summary>
    /// Contexto de la vista de Orden de Formula
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140910 <br />
    /// Modificación: 
    /// </remarks>
    public class FormulaOrderContext
    {
        #region Properties
        //Inicio Sonar 15/08/2016
        readonly IPolicyDomain policyDomain;
        readonly YanbalSession yanbalSession;
        //Fin Sonar
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de implementación de la clase
        /// </summary>
        /// <param name="yanbalSession">Objeto mantenido en Sesión</param>
        public FormulaOrderContext(YanbalSession yanbalSession)
        {
            this.yanbalSession = yanbalSession;
            EnvironmentEL environment = BaseContext.EnvironmentAdapter(yanbalSession);
            policyDomain = new PolicyDomain(environment);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Permite generar el Modelo de la ventana de Orden de Formula
        /// </summary>
        /// <returns>Modelo a aplicar en la vista</returns>
        public FormulaOrderModel Index()
        {
            FormulaOrderModel formulaOrderModel = new FormulaOrderModel();
            string controllerName = "FormulaOrder";

            formulaOrderModel.Save = new ButtonControl();
            formulaOrderModel.Save.Id = "btnSave";
            BaseContext.GetAccessControl(formulaOrderModel.Save.Id, controllerName, formulaOrderModel.Save);
            
            formulaOrderModel.Edit = new ImageControl();
            formulaOrderModel.Edit.Id = "ibtEdit";
            BaseContext.GetAccessControl(formulaOrderModel.Edit.Id, controllerName, formulaOrderModel.Edit);

            formulaOrderModel.ListFormula = GetListFormula();
            formulaOrderModel.ListRegistrationStatus = yanbalSession.ListRegistrationStatus;

            return formulaOrderModel;
        }

        /// <summary>
        /// Permite realizar la búsqueda de Orden de Formula
        /// </summary>
        /// <param name="formulaRequest">Formula</param>
        /// <returns>Lista de resultado de Formula</returns>
        public List<FormulaEL> Search(FormulaRequest formulaRequest)
        {
            List<FormulaEL> resultFormulaOrder = new List<FormulaEL>();
            if (yanbalSession.ListRegistrationStatus != null && yanbalSession.ListRegistrationStatus.Count > 0)
            {
                formulaRequest.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
                formulaRequest.RegistrationStatus = Enumerated.RegistrationStatus.Active;
                resultFormulaOrder = policyDomain.FormulaSearch(formulaRequest).Result.Where(item => item.Order != null && item.Order >= 1).OrderBy(item => item.Order).ToList();
            }
            return resultFormulaOrder;
        }

        /// <summary>
        /// Permite generar el Modelo de la ventana para modificar Orden de Formula
        /// </summary>
        /// <param name="formulaCode">Código de Formula</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public FormulaOrderModel Edit(int formulaCode)
        {
            FormulaOrderModel formulaOrderModel = new FormulaOrderModel();
            string controllerName = "FormulaOrder";

            FormulaEL formulaOrderEl = policyDomain.FormulaSearch(new FormulaRequest() { BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode, FormulaCode = formulaCode }).Result.FirstOrDefault();

            formulaOrderModel.Save = new ButtonControl();
            formulaOrderModel.Save.Id = "btnSaveEdit";
            BaseContext.GetAccessControl(formulaOrderModel.Save.Id, controllerName, formulaOrderModel.Save);

            formulaOrderModel.Cancel = new ButtonControl();
            formulaOrderModel.Cancel.Id = "btnCancelEdit";
            BaseContext.GetAccessControl(formulaOrderModel.Cancel.Id, controllerName, formulaOrderModel.Cancel);

            if (formulaOrderEl != null)
            {
                formulaOrderModel.FormulaCode = formulaOrderEl.FormulaCode;
                formulaOrderModel.FormulaDescription = GenerateFormulaDescription(formulaOrderEl);
                formulaOrderModel.Order = formulaOrderEl.Order;
                formulaOrderModel.RegistrationStatus = formulaOrderEl.RegistrationStatus;
            }
            return formulaOrderModel;
        }

        /// <summary>
        /// Permite el registro de Orden de Formula
        /// </summary>
        /// <param name="register">Orden de Formula</param>
        /// <returns>Indicador de Conformidad</returns>
        public string RegisterFormulaOrder(FormulaRequest register)
        {
            register.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
            register.UserModification = yanbalSession.User.Login;
            register.TerminalModification = yanbalSession.User.Ip;
            var result = policyDomain.FormulaOrderRegister(register).Result;
            return result;
        } 

        /// <summary>
        /// Permite la modificación de Orden de Formula
        /// </summary>
        /// <param name="register">Orden de Formula</param>
        /// <returns>Indicador de Conformidad</returns>
        public string ModifyFormulaOrder(FormulaRequest register)
        {
            register.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
            register.UserModification = yanbalSession.User.Login;
            register.TerminalModification = yanbalSession.User.Ip;
            var result = policyDomain.FormulaOrderUpdate(register).Result;
            return result;
        } 
        #endregion

        #region Adapters
        /// <summary>
        /// Obtiene la lista de Formulas para mostrar en Combos
        /// </summary>
        /// <returns>Lista de Combos</returns>
        private List<SelectType> GetListFormula()
        {
            List<SelectType> listSelect = new List<SelectType>();

            var listResult = policyDomain.FormulaSearch(new FormulaRequest()
            {
                BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result;

            foreach (var item in listResult)
            {
                listSelect.Add(new SelectType() { Id = Convert.ToString(item.FormulaCode), Name = GenerateFormulaDescription(item) });
            }
            return listSelect;
        }

        /// <summary>
        /// Genera la Descripción de la Formula
        /// </summary>
        /// <param name="formula">Entidad Logica de Formula</param>
        /// <returns>Descripción de formula</returns>
        private string GenerateFormulaDescription(FormulaEL formula)
        {
            return formula.ParameterDescription + " - " + formula.ValueDescription + " (" + formula.Operation + ")";
        }
        #endregion

    }
}
