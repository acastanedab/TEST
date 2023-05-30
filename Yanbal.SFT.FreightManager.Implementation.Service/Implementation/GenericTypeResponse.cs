namespace Yanbal.SFT.FreightManager.Implementation.Service
{
    
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FreightResponseType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:pfi:schema:base")]
    public abstract partial class GenericTypeResponse
    {
        
        /// <remarks/>
        public string responseDate;
        
        /// <remarks/>
        public ErrorType Error;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public Cabecera Header;
    }
}
