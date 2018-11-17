namespace BizTalk.T4PipelineDemo {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://BizTalk.T4PipelineDemo.TemplateRequest/1.0/",@"TemplateRequest")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"TemplateRequest"})]
    public sealed class TemplateRequest : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://BizTalk.T4PipelineDemo.TemplateRequest/1.0/"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" targetNamespace=""http://BizTalk.T4PipelineDemo.TemplateRequest/1.0/"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""TemplateRequest"">
    <xs:complexType>
      <xs:sequence>
        <xs:element minOccurs=""1"" maxOccurs=""1"" name=""TemplateName"" type=""xs:string"" />
        <xs:element minOccurs=""1"" maxOccurs=""1"" name=""TemplateLocation"" type=""xs:string"" />
        <xs:element minOccurs=""0"" maxOccurs=""1"" name=""TemplateParams"">
          <xs:complexType>
            <xs:sequence>
              <xs:element minOccurs=""0"" maxOccurs=""unbounded"" name=""TemplateParam"">
                <xs:complexType>
                  <xs:sequence>
                    <xs:element name=""Key"" type=""xs:string"" />
                    <xs:element name=""Value"" type=""xs:string"" />
                  </xs:sequence>
                </xs:complexType>
              </xs:element>
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public TemplateRequest() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "TemplateRequest";
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
