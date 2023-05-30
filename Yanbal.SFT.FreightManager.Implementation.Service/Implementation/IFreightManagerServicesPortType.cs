namespace Yanbal.SFT.FreightManager.Implementation.Service
{

    /// <summary>
    /// IFreight Manager Services PortType
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:pfi:contract:task:freight", ConfigurationName="IFreightManagerServicesPortType")]
    public interface IFreightManagerServicesPortType
    {

        /// <summary>
        /// calculate Freight Order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [System.ServiceModel.OperationContractAttribute(Action="urn:pfi:contract:task:freight:calculateFreightOrder", ReplyAction="")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(GenericTypeResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(GenericTypeRequest))]
        calculateFreightOrderResponse calculateFreightOrder(calculateFreightOrderRequest request);

        /// <summary>
        /// calculate Freight Order List
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [System.ServiceModel.OperationContractAttribute(Action = "urn:pyf:contract:task:payment:calculateFreightOrderList", ReplyAction = "")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(GenericTypeResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(GenericTypeRequest))]
        calculateFreightOrderResponse calculateFreightOrderList(calculateFreightOrderRequestList request);
    }
}
