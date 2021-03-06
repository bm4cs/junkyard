# Summary #

A tiny pipeline component that surfaces up the powerful T4 (text template transformation toolkit) templating through a BizTalk Server pipeline.

# Context #

Frameworks like ASP.NET are well equipped with templating engines, and more so now with the extensibility that ASP.NET MVC offers (can run with the awesome Razor view engine, or swap in a view engine of your liking such as the excellent Spark view engine). Simply put, a views template is responsible for transforming a model into a representation.

> A T4 text template is a mixture of text blocks and control logic that can generate a text file. The control logic is written as fragments of program code in Visual C# or Visual Basic. The generated file can be text of any kind, such as a Web page, or a resource file, or program source code in any language.

Some benefits of using T4; it's a baked in library, the templates are very readable opening up maintenance possibilities to business/power users (XSLT eats users for breakfast), moves away from the the clumsiness of doing custom StringBuilder/Regex type implementations.

To get started I found quickly a custom T4 host was necessary. Creating an `ITextTemplatingEngineHost` is not the most documented process in the world. MSDN does however provide a very basic [console based walkthrough](http://msdn.microsoft.com/en-us/library/bb126579.aspx), with sample code. Its a great start, but unfortunately doesn't cover of a number of subtleties, particularly around managing stateful template parameters using the `ITextTemplatingSessionHost` interface.

After getting a working custom T4 template host pieced together, my next goal was to drop the custom T4 template host into a BizTalk pipeline component. The goal being to bind a T4 template over an outbound XML stream via a send pipeline.

To make this happen, the outbound message is required to specify a few things:

*   The name of the T4 template to be applied,
*   The location of the said template. This could come from a variety of sources such as a SharePoint document library, a simple file share, the BizTalkMgmtDb as a resource, even Azure blob storage! One compelling reason behind using templates, is that non-technical people can maintain their actual content.
*   A set of key/value pairs, to be bound as T4 parameters, for consumption by the template.

### Configured Pipeline Component ###
![The T4 pipeline component, in its configured state](http://bencode.net/get/img/t4_plinecfg.png)


### CustomTemplateHost.cs ###
A "working" `ITextTemplatingEngineHost` implementation. Additionally implements `ITextTemplatingSessionHost` to support stateful/session based template parameters.

    using System;
    using System.IO;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.VisualStudio.TextTemplating;
    
    namespace BizTalk.T4PipelineComponent
    {
      internal class CustomTemplateHost : ITextTemplatingEngineHost, ITextTemplatingSessionHost
      {
        internal string TemplateFileValue;
    
        public string TemplateFile
        {
          get { return TemplateFileValue; }
        }
    
        private string fileExtensionValue = ".txt";
    
        public string FileExtension
        {
          get { return fileExtensionValue; }
        }
    
        private Encoding fileEncodingValue = Encoding.UTF8;
    
        public Encoding FileEncoding
        {
          get { return fileEncodingValue; }
        }
    
        private CompilerErrorCollection errorsValue;
    
        public CompilerErrorCollection Errors
        {
          get { return errorsValue; }
        }
    
        public IList<string> StandardAssemblyReferences
        {
          get
          {
            return new string[]
    				   {
    					   typeof (System.Uri).Assembly.Location
    				   };
          }
        }
    
        public IList<string> StandardImports
        {
          get
          {
            return new string[]
                   {
                     "System"
                   };
          }
        }
    
        public bool LoadIncludeText(string requestFileName, out string content, out string location)
        {
          content = System.String.Empty;
          location = System.String.Empty;
    
          if (File.Exists(requestFileName))
          {
            content = File.ReadAllText(requestFileName);
            return true;
          }
          else
          {
            return false;
          }
        }
    
        public object GetHostOption(string optionName)
        {
          object returnObject;
          switch (optionName)
          {
            case "CacheAssemblies":
              returnObject = true;
              break;
            default:
              returnObject = null;
              break;
          }
          return returnObject;
        }
    
        public string ResolveAssemblyReference(string assemblyReference)
        {
          if (File.Exists(assemblyReference))
          {
            return assemblyReference;
          }
          string candidate = Path.Combine(Path.GetDirectoryName(this.TemplateFile), assemblyReference);
          if (File.Exists(candidate))
          {
            return candidate;
          }
          return "";
        }
    
        public Type ResolveDirectiveProcessor(string processorName)
        {
          if (string.Compare(processorName, "XYZ", StringComparison.OrdinalIgnoreCase) == 0)
          {
            //return typeof();
          }
          throw new Exception("Directive Processor not found");
        }
    
        public string ResolvePath(string fileName)
        {
          if (fileName == null)
          {
            throw new ArgumentNullException("the file name cannot be null");
          }
    
          if (File.Exists(fileName))
          {
            return fileName;
          }
    
          string candidate = Path.Combine(Path.GetDirectoryName(this.TemplateFile), fileName);
          if (File.Exists(candidate))
          {
            return candidate;
          }
          return fileName;
        }
    
        public string ResolveParameterValue(string directiveId, string processorName, string parameterName)
        {
          if (directiveId == null)
          {
            throw new ArgumentNullException("the directiveId cannot be null");
          }
          if (processorName == null)
          {
            throw new ArgumentNullException("the processorName cannot be null");
          }
          if (parameterName == null)
          {
            throw new ArgumentNullException("the parameterName cannot be null");
          }
          return String.Empty;
        }
    
        public void SetFileExtension(string extension)
        {
          fileExtensionValue = extension;
        }
    
        public void SetOutputEncoding(System.Text.Encoding encoding, bool fromOutputDirective)
        {
          fileEncodingValue = encoding;
        }
    
        public void LogErrors(CompilerErrorCollection errors)
        {
          errorsValue = errors;
        }
    
        public AppDomain ProvideTemplatingAppDomain(string content)
        {
          return AppDomain.CreateDomain("Generation App Domain");
        }
    
        public ITextTemplatingSession CreateSession()
        {
          Session = new TextTemplatingSession();
          return Session;
        }
    
        public ITextTemplatingSession Session { get; set; }
      }
    }

### FileTemplateResolverCommand.cs ###
Simple example of a template resolver. I will include working SharePoint command later.

    public class FileTemplateResolverCommand : ICommand, ICommandFactory
    {
      public CommandParams Parameters { get; set; }
    
      public string Execute()
      {
        return File.ReadAllText(Parameters.TemplateLocation);
      }
    
      public string CommandName
      {
        get { return "File"; }
      }
    
      public string Description
      {
        get { return "A simple file system based template resolver."; }
      }
    
      public ICommand MakeCommand(CommandParams arguments)
      {
        return new FileTemplateResolverCommand {Parameters = arguments};
      }
    }

### TemplateRequest.xsd ###
A simple schema that represents the above requirements.

    <?xml version="1.0" encoding="utf-16"?>
    <xs:schema xmlns="http://BizTalk.T4PipelineDemo.TemplateRequest/1.0/" xmlns:b="http://schemas.microsoft.com/BizTalk/2003" targetNamespace="http://BizTalk.T4PipelineDemo.TemplateRequest/1.0/" xmlns:xs="http://www.w3.org/2001/XMLSchema">
      <xs:element name="TemplateRequest">
      <xs:complexType>
        <xs:sequence>
        <xs:element minOccurs="1" maxOccurs="1" name="TemplateName" type="xs:string" />
        <xs:element minOccurs="1" maxOccurs="1" name="TemplateLocation" type="xs:string" />
        <xs:element minOccurs="0" maxOccurs="1" name="TemplateParams">
          <xs:complexType>
          <xs:sequence>
            <xs:element minOccurs="0" maxOccurs="unbounded" name="TemplateParam">
            <xs:complexType>
              <xs:sequence>
              <xs:element name="Key" type="xs:string" />
              <xs:element name="Value" type="xs:string" />
              </xs:sequence>
            </xs:complexType>
            </xs:element>
          </xs:sequence>
          </xs:complexType>
        </xs:element>
        </xs:sequence>
      </xs:complexType>
      </xs:element>
    </xs:schema>

### Sample.tt ###
An actual T4 template definition. This is really just the tip of the iceberg. T4 supports things like looping constructs, and injectable parameters.

    <#@ parameter name="Firstname" type="System.String" #>
    <#@ parameter name="Lastname" type="System.String" #>
    <#@ parameter name="CustomerNo" type="System.String" #>
    
    To <#= Firstname #> <#= Lastname #>,
    
    Text Template Host Test
    
    Your reference number is : <#= CustomerNo #>
    
    <#@ template debug="true" #>
    
    <# //Uncomment this line to test that the host allows the engine to set the extension. #>
    <# //@ output extension=".htm" #>
    
    <# //Uncomment this line if you want to debug the generated transformation class. #>
    <# //System.Diagnostics.Debugger.Break(); #>
    
    <# for (int i=0; i<3; i++)
       {
         WriteLine("This is a test");
       }
    #>

### SendEmail.xml ###
An instance of the business message that wraps the template request (note the TemplateRequest is embedded in the SendEmail request). In this particular instance, are interested in delivering an email (care about things like sender, recipient, subject, and so on). However, could just as easily T4 out to SAP, FTP, FILE or whatever fits your problem space.

    <ns0:SendEmail xmlns:ns0="http://BizTalk.T4PipelineDemo.SendEmailRequest/1.0/">
      <To>1337@nodejs.org</To>
      <From>ben@bencode.net</From>
      <Subject>Hello T4</Subject>
      <ns1:TemplateRequest xmlns:ns1="http://BizTalk.T4PipelineDemo.TemplateRequest/1.0/">
      <TemplateName>sample.tt</TemplateName>
      <TemplateLocation>c:\\Sample.tt</TemplateLocation>
      <TemplateParams>
        <TemplateParam>
        <Key>Firstname</Key>
        <Value>Arnold</Value>
        </TemplateParam>
        <TemplateParam>
        <Key>Surname</Key>
        <Value>Schwarzenegger</Value>
        </TemplateParam>
        <TemplateParam>
        <Key>CustomerNo</Key>
        <Value>ABC123456789</Value>
        </TemplateParam>
      </TemplateParams>
      </ns1:TemplateRequest>
    </ns0:SendEmail>

### SampleEmail.eml ###
The resulting mail message produced from the dynamic SMTP send port configured against the T4TemplateSend pipeline.

    thread-index: Ac0bA1TZgMDs4cR9S7+lcZrskqCkkw==
    Thread-Topic: =?utf-8?B?SGVsbG8gVDQ=?=
    From: <ben@bencode.net>
    To: <1337@nodejs.org>
    Cc: 
    Subject: =?utf-8?B?SGVsbG8gVDQ=?=
    Date: Sun, 15 Apr 2012 05:28:58 -0700
    Message-ID: <80C4BE005ACF4725836ED9FF412DCA16@bencode.net>
    MIME-Version: 1.0
    Content-Type: text/plain;
    	charset="UTF-8"
    Content-Transfer-Encoding: 7bit
    Content-Description: body
    X-Mailer: Microsoft CDO for Windows 2000
    Content-Class: urn:content-classes:message
    Importance: normal
    Priority: normal
    X-MimeOLE: Produced By Microsoft MimeOLE V6.1.7600.16385
    
    
    To Arnold Schwarzenegger,
    
    Text Template Host Test
    
    Your reference number is : ABC123456789
    
    
    
    
    This is a test
    This is a test
    This is a test

