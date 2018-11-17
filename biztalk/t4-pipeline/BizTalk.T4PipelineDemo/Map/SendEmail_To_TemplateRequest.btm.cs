namespace BizTalk.T4PipelineDemo.Map {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"BizTalk.T4PipelineDemo.SendEmailRequest", typeof(global::BizTalk.T4PipelineDemo.SendEmailRequest))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"BizTalk.T4PipelineDemo.TemplateRequest", typeof(global::BizTalk.T4PipelineDemo.TemplateRequest))]
    public sealed class SendEmail_To_TemplateRequest : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var s0"" version=""1.0"" xmlns:s0=""http://BizTalk.T4PipelineDemo.SendEmailRequest/1.0/"" xmlns:ns0=""http://BizTalk.T4PipelineDemo.TemplateRequest/1.0/"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/s0:SendEmail"" />
  </xsl:template>
  <xsl:template match=""/s0:SendEmail"">
    <ns0:TemplateRequest>
      <xsl:copy-of select=""ns0:TemplateRequest/@*"" />
      <xsl:copy-of select=""ns0:TemplateRequest/*"" />
    </ns0:TemplateRequest>
  </xsl:template>
</xsl:stylesheet>";
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"BizTalk.T4PipelineDemo.SendEmailRequest";
        
        private const global::BizTalk.T4PipelineDemo.SendEmailRequest _srcSchemaTypeReference0 = null;
        
        private const string _strTrgSchemasList0 = @"BizTalk.T4PipelineDemo.TemplateRequest";
        
        private const global::BizTalk.T4PipelineDemo.TemplateRequest _trgSchemaTypeReference0 = null;
        
        public override string XmlContent {
            get {
                return _strMap;
            }
        }
        
        public override string XsltArgumentListContent {
            get {
                return _strArgList;
            }
        }
        
        public override string[] SourceSchemas {
            get {
                string[] _SrcSchemas = new string [1];
                _SrcSchemas[0] = @"BizTalk.T4PipelineDemo.SendEmailRequest";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"BizTalk.T4PipelineDemo.TemplateRequest";
                return _TrgSchemas;
            }
        }
    }
}
