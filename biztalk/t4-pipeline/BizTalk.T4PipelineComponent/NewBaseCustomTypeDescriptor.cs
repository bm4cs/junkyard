#region Copyright
//-------------------------------------------------
// Author:  Paolo Salvatori
// Email:   paolos@microsoft.com
// History: 2009-01-08 Created
//-------------------------------------------------
#endregion

#region References
using System;
using System.ComponentModel;
using System.Collections;
using System.Resources;
using System.Reflection;
using System.Diagnostics;
#endregion

namespace BizTalk.T4PipelineComponent
{
    /// <summary>
    /// Custom type description for design-time properties.
    /// </summary>
    public class NewBaseCustomTypeDescriptor : ICustomTypeDescriptor
    {
        #region Private Fields
        private ResourceManager resourceManager;
        #endregion

        #region Public Constructors
        public NewBaseCustomTypeDescriptor(ResourceManager resourceManager)
        {
            this.resourceManager = resourceManager;
        }
        #endregion

        #region Public Properties
        public AttributeCollection GetAttributes()
        {
            return new AttributeCollection(null);
        }

        public virtual string GetClassName()
        {
            return null;
        }

        public virtual string GetComponentName()
        {
            return null;
        }

        public TypeConverter GetConverter()
        {
            return null;
        }

        public EventDescriptor GetDefaultEvent()
        {
            return null;
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return null;
        }

        public object GetEditor(Type editorBaseType)
        {
            return null;
        }

        public EventDescriptorCollection GetEvents()
        {
            return EventDescriptorCollection.Empty;
        }

        public EventDescriptorCollection GetEvents(Attribute[] filter)
        {
            return EventDescriptorCollection.Empty;
        }

        public virtual PropertyDescriptorCollection GetProperties()
        {
            PropertyDescriptorCollection sourceProperties = TypeDescriptor.GetProperties(this.GetType());
            NewPropertyDescriptor[] propertyDescriptors = new NewPropertyDescriptor[sourceProperties.Count];

            int i = 0;
            foreach (PropertyDescriptor sourceDescriptor in sourceProperties)
            {
                NewPropertyDescriptor destDescriptor = new NewPropertyDescriptor(sourceDescriptor, resourceManager);
                AttributeCollection attributes = sourceDescriptor.Attributes;
                propertyDescriptors[i++] = destDescriptor;
            }
            PropertyDescriptorCollection destProperties = new PropertyDescriptorCollection(propertyDescriptors);
            return destProperties;
        }

        public virtual PropertyDescriptorCollection GetProperties(Attribute[] filter)
        {
            PropertyDescriptorCollection baseProps = TypeDescriptor.GetProperties(this);
            return baseProps;
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
        #endregion
    }
}