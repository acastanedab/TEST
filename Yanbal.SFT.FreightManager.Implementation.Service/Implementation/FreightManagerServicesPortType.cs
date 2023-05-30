using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.FreightManagement.Common.Custom;
using Yanbal.SFT.FreightManager.Domain;
using Yanbal.SFT.FreightManager.Domain.Wrappers;
using Yanbal.SFT.Infrastructure.CrossCutting.Log;
using Yanbal.SFT.Infrastructure.CrossCutting.Log4Net;
using Yanbal.SFT.PolicyManager.Domain;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using static Yanbal.SFT.Infrastructure.CrossCutting.Log.Logging;

namespace Yanbal.SFT.FreightManager.Implementation.Service
{

    /// <summary>
    /// Freight Manager Services PortType
    /// </summary>
    [System.ServiceModel.ServiceBehaviorAttribute(InstanceContextMode = System.ServiceModel.InstanceContextMode.PerCall, ConcurrencyMode = System.ServiceModel.ConcurrencyMode.Single)]
    public class FreightManagerServicesPortType : IFreightManagerServicesPortType
    {
        private ILogging ilog4Net;
        /// <summary>
        /// calculate Freight Order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual calculateFreightOrderResponse calculateFreightOrder(calculateFreightOrderRequest request)
        {
            calculateFreightOrderResponse response = new calculateFreightOrderResponse();
            string errorCode = Enumerated.ErrorCodeBase.UnExpectedError;
            string errorDescription = Enumerated.ErrorDescriptionBase.UnExpectedError;

            StackTrace tracenom = new StackTrace();
            String codigoPais = request != null && !string.IsNullOrWhiteSpace(request.FreightOrderRequest.Header.codigoPais) ? request.FreightOrderRequest.Header.codigoPais : ConfigurationManager.AppSettings["BusinessUnity"];
            string IdTransaccion = Guid.NewGuid().ToString();
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, codigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(FreightManagerServicesPortType).FullName);

            ilog4Net = new Logging(ConfigLog4Net.GetConfigByComponent(new ParameterValueRequest()
            {
                Component = Enumerated.Componente.srvSFTFreight,
                CountryCode = codigoPais
            }));
            try
            {
                XCData cdataRequest = new XCData(Utility.ToXML(request));
                traceOrder.TramaRequest = Utility.XmlUnescape(cdataRequest.ToString());
                ilog4Net.AddLog4Net("Request SFT SOAP srvSFTFreight-calculateFreightOrder", traceOrder, LogLevel.DEBUG.ToString());
                ilog4Net.AddLog4Net("Inició el Servicio srvSFTFreight-calculateFreightOrder", traceOrder, LogLevel.INFO.ToString());

                response.FreightResponse = new FreightResponseType();
                response.FreightResponse.OrderResponse = new OrderResponseType();
                response.FreightResponse.OrderResponse.countryCode = request.FreightOrderRequest.OrderRequest.countryCode;
                response.FreightResponse.OrderResponse.identifyOrder = request.FreightOrderRequest.OrderRequest.identifyOrder;

                List<CollectorParameterRequest> collectorParameter = new List<CollectorParameterRequest>();
                foreach (var parameter in request.FreightOrderRequest.OrderRequest.collectorParameterList)
                {
                    collectorParameter.Add(new CollectorParameterRequest() { Id = parameter.id, Value = parameter.value });
                }

                IFreightDomain freightDomain = new FreightDomain();
                var resultCalculateFreight = freightDomain.CalculateFreight(new FreightRequest()
                {
                    Amount = request.FreightOrderRequest.OrderRequest.valueTotalOrder,
                    Country = request.FreightOrderRequest.OrderRequest.countryCode,
                    Zone = request.FreightOrderRequest.OrderRequest.zoneId,
                    TypeOrder = request.FreightOrderRequest.OrderRequest.orderType,
                    YearCampaign = Convert.ToString(request.FreightOrderRequest.OrderRequest.campaignYear),
                    NumberCampaign = Convert.ToString(request.FreightOrderRequest.OrderRequest.campaignNumber),
                    NumberWeek = Convert.ToString(request.FreightOrderRequest.OrderRequest.weekNumber),
                    SendType = request.FreightOrderRequest.OrderRequest.sendType,
                    CollectorParameter = collectorParameter, 
                    IsForService = true,
                });
                if (resultCalculateFreight.IsSuccess)
                {
                    response.FreightResponse.OrderResponse.valueFreight = resultCalculateFreight.Result.AmountFreight;
                    response.FreightResponse.OrderResponse.valueFreightSpecified = true;
                    errorCode = Enumerated.ErrorCodeBase.Successful;
                    errorDescription = Enumerated.ErrorDescriptionBase.Successful;
                }
                else
                {
                    errorCode = resultCalculateFreight.Exception.CodeError;
                    errorDescription = resultCalculateFreight.Exception.DescriptionError;
                }
            }
            catch (Exception ex)
            {
                errorCode = Enumerated.ErrorCodeBase.UnExpectedError;
                errorDescription = Enumerated.ErrorDescriptionBase.UnExpectedError;
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            finally
            {
                response.FreightResponse.OrderResponse.errorCode = errorCode;
                response.FreightResponse.OrderResponse.errorDescription = errorDescription;

                IPolicyDomain policyDomain = new PolicyDomain();
                DateTime dateNow = policyDomain.GetDateTimeBusinessUnit(null, request.FreightOrderRequest.OrderRequest.countryCode, false);

                response.FreightResponse.responseDate = Utility.DatetimeFormatString(dateNow, Enumerated.FormatDate.ResponseService);
                response.FreightResponse.OrderResponse.responseDate = response.FreightResponse.responseDate;

                if (response.FreightResponse.OrderResponse.errorCode != Enumerated.ErrorCodeBase.Successful)
                {
                    Logging logging = new Logging();
                    logging.Add("calculateTaxOrder", TraceEventType.Error, response.FreightResponse.OrderResponse.errorCode + "(" + response.FreightResponse.OrderResponse.identifyOrder + "): " + response.FreightResponse.OrderResponse.errorDescription);
                    
                }
                ilog4Net.AddLog4Net($"Finalizó el Servicio srvSFTFreight-calculateFreightOrder - errorCode: {response.FreightResponse.OrderResponse.errorCode} - errorDescription : { response.FreightResponse.OrderResponse.errorDescription}", traceOrder, LogLevel.INFO.ToString());
            }

            XCData cdataResponse = new XCData(Utility.ToXML(response));
            traceOrder.TramaResponse = Utility.XmlUnescape(cdataResponse.ToString());
            ilog4Net.AddLog4Net("Response SFT SOAP srvSFTFreight-calculateFreightOrder", traceOrder, LogLevel.DEBUG.ToString());

            return response;
        }

        /// <summary>
        /// calculate Freight Order List 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual calculateFreightOrderResponse calculateFreightOrderList(calculateFreightOrderRequestList request)
        {

            calculateFreightOrderResponse response = new calculateFreightOrderResponse();

            string errorCode = Enumerated.ErrorCodeBase.UnExpectedError;
            string errorDescription = Enumerated.ErrorDescriptionBase.UnExpectedError;
            StackTrace tracenom = new StackTrace();
            string IdTransaccion = Guid.NewGuid().ToString();
            string codigoPais = request != null && !string.IsNullOrWhiteSpace(request.FreightOrderRequestList.Header.codigoPais) ? request.FreightOrderRequestList.Header.codigoPais : ConfigurationManager.AppSettings["BusinessUnity"];
            Traza traceOrder = TraceFactory.Create(IdTransaccion, string.Empty, codigoPais, tracenom.GetFrame(0).GetMethod().Name, typeof(FreightManagerServicesPortType).FullName);
            ilog4Net = new Logging(ConfigLog4Net.GetConfigByComponent(new ParameterValueRequest()
            {
                Component = Enumerated.Componente.srvSFTFreight,
                CountryCode = codigoPais
            }));
            try
            {
                XCData cdataRequest = new XCData(Utility.ToXML(request));
                traceOrder.TramaRequest = Utility.XmlUnescape(cdataRequest.ToString());
                ilog4Net.AddLog4Net("Request SFT SOAP srvSFTFreight-calculateFreightOrderList", traceOrder, LogLevel.DEBUG.ToString());
                ilog4Net.AddLog4Net("Inició el Servicio srvSFTFreight-calculateFreightOrderList", traceOrder, LogLevel.INFO.ToString());

                List<OrderResponseType> dataList = new List<OrderResponseType>();
                response.FreightResponse = new FreightResponseType();
                response.FreightResponse.OrderResponseList = new List<OrderResponseType>();
                response.FreightResponse.OrderResponse = new OrderResponseType();

                response.FreightResponse.OrderResponse.countryCode = request.FreightOrderRequestList.OrderRequest.countryCode;
                response.FreightResponse.OrderResponse.identifyOrder = request.FreightOrderRequestList.OrderRequest.identifyOrder;

                List<CollectorParameterRequest> collectorParameter = new List<CollectorParameterRequest>();
                foreach (var parameter in request.FreightOrderRequestList.OrderRequest.collectorParameterList)
                {
                    collectorParameter.Add(new CollectorParameterRequest() { Id = parameter.id, Value = parameter.value });
                }
                List<OrderRequestType> lstSendType = new List<OrderRequestType>();
                IPolicyDomain policyDomain = new PolicyDomain();
                var unidadNegocio = policyDomain.BusinessUnitSearch(new BusinessUnitRequest() { CountryCode = request.FreightOrderRequestList.OrderRequest.countryCode, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result.FirstOrDefault();
                ParameterValueRequest entidad = new ParameterValueRequest()
                {
                    BusinessUnitCode = unidadNegocio.BusinessUnitCode,
                    Code = Enumerated.Parameter.SendType,
                    RegistrationStatus = Enumerated.RegistrationStatus.Active
                };
                var listResult = policyDomain.ParameterValueSearch(entidad);

                if (listResult.Result.Any())
                {
                    if (request.FreightOrderRequestList.OrderRequest.sendTypeList.Any())
                    {
                        foreach (var item in listResult.Result.Select(itemResult => itemResult.RecordValueString))
                        {
                            var enSendType = request.FreightOrderRequestList.OrderRequest.sendTypeList.Where(x => x == item["1"]).AsEnumerable().FirstOrDefault();
                            if (enSendType != null)
                            {
                                lstSendType.Add(new OrderRequestType() { sendType = item["1"] });
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in listResult.Result.Select(itemResult => itemResult.RecordValueString))
                        {
                            lstSendType.Add(new OrderRequestType() { sendType = item["1"] });
                        }
                    }

                    if (lstSendType != null && lstSendType.Any())
                    {
                        foreach (var item in lstSendType.Distinct())
                        {
                            IFreightDomain freightDomain = new FreightDomain();
                            FreightRequest freightRequest = new FreightRequest()
                            {
                                Amount = request.FreightOrderRequestList.OrderRequest.valueTotalOrder,
                                Country = request.FreightOrderRequestList.OrderRequest.countryCode,
                                Zone = request.FreightOrderRequestList.OrderRequest.zoneId,
                                TypeOrder = request.FreightOrderRequestList.OrderRequest.orderType,
                                YearCampaign = Convert.ToString(request.FreightOrderRequestList.OrderRequest.campaignYear),
                                NumberCampaign = Convert.ToString(request.FreightOrderRequestList.OrderRequest.campaignNumber),
                                NumberWeek = Convert.ToString(request.FreightOrderRequestList.OrderRequest.weekNumber),
                                SendType = item.sendType,
                                CollectorParameter = collectorParameter,
                                IsForService = true,
                            };

                            var resultCalculateFreight = freightDomain.CalculateFreight(freightRequest);
                            if (resultCalculateFreight.IsSuccess)
                            {
                                dataList.Add(new OrderResponseType() { valueFreight = resultCalculateFreight.Result.AmountFreight, valueFreightSpecified = true, sendType = item.sendType });
                            }
                        }
                        response.FreightResponse.OrderResponseList.AddRange(dataList);
                        errorCode = Enumerated.ErrorCodeBase.Successful;
                        errorDescription = Enumerated.ErrorDescriptionBase.Successful;
                    }
                }
                else
                {
                    errorCode = Enumerated.ErrorCodeBase.UnExpectedError;
                    errorDescription = Enumerated.ErrorDescriptionBase.UnExpectedError;
                }
            }
            catch (Exception ex)
            {
                errorCode = Enumerated.ErrorCodeBase.UnExpectedError;
                errorDescription = Enumerated.ErrorDescriptionBase.UnExpectedError;
                var mensajeErrorLog = $"{ex.Message} - stackTrace {ex.StackTrace} - innerException {ex.InnerException} ";
                ilog4Net.AddLog4Net(mensajeErrorLog, traceOrder, LogLevel.ERROR.ToString());
            }
            finally
            {
                response.FreightResponse.OrderResponse.errorCode = errorCode;
                response.FreightResponse.OrderResponse.errorDescription = errorDescription;
                IPolicyDomain policyDomain = new PolicyDomain();
                DateTime dateNow = policyDomain.GetDateTimeBusinessUnit(null, request.FreightOrderRequestList.OrderRequest.countryCode, false);
                response.FreightResponse.responseDate = Utility.DatetimeFormatString(dateNow, Enumerated.FormatDate.ResponseService);
                response.FreightResponse.OrderResponse.responseDate = response.FreightResponse.responseDate;
                if (response.FreightResponse.OrderResponse.errorCode != Enumerated.ErrorCodeBase.Successful)
                {
                    Logging logging = new Logging();
                    logging.Add("calculateTaxOrder", TraceEventType.Error, response.FreightResponse.OrderResponse.errorCode + "(" + response.FreightResponse.OrderResponse.identifyOrder + "): " + response.FreightResponse.OrderResponse.errorDescription);
                }
                ilog4Net.AddLog4Net($"Finalizó el Servicio srvSFTFreight-calculateFreightOrderList - errorCode: {response.FreightResponse.OrderResponse.errorCode} - errorDescription : { response.FreightResponse.OrderResponse.errorDescription}", traceOrder, LogLevel.INFO.ToString());
            }

            XCData cdataResponse = new XCData(Utility.ToXML(response));
            traceOrder.TramaResponse = Utility.XmlUnescape(cdataResponse.ToString());
            ilog4Net.AddLog4Net("Response SFT SOAP srvSFTFreight-calculateFreightOrderList", traceOrder, LogLevel.DEBUG.ToString());

            return response;
        }
    }
}