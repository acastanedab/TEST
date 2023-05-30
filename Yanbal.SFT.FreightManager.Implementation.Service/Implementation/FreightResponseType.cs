using System.Collections.Generic;

namespace Yanbal.SFT.FreightManager.Implementation.Service
{
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:pfi:contract:task:freight")]
    public partial class FreightResponseType : GenericTypeResponse
    {       
        public OrderResponseType OrderResponse;
        public System.Collections.Generic.List<OrderResponseType> OrderResponseList;
    }
}
