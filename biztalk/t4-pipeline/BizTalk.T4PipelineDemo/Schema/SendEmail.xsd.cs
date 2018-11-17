namespace BizTalk.T4PipelineDemo {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://BizTalk.T4PipelineDemo.SendEmailRequest/1.0/",@"SendEmail")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "To", XPath = @"/*[local-name()='SendEmail' and namespace-uri()='http://BizTalk.T4PipelineDemo.SendEmailRequest/1.0/']/*[local-name()='To' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "From", XPath = @"/*[local-name()='SendEmail' and namespace-uri()='http://BizTalk.T4PipelineDemo.SendEmailRequest/1.0/']/*[local-name()='From' and namespace-uri()='']", XsdType = @"string")]
    [Microsoft.XLANGs.BaseTypes.DistinguishedFieldAttribute(typeof(System.String), "Subject", XPath = @"/*[local-name()='SendEmail' and namespace-uri()='http://BizTalk.T4PipelineDemo.SendEmailRequest/1.0/']/*[local-name()='Subject' and namespace-uri()='']", XsdType = @"string")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"SendEmail"})]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"BizTalk.T4PipelineDemo.TemplateRequest", typeof(global::BizTalk.T4PipelineDemo.TemplateRequest))]
    public sealed class SendEmailRequest : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://BizTalk.T4PipelineDemo.SendEmailRequest/1.0/"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" xmlns:ns0=""http://BizTalk.T4PipelineDemo.TemplateRequest/1.0/"" targetNamespace=""http://BizTalk.T4PipelineDemo.SendEmailRequest/1.0/"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:import schemaLocation=""BizTalk.T4PipelineDemo.TemplateRequest"" namespace=""http://BizTalk.T4PipelineDemo.TemplateRequest/1.0/"" />
  <xs:annotation>
    <xs:appinfo>
      <b:references>
        <b:reference targetNamespace=""http://BizTalk.T4PipelineDemo.TemplateRequest/1.0/"" />
      </b:references>
    </xs:appinfo>
  </xs:annotation>
  <xs:element name=""SendEmail"">
    <xs:annotation>
      <xs:appinfo>
        <b:properties>
          <b:property distinguished=""true"" xpath=""/*[local-name()='SendEmail' and namespace-uri()='http://BizTalk.T4PipelineDemo.SendEmailRequest/1.0/']/*[local-name()='To' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='SendEmail' and namespace-uri()='http://BizTalk.T4PipelineDemo.SendEmailRequest/1.0/']/*[local-name()='From' and namespace-uri()='']"" />
          <b:property distinguished=""true"" xpath=""/*[local-name()='SendEmail' and namespace-uri()='http://BizTalk.T4PipelineDemo.SendEmailRequest/1.0/']/*[local-name()='Subject' and namespace-uri()='']"" />
        </b:properties>
      </xs:appinfo>
    </xs:annotation>
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""To"" type=""xs:string"" />
        <xs:element name=""From"" type=""xs:string"" />
        <xs:element name=""Subject"" type=""xs:string"" />
        <xs:element ref=""ns0:TemplateRequest"" />
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public SendEmailRequest() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "SendEmail";
                return _RootElements;
            }
        }
        
        protected override object RawSchema {
            get {
                return _rawSchema;
            }
            set {
                _rawSchema = value;
            }
        }
    }
}
