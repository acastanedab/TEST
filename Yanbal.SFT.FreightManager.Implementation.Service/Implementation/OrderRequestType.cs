namespace Yanbal.SFT.FreightManager.Implementation.Service
{
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:pfi:schema:freight")]
    public partial class OrderRequestType
    {
        
        /// <remarks/>
        public string identifyOrder;
        
        /// <remarks/>
        public decimal valueTotalOrder;
        
        /// <remarks/>
        public string countryCode;
        
        /// <remarks/>
        public string zoneId;
        
        /// <remarks/>
        public string orderType;
        
        /// <remarks/>
        public string processDate;
        
        /// <remarks/>
        public int campaignYear;
        
        /// <remarks/>
        public int campaignNumber;
        
        /// <remarks/>
        public int weekNumber;
        
        /// <remarks/>
        public string sendType;
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Parameter", Namespace="urn:pfi:schema:base", IsNullable=false)]
        public System.Collections.Generic.List<ParameterType> collectorParameterList;
        
        public virtual bool ShouldSerializecollectorParameterList()
        {
            return ((this.collectorParameterList != null) 
                        && (this.collectorParameterList.Count > 0));
        }
    }
}
