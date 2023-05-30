namespace Yanbal.SFT.FreightManager.Implementation.Service
{
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:pfi:schema:freight")]
    public partial class OrderResponseType
    {
        
        /// <remarks/>
        public string identifyOrder;        
        /// <remarks/>
        public decimal valueFreight;        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool valueFreightSpecified;        
        /// <remarks/>
        public string errorCode;        
        /// <remarks/>
        public string errorDescription;        
        /// <remarks/>
        public string responseDate;        
        /// <remarks/>
        public string countryCode;
        /// <remarks/>
        public string sendType;
    }
}
