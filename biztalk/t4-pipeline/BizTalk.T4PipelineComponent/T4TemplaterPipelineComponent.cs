using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Resources;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.EnterpriseServices;
using Microsoft.BizTalk.Message.Interop;
using Microsoft.BizTalk.Component.Interop;
using Microsoft.BizTalk.Streaming;
using Microsoft.BizTalk.XPath;
using System.Xml.Linq;
using System.Linq;
using BizTalk.T4PipelineComponent.Properties;
using Microsoft.BizTalk.Component;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Microsoft.VisualStudio.TextTemplating;
using System.CodeDom.Compiler;
using BizTalk.T4PipelineComponent.Commands;
using BizTalk.T4PipelineComponent.Exceptions;


namespace BizTalk.T4PipelineComponent
{
    /// <summary>
    /// This component can be used to trace the context properties of an inbound 
    /// message and the content of a given message part.
    /// </summary>
    /// <remarks>
    ///</remarks>
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [ComponentCategory(CategoryTypes.CATID_Any)]
    [ComponentCategory(CategoryTypes.CATID_Validate)]
    [Guid("740EBF2F-D0E6-4D0F-8561-98670D1DBF0D")]
    public class T4TemplaterPipelineComponent :
        //NewBaseCustomTypeDescriptor,
        BaseCustomTypeDescriptor,
        IBaseComponent,
        Microsoft.BizTalk.Component.Interop.IComponent,
        Microsoft.BizTalk.Component.Interop.IPersistPropertyBag,
        IComponentUI
    {
        //private const string SharePointServiceUriPropertyName = "SharePointServiceUriPropertyName";
        //private const string SharePointServiceUriPropertyDescription = "The location of the SharePoint CRUD WCF service.";


        //private const string BufferSizePropertyName = "BufferSizePropertyName";
        //private const string BufferSizePropertyDescription = "BufferSizePropertyDescription";
        private const int DefaultBufferSize = 0x4000;
        private const int DefaultTransactionTimeout = 3600;

        private string _sharePointServiceUri = "";
        private string _keyValuePairElementName = "";

        //private static ResourceManager resourceManager = new ResourceManager(Resources.ResourcesClass, Assembly.GetExecutingAssembly());
        private static ResourceManager resourceManager = new ResourceManager(typeof(Resources));
        private string _keyElementName;
        private string _valueElementName;
        private string _templateLocationElementName;
        private string _templateElementName
            ;

        /// <summary>
        /// Constructor initializes base class to allow custom names and description for component properies
        /// </summary>
        public T4TemplaterPipelineComponent()
            :
            base(resourceManager)
        {
        }

        /// <summary>
        /// Name of the component.
        /// </summary>
        [Browsable(false)]
        public string Name
        {
            get
            {
                return Resources.T4TemplaterPipelineComponentName;
            }
        }

        /// <summary>
        /// Version of the component.
        /// </summary>
        [Browsable(false)]
        public string Version
        {
            get
            {
                return Resources.T4TemplaterPipelineComponentVersion;
            }
        }

        /// <summary>
        /// Description of the component.
        /// </summary>
        [Browsable(false)]
        public string Description
        {
            get
            {
                return Resources.T4TemplaterFilePipelineComponentDescription;
            }
        }

        //[BtsPropertyName("PropertyNameSharePointServiceUri")]
        //[BtsDescription("PropertyDescriptionSharePointServiceUri")]
        //public string SharePointServiceUri
        //{
        //    get
        //    {
        //        return _sharePointServiceUri;
        //    }
        //    set
        //    {
        //        _sharePointServiceUri = value;
        //    }
        //}

        [BtsPropertyName("PropertyNameKeyValuePairElementName")]
        [BtsDescription("PropertyDescriptionKeyValuePairElementName")]
        public string KeyValuePairElementName
        {
            get
            {
                return _keyValuePairElementName;
            }
            set
            {
                _keyValuePairElementName = value;
            }
        }

        [BtsPropertyName("PropertyNameKeyElementName")]
        [BtsDescription("PropertyDescriptionKeyElementName")]
        public string KeyElementName
        {
            get
            {
                return _keyElementName;
            }
            set
            {
                _keyElementName = value;
            }
        }

        [BtsPropertyName("PropertyNameValueElementName")]
        [BtsDescription("PropertyDescriptionValueElementName")]
        public string ValueElementName
        {
            get
            {
                return _valueElementName;
            }
            set
            {
                _valueElementName = value;
            }
        }

        [BtsPropertyName("PropertyNameTemplateLocationElementName")]
        [BtsDescription("PropertyDescriptionTemplateLocationElementName")]
        public string TemplateLocationElementName
        {
            get
            {
                return _templateLocationElementName;
            }
            set
            {
                _templateLocationElementName = value;
            }
        }

        [BtsPropertyName("PropertyNameTemplateNameElementName")]
        [BtsDescription("PropertyDescriptionTemplateNameElementName")]
        public string TemplateElementName
        {
            get
            {
                return _templateElementName;
            }
            set
            {
                _templateElementName = value;
            }
        }

        /// <summary>
        /// Implements IComponent.Execute method.
        /// </summary>
        /// <param name="context">Pipeline context</param>
        /// <param name="message">Input message.</param>
        /// <returns>T4 template outputs.</returns>
        /// <remarks>
        /// IComponent.Execute method is used to initiate the processing of the message in pipeline component.
        /// </remarks>
        public IBaseMessage Execute(IPipelineContext context, IBaseMessage message)
        {
            try
            {
                if (context == null)
                {
                    throw new ArgumentException(Resources.ContextIsNullMessage);
                }
                if (message == null)
                {
                    throw new ArgumentException(Resources.InboundMessageIsNullMessage);
                }
                var bodyPart = message.BodyPart;
                var inboundStream = bodyPart.GetOriginalDataStream();
                if (inboundStream != null)
                {
                    var document = XDocument.Load(inboundStream);
                    var stream = ReadMessage(document, context);
                    bodyPart.Data = stream;
                    bodyPart.Data.Position = 0;
                }
            }
            catch (Exception ex)
            {
                if (message != null)
                {
                    message.SetErrorInfo(ex);
                }
                throw;
            }
            finally
            {
            }

            return message;
        }

        /// <summary>
        /// Gets class ID of component for usage from unmanaged code.
        /// </summary>
        /// <param name="classid">Class ID of the component.</param>
        public void GetClassID(out Guid classid)
        {

            
            classid = new System.Guid("A0840D07-7C1A-4430-B2E7-86682C884BFF");
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public void InitNew()
        {
        }

        /// <summary>
        /// Loads configuration property for component.
        /// </summary>
        /// <param name="pb">Configuration property bag.</param>
        /// <param name="errlog">Error status (not used in this code).</param>
        public void Load(IPropertyBag propertyBag, Int32 errlog)
        {
            try
            {
                object data = null;

                data = ReadPropertyBag(propertyBag, Resources.KeyValuePairElementName);
                if (data != null &&
                    data is string)
                {
                    _keyValuePairElementName = (string)data;
                }
                else
                {
                    _keyValuePairElementName = "";
                }

                data = ReadPropertyBag(propertyBag, Resources.KeyElementName);
                if (data != null &&
                    data is string)
                {
                    _keyElementName = (string)data;
                }
                else
                {
                    _keyElementName = "";
                }

                data = ReadPropertyBag(propertyBag, Resources.ValueElementName);
                if (data != null &&
                    data is string)
                {
                    _valueElementName = (string)data;
                }
                else
                {
                    _valueElementName = "";
                }

                data = ReadPropertyBag(propertyBag, Resources.TemplateLocationElementName);
                if (data != null &&
                    data is string)
                {
                    _templateLocationElementName = (string)data;
                }
                else
                {
                    _templateLocationElementName = "";
                }

                data = ReadPropertyBag(propertyBag, Resources.TemplateNameElementName);
                if (data != null &&
                    data is string)
                {
                    _templateElementName = (string)data;
                }
                else
                {
                    _templateElementName = "";
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw; ;
            }
        }

        /// <summary>
        /// Saves the current component configuration into the property bag.
        /// </summary>
        /// <param name="propertyBag">Configuration property bag.</param>
        /// <param name="clearDirty">Not used.</param>
        /// <param name="saveAllProperties">Not used.</param>
        public void Save(IPropertyBag propertyBag, Boolean clearDirty, Boolean saveAllProperties)
        {
            try
            {
                WritePropertyBag(propertyBag, Resources.KeyValuePairElementName, (object)_keyValuePairElementName);
                WritePropertyBag(propertyBag, Resources.KeyElementName, (object)_keyElementName);
                WritePropertyBag(propertyBag, Resources.ValueElementName, (object)_valueElementName);
                WritePropertyBag(propertyBag, Resources.TemplateLocationElementName, (object)_templateLocationElementName);
                WritePropertyBag(propertyBag, Resources.TemplateNameElementName, (object)_templateElementName);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                throw; ;
            }
        }

        /// <summary>
        /// Reads property value from property bag.
        /// </summary>
        /// <param name="propertyBag">Property bag.</param>
        /// <param name="propertyName">Name of property.</param>
        /// <returns>Value of the property.</returns>
        private object ReadPropertyBag(IPropertyBag propertyBag, string propertyName)
        {
            object val = null;
            try
            {
                propertyBag.Read(propertyName, out val, 0);
            }
            catch (ArgumentException)
            {
                return val;
            }
            //catch (Exception ex)
            //{
            //    ExceptionHelper.HandleException(Resources.T4TemplaterPipelineComponentName, ex);
            //    TraceHelper.WriteLineIf(traceEnabled, ex.Message, EventLogEntryType.Error);
            //    throw; ;
            //}
            return val;
        }

        /// <summary>
        /// Writes property values into a property bag.
        /// </summary>
        /// <param name="pb">Property bag.</param>
        /// <param name="propName">Name of property.</param>
        /// <param name="val">Value of property.</param>
        private void WritePropertyBag(IPropertyBag propertyBag, string propertyName, object value)
        {
            try
            {
                propertyBag.Write(propertyName, ref value);
            }
            catch (Exception ex)
            {
                //ExceptionHelper.HandleException(Resources.T4TemplaterPipelineComponentName, ex);
                //TraceHelper.WriteLineIf(traceEnabled, ex.Message, EventLogEntryType.Error);
                throw; ;
            }
        }

        /// <summary>
        /// Component icon to use in BizTalk Editor.
        /// </summary>
        [Browsable(false)]
        public IntPtr Icon
        {
            get
            {
                return Resources.star.Handle;
            }
        }

        /// <summary>
        /// The Validate method is called by the BizTalk Editor during the build 
        /// of a BizTalk project.
        /// </summary>
        /// <param name="obj">Project system.</param>
        /// <returns>
        /// A list of error and/or warning messages encounter during validation
        /// of this component.
        /// </returns>
        public IEnumerator Validate(object obj)
        {
            IEnumerator enumerator = null;
            var strList = new ArrayList();

            //// Validate prepend data property
            //if ((prependData != null) &&
            //(prependData.Length >= 64))
            //{
            //    strList.Add(resManager.GetString("ErrorPrependDataTooLong"));
            //}

            //// validate append data property
            //if ((appendData != null) &&
            //(appendData.Length >= 64))
            //{
            //    strList.Add(resManager.GetString("ErrorAppendDataTooLong"));
            //}

            //if (strList.Count > 0)
            //{
            //    enumerator = strList.GetEnumerator();
            //}

            return enumerator;
        }


        /// <summary>
        /// 1. Query SharePoint for T4 template.
        /// 2. Execute T4 template.
        /// 3. Load stream.
        /// </summary>
        /// <param name="document"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private Stream ReadMessage(XDocument document, IPipelineContext context)
        {
            if (String.IsNullOrEmpty(KeyValuePairElementName) ||
                String.IsNullOrEmpty(KeyElementName) ||
                String.IsNullOrEmpty(ValueElementName) ||
                String.IsNullOrEmpty(TemplateElementName) ||
                String.IsNullOrEmpty(TemplateLocationElementName))
            {

                throw new T4TemplatePipelineValidationException(
                    String.Format(
                        resourceManager.GetString("PipelineParametersUnspecified"),
                        KeyValuePairElementName,
                        KeyElementName,
                        ValueElementName,
                        TemplateElementName,
                        TemplateLocationElementName));
            }

            if (document != null)
            {
                //
                var templateName = document.Descendants(TemplateElementName).Single().Value;

                //
                var templateLocation = document.Descendants(TemplateLocationElementName).Single().Value;

                if (String.IsNullOrWhiteSpace(templateName))
                {
                    throw new T4TemplatePipelineValidationException(resourceManager.GetString("TemplateNameUnspecified"));
                }

                if (String.IsNullOrWhiteSpace(templateLocation))
                {
                    throw new T4TemplatePipelineValidationException(resourceManager.GetString("TemplateLocationUnspecified"));
                }

                //Parse the property bag.
                var propertyBag =
                    document.Descendants(KeyValuePairElementName).ToDictionary(
                        x => x.Element(KeyElementName).Value,
                        x => x.Element(ValueElementName).Value);
                
                var parser = new CommandParser(GetAvailableCommands());
                var command = parser.ParseCommand("File", new CommandParams() { TemplateName = templateName, TemplateLocation = templateLocation });
                var templateContent = command.Execute();

                //Run the template.
                return ExecuteT4Template(templateContent, propertyBag);
            }
            return null;
        }


        private IEnumerable<ICommandFactory> GetAvailableCommands()
        {
            return new ICommandFactory[]
            {
                new FileTemplateResolverCommand(),
                //new SharePointTemplateResolverCommand()
            };
        }


        private Stream ExecuteT4Template(string templateContent, Dictionary<string, string> propertyBag)
        {
            var host = new CustomTemplateHost();
            var engine = new Engine();
            host.TemplateFileValue = "c:\\foo.t4";
            //string input = templateContent;

            var session = host.CreateSession();
            foreach (var property in propertyBag)
            {
                session.Add(property.Key, property.Value);
            }

            string output = engine.ProcessTemplate(templateContent, host);

            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream);
            streamWriter.Write(output);
            streamWriter.Flush();
            stream.Position = 0L;


            if (!host.Errors.HasErrors)
                return stream;

            var exception = new T4TemplateException("T4 compilation error");

            foreach (var error in host.Errors)
            {
                exception.AddError(error.ToString());
            }

            throw exception;
        }

        public static string GetTempFilePathWithExtension(string extension)
        {
            var path = Path.GetTempPath();
            var fileName = Guid.NewGuid().ToString() + extension;
            return Path.Combine(path, fileName);
        }

        private void HandleException(Exception exception)
        {
            Debug.Write(String.Format("T4Template Pipeline Component Exception : {0}", exception.Message));
        }
    }
}