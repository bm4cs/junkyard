namespace BizTalk.T4PipelineDemo
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
"\" />      <Components>        <Component>          <Name>BizTalk.T4PipelineComponent.T4TemplaterPipe"+
"lineComponent,BizTalk.T4PipelineComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=5744765d"+
"9b55ecea</Name>          <ComponentName>T4 Pipeline Component</ComponentName>          <Description>"+
"This component spins up an in memory instance of the T4 templating engine, and washes the inbound st"+
"ream over it.</Description>          <Version>1.0</Version>          <Properties>            <Proper"+
"ty Name=\"KeyValuePairElementName\">              <Value xsi:type=\"xsd:string\">-</Value>            </"+
"Property>            <Property Name=\"KeyElementName\">              <Value xsi:type=\"xsd:string\">-</V"+
"alue>            </Property>            <Property Name=\"ValueElementName\">              <Value xsi:t"+
"ype=\"xsd:string\">-</Value>            </Property>            <Property Name=\"TemplateLocationElement"+
"Name\">              <Value xsi:type=\"xsd:string\">-</Value>            </Property>            <Proper"+
"ty Name=\"TemplateNameElementName\">              <Value xsi:type=\"xsd:string\">-</Value>            </"+
"Property>          </Properties>          <CachedDisplayName>T4 Pipeline Component</CachedDisplayNam"+
"e>          <CachedIsManaged>true</CachedIsManaged>        </Component>      </Components>    </Stag"+
"e>  </Stages></Document>";
        
        private const string _versionDependentGuid = "0eaddc70-8aeb-4999-90b5-d55e34ff030f";
        
        public T4TemplaterSendPipeline()
        {
            Microsoft.BizTalk.PipelineOM.Stage stage = this.AddStage(new System.Guid("9d0e4108-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.all);
            IBaseComponent comp0 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("BizTalk.T4PipelineComponent.T4TemplaterPipelineComponent,BizTalk.T4PipelineComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=5744765d9b55ecea");;
            if (comp0 is IPersistPropertyBag)
            {
                string comp0XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"KeyValuePairEle"+
"mentName\">      <Value xsi:type=\"xsd:string\">-</Value>    </Property>    <Property Name=\"KeyElementN"+
"ame\">      <Value xsi:type=\"xsd:string\">-</Value>    </Property>    <Property Name=\"ValueElementName"+
"\">      <Value xsi:type=\"xsd:string\">-</Value>    </Property>    <Property Name=\"TemplateLocationEle"+
"mentName\">      <Value xsi:type=\"xsd:string\">-</Value>    </Property>    <Property Name=\"TemplateNam"+
"eElementName\">      <Value xsi:type=\"xsd:string\">-</Value>    </Property>  </Properties></PropertyBa"+
"g>";
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
