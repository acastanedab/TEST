using System;
using System.Collections.Generic;
using System.Linq;
using Yanbal.SFT.Domain.Entities.Logic.Freight;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.FreightManagement.Common.Custom;
using Yanbal.SFT.FreightManagement.Common.Response;
using Yanbal.SFT.FreightManager.Domain.Wrappers;
using Yanbal.SFT.Infrastructure.CrossCutting.Integracion;
using Yanbal.SFT.Infrastructure.CrossCutting.Repositories;
using Yanbal.SFT.PolicyManager.Domain;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;

namespace Yanbal.SFT.FreightManager.Domain
{
    /// <summary>
    /// Dominio que representa el Administrador de Fletes
    /// </summary>/// <remarks>
    /// Creación:       GMD 20140822 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class FreightDomain : IFreightDomain
    {   //Inicio Sonar 15/08/2016
        private readonly IDbContext dbContext;
        private readonly IPolicyDomain policyDomain;
        //Fin Sonar

        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public FreightDomain()
        {
            dbContext = new DataBaseContext();
            policyDomain = new PolicyDomain();
        }

        /// <summary>
        /// Permite realizar el Calculo del Flete
        /// </summary>
        /// <param name="freightRequest">Parámetros del Calculo del Flete</param>
        /// <returns>Respuesta del Proceso</returns>
        public ProcessResult<FreightEL> CalculateFreight(FreightRequest freightRequest)
        {
            int combinationCode = 0;
            decimal amountFreight = 0;
            ProcessResult<FreightEL> result = new ProcessResult<FreightEL>();
            try
            {
                if (string.IsNullOrEmpty(freightRequest.Country)
                 || string.IsNullOrEmpty(freightRequest.NumberCampaign)
                 || string.IsNullOrEmpty(freightRequest.NumberWeek)
                 || string.IsNullOrEmpty(freightRequest.YearCampaign)
                 || string.IsNullOrEmpty(freightRequest.SendType)
                 || string.IsNullOrEmpty(freightRequest.TypeOrder)
                 || string.IsNullOrEmpty(freightRequest.Zone))
                {
                    result.IsSuccess = false;
                    result.Exception = new CustomException(Enumerated.ErrorCodeBase.NoDataRequired, Enumerated.ErrorDescriptionBase.NoDataRequired);
                    return result;
                }
                int yearCampaign, numberWeek, numberCampaign;
                if (freightRequest.Amount < 0
                 || freightRequest.Country.Trim().Length != 2
                 || !int.TryParse(freightRequest.YearCampaign, out yearCampaign)
                 || yearCampaign <= 0
                 || !int.TryParse(freightRequest.NumberWeek, out numberWeek)
                 || numberWeek <= 0
                 || !int.TryParse(freightRequest.NumberCampaign, out numberCampaign)
                 || numberCampaign <= 0
                 || freightRequest.Zone.Trim().Length != 11
                 || (freightRequest.CollectorParameter != null && freightRequest.CollectorParameter.Any(item => item.Value == null || item.Value.Trim() == "" || item.Id == null || item.Id.Trim() == "")))
                {
                    result.IsSuccess = false;
                    result.Exception = new CustomException(Enumerated.ErrorCodeBase.DataInvalid, Enumerated.ErrorDescriptionBase.DataInvalid);
                    return result;
                }

                freightRequest.CollectorParameter = freightRequest.CollectorParameter ?? new List<CollectorParameterRequest>();

                var businessUnitCurrent = policyDomain.BusinessUnitSearch(new BusinessUnitRequest() { CountryCode = freightRequest.Country, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result.FirstOrDefault();

                if (businessUnitCurrent == null)
                {
                    result.IsSuccess = false;
                    result.Exception = new CustomException(Enumerated.ErrorCodeCombination.CombinationNonexistent, Enumerated.ErrorDescriptionCombination.CombinationNonexistent);
                    return result;
                }

                int businessUnitCode = businessUnitCurrent.BusinessUnitCode;

                var combinationOrder = policyDomain.CombinationOrderSearch(new CombinationOrderRequest()
                {
                    BusinessUnitCode = businessUnitCode,
                    RegistrationStatus = Enumerated.RegistrationStatus.Active
                }).Result.OrderBy(item => item.Order).ToList();

                if (combinationOrder == null || combinationOrder.Count == 0)
                {
                    result.IsSuccess = false;
                    result.Exception = new CustomException(Enumerated.ErrorCodeCombination.CombinationNonexistent, Enumerated.ErrorDescriptionCombination.CombinationNonexistent);
                    return result;
                }

                combinationOrder = combinationOrder.OrderBy(item => item.Order).ToList();

                var combinations = policyDomain.CombinationSearch(new CombinationRequest()
                {
                    BusinessUnitCode = businessUnitCode,
                    GetParametersCombination = true,
                    RegistrationStatus = Enumerated.RegistrationStatus.Active,
                    IsForService = freightRequest.IsForService,
                }).Result;

                if (combinations == null || combinations.Count == 0)
                {
                    result.IsSuccess = false;
                    result.Exception = new CustomException(Enumerated.ErrorCodeCombination.CombinationNonexistent, Enumerated.ErrorDescriptionCombination.CombinationNonexistent);
                    return result;
                }

                byte maxOrder = 0;

                var listParameterValue = new Dictionary<byte, Dictionary<string, List<string>>>();
                foreach (var itemOrder in combinationOrder)
                {
                    if (maxOrder + 1 == itemOrder.Order)
                    {
                        Dictionary<string, List<string>> parameter = new Dictionary<string, List<string>>();
                        List<string> codeParameterValue = new List<string>();
                        switch (itemOrder.Code)
                        {
                            case Enumerated.Parameter.AmountRange:
                                var valuesAmountRange = policyDomain.ParameterValueSearch(new ParameterValueRequest()
                                {
                                    BusinessUnitCode = businessUnitCode,
                                    Code = Enumerated.Parameter.AmountRange,
                                    RegistrationStatus = Enumerated.RegistrationStatus.Active
                                }).Result;

                                foreach (var value in valuesAmountRange)
                                {
                                    if ((decimal)value.RecordValueObject["3"] <= freightRequest.Amount && (value.RecordValueObject["4"] == null || (decimal)value.RecordValueObject["4"] > freightRequest.Amount))
                                    {
                                        codeParameterValue.Add(value.RecordValueObject["1"].ToString());
                                    }
                                }
                                if (codeParameterValue != null && codeParameterValue.Count > 0)
                                {
                                    parameter.Add(Enumerated.Parameter.AmountRange, codeParameterValue);
                                    listParameterValue.Add(itemOrder.Order, parameter);
                                    maxOrder++;
                                }
                                break;

                            case Enumerated.Parameter.ZoneType:
                                var freightUbication = policyDomain.UbicationSearch(freightRequest.Zone);
                                string codeCountry = freightUbication != null ? freightUbication.CodigoPais : string.Empty;
                                string codeLeve1 = freightUbication != null ? freightUbication.CodigoProvincia : string.Empty;
                                string codeLeve2 = freightUbication != null ? freightUbication.CodigoCiudad : string.Empty;
                                string codeLeve3 = freightUbication != null ? freightUbication.CodigoDistrito : string.Empty;

                                var valuesZoneType = policyDomain.UbigeoZoneTypeSearch(new UbigeoZoneTypeRequest() { BusinessUnitCode = businessUnitCode, CodeCountry = codeCountry, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result;

                                valuesZoneType = (from value in valuesZoneType
                                                  orderby value.CodeLevel1, value.CodeLevel2, value.CodeLevel3
                                                  select value).ToList();

                                var valuesZoneTypeEvaluation1 = new List<UbigeoZoneTypeEL>(valuesZoneType);
                                foreach (var value in valuesZoneTypeEvaluation1)
                                {
                                    if (!string.IsNullOrEmpty(value.CodeLevel1) && value.CodeLevel1 != codeLeve1)
                                    {
                                        valuesZoneType.Remove(value);
                                    }
                                }
                                valuesZoneTypeEvaluation1 = null;

                                var valuesZoneTypeEvaluation2 = new List<UbigeoZoneTypeEL>(valuesZoneType);
                                foreach (var value in valuesZoneTypeEvaluation2)
                                {
                                    if (!string.IsNullOrEmpty(value.CodeLevel2) && value.CodeLevel2 != codeLeve2)
                                    {
                                        valuesZoneType.Remove(value);
                                    }
                                }
                                valuesZoneTypeEvaluation2 = null;

                                var valuesZoneTypeEvaluation3 = new List<UbigeoZoneTypeEL>(valuesZoneType);
                                foreach (var value in valuesZoneTypeEvaluation3)
                                {
                                    if (!string.IsNullOrEmpty(value.CodeLevel3) && value.CodeLevel3 != codeLeve3)
                                    {
                                        valuesZoneType.Remove(value);
                                    }
                                }
                                valuesZoneTypeEvaluation3 = null;

                                if (valuesZoneType != null && valuesZoneType.Count > 0)
                                {
                                    string valueZone = valuesZoneType.OrderBy(item => item.CodeZone).LastOrDefault().CodeTypeZone;
                                    codeParameterValue.Add(valueZone);
                                    parameter.Add(Enumerated.Parameter.ZoneType, codeParameterValue);
                                    listParameterValue.Add(itemOrder.Order, parameter);
                                    maxOrder++;
                                }
                                break;

                            case Enumerated.Parameter.TypeOrder:
                                var valuesTypeOrder = policyDomain.ParameterValueSearch(new ParameterValueRequest()
                                {
                                    BusinessUnitCode = businessUnitCode,
                                    Code = Enumerated.Parameter.TypeOrder,
                                    CodeSection = 1,
                                    Value = freightRequest.TypeOrder,
                                    RegistrationStatus = Enumerated.RegistrationStatus.Active
                                }).Result.FirstOrDefault();

                                if (valuesTypeOrder != null)
                                {
                                    string valueTypeOrder = (string)valuesTypeOrder.RecordValueObject.Values.FirstOrDefault();
                                    codeParameterValue.Add(valueTypeOrder);
                                    parameter.Add(Enumerated.Parameter.TypeOrder, codeParameterValue);
                                    listParameterValue.Add(itemOrder.Order, parameter);
                                    maxOrder++;
                                }
                                break;

                            case Enumerated.Parameter.YearCampaign:
                                var valuesYearCampaign = policyDomain.ParameterValueSearch(new ParameterValueRequest()
                                {
                                    BusinessUnitCode = businessUnitCode,
                                    Code = Enumerated.Parameter.YearCampaign,
                                    CodeSection = 1,
                                    Value = freightRequest.YearCampaign,
                                    RegistrationStatus = Enumerated.RegistrationStatus.Active
                                }).Result.FirstOrDefault();

                                if (valuesYearCampaign != null)
                                {
                                    string valueYearCampaign = (string)valuesYearCampaign.RecordValueObject.Values.FirstOrDefault();
                                    codeParameterValue.Add(valueYearCampaign);
                                    parameter.Add(Enumerated.Parameter.YearCampaign, codeParameterValue);
                                    listParameterValue.Add(itemOrder.Order, parameter);
                                    maxOrder++;
                                }
                                break;

                            case Enumerated.Parameter.NumberCampaign:
                                var valuesNumberCampaign = policyDomain.ParameterValueSearch(new ParameterValueRequest()
                                {
                                    BusinessUnitCode = businessUnitCode,
                                    Code = Enumerated.Parameter.NumberCampaign,
                                    CodeSection = 1,
                                    Value = freightRequest.NumberCampaign,
                                    RegistrationStatus = Enumerated.RegistrationStatus.Active
                                }).Result.FirstOrDefault();

                                if (valuesNumberCampaign != null)
                                {
                                    string valueNumberCampaign = (string)valuesNumberCampaign.RecordValueObject.Values.FirstOrDefault();
                                    codeParameterValue.Add(valueNumberCampaign);
                                    parameter.Add(Enumerated.Parameter.NumberCampaign, codeParameterValue);
                                    listParameterValue.Add(itemOrder.Order, parameter);
                                    maxOrder++;
                                }
                                break;

                            case Enumerated.Parameter.NumberWeek:
                                var valuesNumberWeek = policyDomain.ParameterValueSearch(new ParameterValueRequest()
                                {
                                    BusinessUnitCode = businessUnitCode,
                                    Code = Enumerated.Parameter.NumberWeek,
                                    CodeSection = 1,
                                    Value = freightRequest.NumberWeek,
                                    RegistrationStatus = Enumerated.RegistrationStatus.Active
                                }).Result.FirstOrDefault();

                                if (valuesNumberWeek != null)
                                {
                                    string valueNumberWeek = (string)valuesNumberWeek.RecordValueObject.Values.FirstOrDefault();
                                    codeParameterValue.Add(valueNumberWeek);
                                    parameter.Add(Enumerated.Parameter.NumberWeek, codeParameterValue);
                                    listParameterValue.Add(itemOrder.Order, parameter);
                                    maxOrder++;
                                }
                                break;

                            case Enumerated.Parameter.SendType:
                                var valuesSendType = policyDomain.ParameterValueSearch(new ParameterValueRequest()
                                {
                                    BusinessUnitCode = businessUnitCode,
                                    Code = Enumerated.Parameter.SendType,
                                    CodeSection = 1,
                                    Value = freightRequest.SendType,
                                    RegistrationStatus = Enumerated.RegistrationStatus.Active
                                }).Result.FirstOrDefault();

                                if (valuesSendType != null)
                                {
                                    string valueSendType = (string)valuesSendType.RecordValueObject.Values.FirstOrDefault();
                                    codeParameterValue.Add(valueSendType);
                                    parameter.Add(Enumerated.Parameter.SendType, codeParameterValue);
                                    listParameterValue.Add(itemOrder.Order, parameter);
                                    maxOrder++;
                                }
                                break;

                            default:
                                var parameterDynamic = freightRequest.CollectorParameter.Where(item => item.Id == itemOrder.Code).FirstOrDefault();

                                if (parameterDynamic != null && !string.IsNullOrEmpty(parameterDynamic.Id))
                                {
                                    var valuesParameter = policyDomain.ParameterValueSearch(new ParameterValueRequest()
                                    {
                                        BusinessUnitCode = businessUnitCode,
                                        Code = parameterDynamic.Id,
                                        RegistrationStatus = Enumerated.RegistrationStatus.Active
                                    }).Result;

                                    if (valuesParameter.FirstOrDefault().CodeParameterType == Enumerated.ParameterType.SingleValue)
                                    {
                                        string valueParameter = (string)valuesParameter.Where(item => (string)item.RecordValueObject["1"] == parameterDynamic.Value).Select(item => item.RecordValueObject["1"]).FirstOrDefault();
                                        if (valueParameter != null)
                                        {
                                            codeParameterValue.Add(valueParameter);
                                            maxOrder++;
                                        }
                                    }
                                    else if (valuesParameter.FirstOrDefault().CodeParameterType == Enumerated.ParameterType.RangeValues)
                                    {
                                        var parameterSectionCurrent = policyDomain.ParameterSectionSearch(new ParameterSectionRequest()
                                        {
                                            CodeParameter = valuesParameter.FirstOrDefault().CodeParameter,
                                            BusinessUnitCode = businessUnitCode,
                                            RegistrationStatus = Enumerated.RegistrationStatus.Active
                                        }).Result;

                                        var sectionRangeBegin = parameterSectionCurrent.Where(itemWhere => itemWhere.RangeIndicator == Enumerated.RangeType.Begin).FirstOrDefault();
                                        var sectionRangeEnd = parameterSectionCurrent.Where(itemWhere => itemWhere.RangeIndicator == Enumerated.RangeType.End).FirstOrDefault();

                                        foreach (var value in valuesParameter)
                                        {
                                            int validationBegin = 0;
                                            int validationEnd = 0;
                                            switch (sectionRangeBegin.CodeParameterSectionType)
                                            {
                                                case Enumerated.SectionType.String:
                                                    validationBegin = String.Compare((string)parameterDynamic.Value,
                                                                                        (string)value.RecordValueObject[sectionRangeBegin.CodeSection.ToString()], false, System.Globalization.CultureInfo.InvariantCulture);

                                                    validationEnd = (value.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] != null)
                                                                    ? String.Compare((string)parameterDynamic.Value,
                                                                                        (string)value.RecordValueObject[sectionRangeEnd.CodeSection.ToString()], false, System.Globalization.CultureInfo.InvariantCulture) : -1;
                                                    break;

                                                case Enumerated.SectionType.Integer:
                                                    validationBegin = Convert.ToInt32(parameterDynamic.Value).CompareTo(
                                                                                        value.RecordValueObject[sectionRangeBegin.CodeSection.ToString()]);

                                                    validationEnd = (value.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] != null)
                                                                    ? Convert.ToInt32(parameterDynamic.Value).CompareTo(
                                                                                        value.RecordValueObject[sectionRangeEnd.CodeSection.ToString()]) : -1;
                                                    break;

                                                case Enumerated.SectionType.Decimal:
                                                    validationBegin = Convert.ToDecimal(parameterDynamic.Value).CompareTo(
                                                                                        value.RecordValueObject[sectionRangeBegin.CodeSection.ToString()]);

                                                    validationEnd = (value.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] != null)
                                                                    ? Convert.ToDecimal(parameterDynamic.Value).CompareTo(
                                                                                        value.RecordValueObject[sectionRangeEnd.CodeSection.ToString()]) : -1;
                                                    break;

                                                case Enumerated.SectionType.Date:
                                                    validationBegin = Convert.ToDateTime(parameterDynamic.Value).CompareTo(
                                                                                            value.RecordValueObject[sectionRangeBegin.CodeSection.ToString()]);

                                                    validationEnd = (value.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] != null)
                                                                    ? Convert.ToDateTime(parameterDynamic.Value).CompareTo(
                                                                                            value.RecordValueObject[sectionRangeEnd.CodeSection.ToString()]) : -1;
                                                    break;
                                            }
                                            if (validationBegin >= 0 && validationEnd < 0)
                                            {
                                                string valueParameter = value.RecordValueObject["1"].ToString();
                                                valueParameter = (valueParameter != null) ? valueParameter : "";
                                                codeParameterValue.Add(valueParameter);
                                                maxOrder++;
                                            }
                                        }
                                    }
                                    if (codeParameterValue != null && codeParameterValue.Count > 0)
                                    {
                                        parameter.Add(parameterDynamic.Id, codeParameterValue);
                                        listParameterValue.Add(itemOrder.Order, parameter);
                                    }
                                }
                                break;
                        }
                    }
                }

                combinations = combinations.Where(item => !item.ListParameterCombination.Any(itemAny => itemAny.CombinationOrder > (byte)listParameterValue.Count)).ToList();

                if (combinations == null || combinations.Count == 0)
                {
                    result.IsSuccess = false;
                    result.Exception = new CustomException(Enumerated.ErrorCodeCombination.CombinationNonexistent, Enumerated.ErrorDescriptionCombination.CombinationNonexistent);
                    return result;
                }

                List<CombinationEL> combinationAplicate = new List<CombinationEL>();

                foreach (var itemCombination in combinations)
                {
                    combinationAplicate.Add(itemCombination);
                    foreach (var itemParameterCombination in itemCombination.ListParameterCombination.OrderBy(itemOrder => itemOrder.CombinationOrder).ToList())
                    {
                        if (listParameterValue.Any(itemAny => itemAny.Key == itemParameterCombination.CombinationOrder && !itemAny.Value.Values.FirstOrDefault().Any(itemAnyValue => itemAnyValue == itemParameterCombination.Value)))
                        {
                            combinationAplicate.Remove(itemCombination);
                            break;
                        }
                    }
                }

                List<ParameterCombinationEL> parametersCombination = new List<ParameterCombinationEL>();

                foreach (var itemCombination in combinationAplicate)
                {
                    foreach (var itemParameterCombination in itemCombination.ListParameterCombination)
                    {
                        parametersCombination.Add(itemParameterCombination);
                    }
                }

                foreach (var itemParameterValue in listParameterValue.OrderByDescending(item => item.Key))
                {
                    var combinationSuccessful = parametersCombination.Where(item => item.CombinationOrder == itemParameterValue.Key
                                                                        && !(item.Code == itemParameterValue.Value.Keys.FirstOrDefault() && itemParameterValue.Value.Values.FirstOrDefault().Any(itemValue => itemValue == item.Value))
                                                                        ).ToList();

                    foreach (var itemCombinationSuccessful in combinationSuccessful)
                    {
                        parametersCombination.Remove(itemCombinationSuccessful);
                        parametersCombination = parametersCombination.Where(item => item.CodeCombination != itemCombinationSuccessful.CodeCombination).ToList();
                    }
                }

                if (parametersCombination.Count > 0)
                {
                    combinationCode = parametersCombination.OrderByDescending(item => item.CombinationOrder).FirstOrDefault().CodeCombination;
                    amountFreight = parametersCombination.OrderByDescending(item => item.CombinationOrder).FirstOrDefault().AmountFreight;

                    if (amountFreight > 0)
                    {
                        var listFormula = policyDomain.FormulaSearch(new FormulaRequest()
                        {
                            BusinessUnitCode = businessUnitCode,
                            RegistrationStatus = Enumerated.RegistrationStatus.Active
                        }).Result;

                        CalculateFormulaFreight(businessUnitCode, freightRequest, ref amountFreight, listFormula.Where(item => item.Order != null && item.Order > 0).ToList());
                        if (amountFreight < 0)
                        {
                            result.IsSuccess = false;
                            result.Exception = new CustomException(Enumerated.ErrorCodeCombination.CalculationFormulaWrong, Enumerated.ErrorDescriptionCombination.CalculationFormulaWrong);
                            return result;
                        }
                        else
                        {
                            result.IsSuccess = true;
                        }
                    }
                    else if (amountFreight == 0)
                    {
                        result.IsSuccess = true;
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Exception = new CustomException(Enumerated.ErrorCodeCombination.CombinationInvalid, Enumerated.ErrorDescriptionCombination.CombinationInvalid);
                        return result;
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    result.Exception = new CustomException(Enumerated.ErrorCodeCombination.CombinationNonexistent, Enumerated.ErrorDescriptionCombination.CombinationNonexistent);
                    return result;
                }
            }
            catch (Exception)
            {
                result.Exception = new CustomException();
                result.IsSuccess = false;
            }
            finally
            {
                if (result.IsSuccess)
                {
                    result.Result = new FreightEL()
                    {
                        CombinationCode = combinationCode,
                        AmountFreight = (amountFreight >= 0) ? Utility.RoundUpDecimal(amountFreight) : 0,
                    };
                }
            }
            return result;
        }

        /// <summary>
        /// Calcula el flete en base a las formulas que le correspondan
        /// </summary>
        /// <param name="businessUnitCode">Código de Unidad de Negocio</param>
        /// <param name="freightRequest">Parámetros para  Calcular el Flete</param>
        /// <param name="amountFreight">Monto del Flete actual</param>
        /// <param name="amountFreightCombination">Monto del Flete obtenido de la combinación</param>
        /// <param name="listFormula">Lista de Formulas a Aplicar</param>
        private void CalculateFormulaFreight(int businessUnitCode, FreightRequest freightRequest, ref decimal amountFreight, List<FormulaEL> listFormula)
        {
            decimal amountOperation = 0;
            List<decimal> listAmount = new List<decimal>();
            try
            {                
                foreach (var formula in listFormula.OrderBy(itemOrderBy => itemOrderBy.Order))
                {
                    bool parameterExistsFormula = false;
                    switch (formula.Code)
                    {
                        case Enumerated.Parameter.AmountRange:
                            var valuesAmountRange = policyDomain.ParameterValueSearch(new ParameterValueRequest()
                            {
                                BusinessUnitCode = businessUnitCode,
                                Code = Enumerated.Parameter.AmountRange,
                                RegistrationStatus = Enumerated.RegistrationStatus.Active
                            }).Result;

                            foreach (var value in valuesAmountRange)
                            {
                                if ((decimal)value.RecordValueObject["3"] <= freightRequest.Amount && (value.RecordValueObject["4"] == null || (decimal)value.RecordValueObject["4"] > freightRequest.Amount))
                                {
                                    parameterExistsFormula = (value.RecordValueObject["1"] != null && formula.Value == (string)value.RecordValueObject["1"]) ? true : false;
                                    if (parameterExistsFormula)
                                    {
                                        break;
                                    }
                                }
                            }
                            break;

                        case Enumerated.Parameter.ZoneType:
                            var freightUbication = policyDomain.UbicationSearch(freightRequest.Zone);
                            string codeCountry = freightUbication != null ? freightUbication.CodigoPais : string.Empty;
                            string codeLeve1 = freightUbication != null ? freightUbication.CodigoProvincia : string.Empty;
                            string codeLeve2 = freightUbication != null ? freightUbication.CodigoCiudad : string.Empty;
                            string codeLeve3 = freightUbication != null ? freightUbication.CodigoDistrito : string.Empty;

                            var valuesZoneType = policyDomain.UbigeoZoneTypeSearch(new UbigeoZoneTypeRequest() { BusinessUnitCode = businessUnitCode, CodeCountry = codeCountry, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result;

                            valuesZoneType = (from value in valuesZoneType
                                              orderby value.CodeLevel1, value.CodeLevel2, value.CodeLevel3
                                              select value).ToList();

                            var valuesZoneTypeEvaluation1 = new List<UbigeoZoneTypeEL>(valuesZoneType);
                            foreach (var value in valuesZoneTypeEvaluation1)
                            {
                                if (!string.IsNullOrEmpty(value.CodeLevel1) && value.CodeLevel1 != codeLeve1)
                                {
                                    valuesZoneType.Remove(value);
                                }
                            }
                            valuesZoneTypeEvaluation1 = null;

                            var valuesZoneTypeEvaluation2 = new List<UbigeoZoneTypeEL>(valuesZoneType);
                            foreach (var value in valuesZoneTypeEvaluation2)
                            {
                                if (!string.IsNullOrEmpty(value.CodeLevel2) && value.CodeLevel2 != codeLeve2)
                                {
                                    valuesZoneType.Remove(value);
                                }
                            }
                            valuesZoneTypeEvaluation2 = null;

                            var valuesZoneTypeEvaluation3 = new List<UbigeoZoneTypeEL>(valuesZoneType);
                            foreach (var value in valuesZoneTypeEvaluation3)
                            {
                                if (!string.IsNullOrEmpty(value.CodeLevel3) && value.CodeLevel3 != codeLeve3)
                                {
                                    valuesZoneType.Remove(value);
                                }
                            }
                            valuesZoneTypeEvaluation3 = null;

                            parameterExistsFormula = (valuesZoneType != null && formula.Value == valuesZoneType.OrderBy(item => item.CodeZone).LastOrDefault().CodeTypeZone) ? true : false;
                            break;

                        case Enumerated.Parameter.TypeOrder:
                            parameterExistsFormula = (formula.Value == freightRequest.TypeOrder) ? true : false;
                            break;

                        case Enumerated.Parameter.YearCampaign:
                            parameterExistsFormula = (formula.Value == freightRequest.YearCampaign) ? true : false;
                            break;

                        case Enumerated.Parameter.NumberCampaign:
                            parameterExistsFormula = (formula.Value == freightRequest.NumberCampaign) ? true : false;
                            break;

                        case Enumerated.Parameter.NumberWeek:
                            parameterExistsFormula = (formula.Value == freightRequest.NumberWeek) ? true : false;
                            break;

                        case Enumerated.Parameter.SendType:
                            parameterExistsFormula = (formula.Value == freightRequest.SendType) ? true : false;
                            break;

                        default:
                            var parameterDynamic = freightRequest.CollectorParameter.Where(item => item.Id == formula.Code).FirstOrDefault();

                            if (parameterDynamic != null && !string.IsNullOrEmpty(parameterDynamic.Id))
                            {
                                var valuesParameter = policyDomain.ParameterValueSearch(new ParameterValueRequest()
                                {
                                    BusinessUnitCode = businessUnitCode,
                                    Code = parameterDynamic.Id,
                                    RegistrationStatus = Enumerated.RegistrationStatus.Active
                                }).Result;

                                if (valuesParameter.FirstOrDefault().CodeParameterType == Enumerated.ParameterType.SingleValue)
                                {
                                    string valueParameter = (string)valuesParameter.Where(item => (string)item.RecordValueObject["1"] == parameterDynamic.Value).Select(item => item.RecordValueObject["1"]).FirstOrDefault();
                                    parameterExistsFormula = (valueParameter == formula.Value) ? true : false;
                                }
                                else if (valuesParameter.FirstOrDefault().CodeParameterType == Enumerated.ParameterType.RangeValues)
                                {
                                    var parameterSectionCurrent = policyDomain.ParameterSectionSearch(new ParameterSectionRequest()
                                    {
                                        CodeParameter = valuesParameter.FirstOrDefault().CodeParameter,
                                        BusinessUnitCode = businessUnitCode,
                                        RegistrationStatus = Enumerated.RegistrationStatus.Active
                                    }).Result;

                                    var sectionRangeBegin = parameterSectionCurrent.Where(itemWhere => itemWhere.RangeIndicator == Enumerated.RangeType.Begin).FirstOrDefault();
                                    var sectionRangeEnd = parameterSectionCurrent.Where(itemWhere => itemWhere.RangeIndicator == Enumerated.RangeType.End).FirstOrDefault();

                                    foreach (var value in valuesParameter)
                                    {
                                        int validationBegin = 0;
                                        int validationEnd = 0;
                                        switch (sectionRangeBegin.CodeParameterSectionType)
                                        {
                                            case Enumerated.SectionType.String:
                                                validationBegin = String.Compare((string)parameterDynamic.Value,
                                                                                    (string)value.RecordValueObject[sectionRangeBegin.CodeSection.ToString()], false, System.Globalization.CultureInfo.InvariantCulture);

                                                validationEnd = (value.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] != null)
                                                                ? String.Compare((string)parameterDynamic.Value,
                                                                                    (string)value.RecordValueObject[sectionRangeEnd.CodeSection.ToString()], false, System.Globalization.CultureInfo.InvariantCulture) : -1;
                                                break;

                                            case Enumerated.SectionType.Integer:
                                                validationBegin = Convert.ToInt32(parameterDynamic.Value).CompareTo(
                                                                                    value.RecordValueObject[sectionRangeBegin.CodeSection.ToString()]);

                                                validationEnd = (value.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] != null)
                                                                ? Convert.ToInt32(parameterDynamic.Value).CompareTo(
                                                                                    value.RecordValueObject[sectionRangeEnd.CodeSection.ToString()]) : -1;
                                                break;

                                            case Enumerated.SectionType.Decimal:
                                                validationBegin = Convert.ToDecimal(parameterDynamic.Value).CompareTo(
                                                                                    value.RecordValueObject[sectionRangeBegin.CodeSection.ToString()]);

                                                validationEnd = (value.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] != null)
                                                                ? Convert.ToDecimal(parameterDynamic.Value).CompareTo(
                                                                                    value.RecordValueObject[sectionRangeEnd.CodeSection.ToString()]) : -1;
                                                break;

                                            case Enumerated.SectionType.Date:
                                                validationBegin = Convert.ToDateTime(parameterDynamic.Value).CompareTo(
                                                                                        value.RecordValueObject[sectionRangeBegin.CodeSection.ToString()]);

                                                validationEnd = (value.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] != null)
                                                                ? Convert.ToDateTime(parameterDynamic.Value).CompareTo(
                                                                                        value.RecordValueObject[sectionRangeEnd.CodeSection.ToString()]) : -1;
                                                break;
                                        }
                                        if (validationBegin >= 0 && validationEnd <= 0)
                                        {
                                            parameterExistsFormula = (value.RecordValueObject["1"] != null && formula.Value == (string)value.RecordValueObject["1"]) ? true : false;
                                            if (parameterExistsFormula)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                    }
                    
                    if (parameterExistsFormula==true &&  (string.IsNullOrEmpty(formula.ValueSendType) || formula.ValueSendType == freightRequest.SendType))
                    {
                        if (formula.FactorType == Enumerated.FactorType.FixedValue)
                            amountOperation = formula.Factor;
                        else
                        switch (formula.Operation)
                        {
                            case Enumerated.Operation.Addition:
                                amountOperation = amountFreight + ((formula.FactorType == Enumerated.FactorType.Percent) ? amountFreight * (formula.Factor / 100) : formula.Factor);
                                break;
                            case Enumerated.Operation.Subtraction:
                                amountOperation = amountFreight - ((formula.FactorType == Enumerated.FactorType.Percent) ? amountFreight * (formula.Factor / 100) : formula.Factor);
                                break;
                            case Enumerated.Operation.Multiplication:
                                amountOperation = amountFreight * ((formula.FactorType == Enumerated.FactorType.Percent) ? amountFreight * (formula.Factor / 100) : formula.Factor);
                                break;
                            case Enumerated.Operation.Division:
                                amountOperation = amountFreight / ((formula.FactorType == Enumerated.FactorType.Percent) ? amountFreight * (formula.Factor / 100) : formula.Factor);
                                break;
                        }
                        listAmount.Add(amountOperation);
                    }
                }
                if (listAmount.Any())
                {
                    amountFreight = listAmount.Min();
                }
                
            }
            catch (Exception ex)
            {
                amountFreight = -1;
            }
        }
    }
}
