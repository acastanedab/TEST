using System;
using System.Collections.Generic;
using System.Linq;
using Yanbal.SFT.Domain.Entities.Logic.Common;
using Yanbal.SFT.Domain.Entities.Logic.Freight;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.FreightManagement.Common.Custom;
using Yanbal.SFT.FreightManagement.Common.Response;
using Yanbal.SFT.FreightManager.Domain;
using Yanbal.SFT.FreightManager.Domain.Wrappers;
using Yanbal.SFT.PolicyManager.Domain;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Context.Common;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;
using Yanbal.SFT.Presentation.Web.Source.Models.Freight;
using Yanbal.SFT.Presentation.Web.Source.Session;

namespace Yanbal.SFT.Presentation.Web.Source.Context.Freight.Combination
{
    /// <summary>
    /// Contexto de la vista de Simulación
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140910 <br />
    /// Modificación: 
    /// </remarks>
    public class SimulatorContext
    {
        #region Properties

        readonly IPolicyDomain policyDomain;
        readonly IFreightDomain freightDomain;
        readonly YanbalSession yanbalSession;
        readonly EnvironmentEL environment;
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de la Clase basado en Sesion
        /// </summary>
        /// <param name="yanbalSession">Objeto de Sesion</param>
        public SimulatorContext(YanbalSession yanbalSession)
        {
            this.yanbalSession = yanbalSession;
            environment = BaseContext.EnvironmentAdapter(yanbalSession);
            this.freightDomain = new FreightDomain();
            this.policyDomain = new PolicyDomain();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Permite generar el Modelo de la ventana de Simulador
        /// </summary>
        /// <returns>Modelo a aplicar en la vista</returns>
        public SimulatorModel Index()
        {
            SimulatorModel simulatorModel = new SimulatorModel();
            string controllerName = "Simulator";

            simulatorModel.Simulator = new ButtonControl();
            simulatorModel.Simulator.Id = "btnSimulate";

            simulatorModel.CodeCountry = yanbalSession.BusinessUnit.CountryCode;
            simulatorModel.CodeCountryGeo = yanbalSession.BusinessUnit.CountryZoneCode;

            simulatorModel.ListSendType = GetListSendType();
            simulatorModel.ListTypeOrder = GetListTypeOrder();

            var geoLevel = policyDomain.ParameterValueSearch(new ParameterValueRequest()
            {
                BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                Code = Convert.ToString(Enumerated.Parameter.LevelGeoZone),
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result;

            if (geoLevel.Count == 3)
            {
                simulatorModel.LabelGeoLevel1 = geoLevel[0].RecordValueString["2"];
                simulatorModel.LabelGeoLevel2 = geoLevel[1].RecordValueString["2"];
                simulatorModel.LabelGeoLevel3 = geoLevel[2].RecordValueString["2"];
                simulatorModel.ListZoneLevel1 = GetListProvince();
            }
            BaseContext.GetAccessControl(simulatorModel.Simulator.Id, controllerName, simulatorModel.Simulator);

            return simulatorModel;
        }

        /// <summary>
        /// Permite mostrar la vista del Modelo
        /// </summary>
        /// <param name="request">Paraámetro de entrada</param>
        /// <returns>Modelo a aplicar en la vista</returns>
        public SimulatorModel Simulate(FreightRequest request)
        {
            SimulatorModel simulatorModel = new SimulatorModel();
            string[] amountPart = request.AmountString.Split('.');

            long partInt = Convert.ToInt64(amountPart[0]);

            long partDecimal = 0;

            decimal amountDecimal = 0;
            if (amountPart.Count() == 2)
            {
                partDecimal = Convert.ToInt64(amountPart[1]);

                amountDecimal = partInt + (partDecimal / (decimal)Math.Pow((double)10, (double)amountPart[1].Count()));
            }
            else
            {
                amountDecimal = partInt;
            }
            request.Amount = amountDecimal;

            List<FreightRequest> lstSendType = new List<FreightRequest>();
            IPolicyDomain _policyDomain = new PolicyDomain();
            var unidadNegocio = _policyDomain.BusinessUnitSearch(new BusinessUnitRequest() { CountryCode = request.Country, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result.FirstOrDefault();
            ParameterValueRequest entidad = new ParameterValueRequest()
            {
                BusinessUnitCode = unidadNegocio.BusinessUnitCode,
                Code = Enumerated.Parameter.SendType,
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            };
            var listResult = policyDomain.ParameterValueSearch(entidad);
            if (listResult.Result.Any())
            {
                foreach (var item in listResult.Result.Select(itemResult => itemResult.RecordValueString))
                {
                    lstSendType.Add(new FreightRequest() { SendType = item["1"], SendTypeDescripcion = item["2"] });
                }
            }
            if (!string.IsNullOrWhiteSpace(request.SendType))
            {
                lstSendType = lstSendType.Where(x => x.SendType == request.SendType).ToList();
            }
            List<OrderResponseType> dataList = new List<OrderResponseType>();
            ProcessResult<FreightEL> restultFreight = new ProcessResult<FreightEL>();

            if (lstSendType != null && lstSendType.Any())
            {
                foreach (var item in lstSendType)
                {
                    request.SendType = item.SendType;
                    restultFreight = freightDomain.CalculateFreight(request);
                    if (restultFreight.Result != null && restultFreight.IsSuccess)
                    {
                        string combinationDescription = policyDomain.CombinationSearch(new CombinationRequest()
                        {
                            BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                            CombinationCode = restultFreight.Result.CombinationCode,
                            GetParametersCombination = true,
                            RegistrationStatus = Enumerated.RegistrationStatus.Active
                        }).Result.FirstOrDefault().Description;

                        dataList.Add(new OrderResponseType()
                        {
                            valueFreight = (restultFreight.Result != null && restultFreight.IsSuccess) ? (Utility.DecimalFormatString(restultFreight.Result.AmountFreight, environment.DecimalFormat, environment.InformationDecimalFormat)) : "",
                            sendType = item.SendType,
                            SendTypeDescripcion = item.SendTypeDescripcion,
                            combinationDescription = combinationDescription
                        });
                    }
                }
                simulatorModel.OrderResponseList = dataList;
                simulatorModel.CodeError = (!restultFreight.IsSuccess) ? restultFreight.Exception.CodeError : Enumerated.ErrorCodeBase.Successful;
                simulatorModel.DescriptionError = (!restultFreight.IsSuccess) ? restultFreight.Exception.DescriptionError : Enumerated.ErrorDescriptionBase.Successful;                                
            }
            return simulatorModel;
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
        /// Adaptador de lista de Tipos de Pedido
        /// </summary>
        /// <returns>Lista con opciones</returns>
        private List<SelectType> GetListTypeOrder()
        {
            List<SelectType> listSelect = new List<SelectType>();

            var listResult = policyDomain.ParameterValueSearch(new ParameterValueRequest()
            {
                BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                Code = Enumerated.Parameter.TypeOrder,
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result;

            foreach (var item in listResult.Select(itemResult => itemResult.RecordValueString))
            {
                listSelect.Add(new SelectType() { Id = item["1"], Name = item["2"] });
            }
            return listSelect;
        }

        /// <summary>
        /// Adaptador de lista de Tipos de Envio
        /// </summary>
        /// <returns>Lista con opciones</returns>
        private List<SelectType> GetListSendType()
        {
            List<SelectType> listSelect = new List<SelectType>();

            var listResult = policyDomain.ParameterValueSearch(new ParameterValueRequest()
            {
                BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                Code = Enumerated.Parameter.SendType,
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
