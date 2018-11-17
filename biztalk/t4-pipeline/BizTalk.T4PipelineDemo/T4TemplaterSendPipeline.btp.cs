namespace Dccee.Integration.BizTalk.EmailServices
{
    using System;
    using System.Collections.Generic;
    using Microsoft.BizTalk.PipelineOM;
    using Microsoft.BizTalk.Component;
    using Microsoft.BizTalk.Component.Interop;
    
    
    public sealed class T4TemplaterSendPipeline : Microsoft.BizTalk.PipelineOM.SendPipeline
    {
        
        private const string _strPipeline = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instanc"+
"e\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" MajorVersion=\"1\" MinorVersion=\"0\">  <Description /> "+
" <CategoryId>8c6b051c-0ff5-4fc2-9ae5-5016cb726282</CategoryId>  <FriendlyName>Transmit</FriendlyName"+
">  <Stages>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"1\" Name=\"Pre-Assemble\" minO"+
"ccurs=\"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e4101-4cce-4536-83fa-4a5040674ad6\" />      <Co"+
"mponents />    </Stage>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"2\" Name=\"Assemb"+
"le\" minOccurs=\"0\" maxOccurs=\"1\" execMethod=\"All\" stageId=\"9d0e4107-4cce-4536-83fa-4a5040674ad6\" />  "+
"    <Components />    </Stage>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"3\" Name="+
"\"Encode\" minOccurs=\"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e4108-4cce-4536-83fa-4a5040674ad6"+
"\" />      <Components>        <Component>          <Name>Dccee.Integration.Platform.BizTalk.Pipeline"+
"Components.T4TemplaterPipelineComponent,Platform.Integration.BizTalk.PipelineComponents, Version=0.0"+
".0.0, Culture=neutral, PublicKeyToken=119facf0a03f506f</Name>          <ComponentName>Platform T4 Te"+
"mplater Pipeline Component</ComponentName>          <Description>This component retrieves a T4 templ"+
"ate using the SharePoint DocLib, and returns the output of T4 template.</Description>          <Vers"+
"ion>1.0</Version>          <Properties>            <Property Name=\"SharePointServiceUri\">           "+
"   <Value xsi:type=\"xsd:string\">-</Value>            </Property>            <Property Name=\"KeyValue"+
"PairElementName\">              <Value xsi:type=\"xsd:string\">-</Value>            </Property>        "+
"    <Property Name=\"KeyElementName\">              <Value xsi:type=\"xsd:string\">-</Value>            "+
"</Property>            <Property Name=\"ValueElementName\">              <Value xsi:type=\"xsd:string\">"+
"-</Value>            </Property>            <Property Name=\"SharePointLogicalConnectionElementName\">"+
"              <Value xsi:type=\"xsd:string\">-</Value>            </Property>            <Property Nam"+
"e=\"TemplateNameElementName\">              <Value xsi:type=\"xsd:string\">-</Value>            </Proper"+
"ty>          </Properties>          <CachedDisplayName>Platform T4 Templater Pipeline Component</Cac"+
"hedDisplayName>          <CachedIsManaged>true</CachedIsManaged>        </Component>      </Componen"+
"ts>    </Stage>  </Stages></Document>";
        
        private const string _versionDependentGuid = "18ac4a4a-2b8f-434d-976a-ac6f5b720574";
        
        public T4TemplaterSendPipeline()
        {
            Microsoft.BizTalk.PipelineOM.Stage stage = this.AddStage(new System.Guid("9d0e4108-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.all);
            IBaseComponent comp0 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("Dccee.Integration.Platform.BizTalk.PipelineComponents.T4TemplaterPipelineComponent,Platform.Integration.BizTalk.PipelineComponents, Version=0.0.0.0, Culture=neutral, PublicKeyToken=119facf0a03f506f");;
            if (comp0 is IPersistPropertyBag)
            {
                string comp0XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"SharePointServi"+
"ceUri\">      <Value xsi:type=\"xsd:string\">-</Value>    </Property>    <Property Name=\"KeyValuePairEl"+
"ementName\">      <Value xsi:type=\"xsd:string\">-</Value>    </Property>    <Property Name=\"KeyElement"+
"Name\">      <Value xsi:type=\"xsd:string\">-</Value>    </Property>    <Property Name=\"ValueElementNam"+
"e\">      <Value xsi:type=\"xsd:string\">-</Value>    </Property>    <Property Name=\"SharePointLogicalC"+
"onnectionElementName\">      <Value xsi:type=\"xsd:string\">-</Value>    </Property>    <Property Name="+
"\"TemplateNameElementName\">      <Value xsi:type=\"xsd:string\">-</Value>    </Property>  </Properties>"+
"</PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp0XmlProperties);;
                ((IPersistPropertyBag)(comp0)).Load(pb, 0);
            }
            this.AddComponent(stage, comp0);
        }
        
        public override string XmlContent
        {
            get
            {
                return _strPipeline;
            }
        }
        
        public override System.Guid VersionDependentGuid
        {
            get
            {
                return new System.Guid(_versionDependentGuid);
            }
        }
    }
}
