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
    /// This class implements an attribute for the custom property name.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public sealed class PropertyNameAttribute : Attribute
    {
        #region Private Fields
        private string propertyName;
        #endregion

        #region Public Constructors
        /// <summary>
        /// Initializes PropertyNameAttribute instance with a property name.
        /// </summary>
        /// <param name="propertyName">A property name</param>
        public PropertyNameAttribute(string propertyName)
        {
            this.propertyName = propertyName;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets a property name.
        /// </summary>
        public string PropertyName
        {
            get
            {
                return this.propertyName;
            }
        }
        #endregion
    }
}