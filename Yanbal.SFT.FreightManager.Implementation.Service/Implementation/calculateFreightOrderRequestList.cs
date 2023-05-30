namespace Yanbal.SFT.FreightManager.Implementation.Service
{


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class calculateFreightOrderRequestList
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:pfi:contract:task:freight", Order=0)]
        public FreightOrderRequestTypeList FreightOrderRequestList;
        
        public calculateFreightOrderRequestList()
        {
        }
        
        public calculateFreightOrderRequestList(FreightOrderRequestTypeList FreightOrderRequest)
        {
            this.FreightOrderRequestList = FreightOrderRequest;
        }
    }
}
