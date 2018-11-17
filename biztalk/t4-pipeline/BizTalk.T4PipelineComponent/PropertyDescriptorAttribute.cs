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
    /// This class implements an attribute for the custom property description.
    /// </summary>
    /// <summary>
    /// Implements property description attribute to be used with design-time properties.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public sealed class PropertyDescriptionAttribute : Attribute
    {
        #region Private Fields
        private string propertyDescription;
        #endregion

        #region Public Constructors
        /// <summary>
        /// Initializes PropertyDescriptionAttribute instance with a property description.
        /// </summary>
        /// <param name="propertyName">A property description</param>
        public PropertyDescriptionAttribute(string propertyDescription)
        {
            this.propertyDescription = propertyDescription;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets a property description.
        /// </summary>
        public string PropertyDescription
        {
            get
            {
                return this.propertyDescription;
            }
        }
        #endregion
    }
}