﻿//---------------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleObject.cs">(c) Mike Fourie. All other rights reserved.</copyright>
//---------------------------------------------------------------------------------------------------------------------------
// <autogenerated/>
namespace MSBuildExplorer.DataModel
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Reflection;

    public abstract class SimpleObject : INotifyPropertyChanged
    {
        ///<summary>
        ///Occurs when a property value changes.
        ///</summary>
        public virtual event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event for
        /// a given property.
        /// </summary>
        /// <param name="propertyName">The name of the changed property.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            //validate the property name in debug builds
            VerifyProperty(propertyName);

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Verifies whether the current class provides a property with a given
        /// name. This method is only invoked in debug builds, and results in
        /// a runtime exception if the <see cref="OnPropertyChanged"/> method
        /// is being invoked with an invalid property name. This may happen if
        /// a property's name was changed but not the parameter of the property's
        /// invocation of <see cref="OnPropertyChanged"/>.
        /// </summary>
        /// <param name="propertyName">The name of the changed property.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider",
            MessageId = "System.String.Format(System.String,System.Object,System.Object)"), Conditional("DEBUG")]
        [DebuggerNonUserCode]
        private void VerifyProperty(string propertyName)
        {
            var type = GetType();

            //look for a *public* property with the specified name
            var pi = type.GetProperty(propertyName);
            if (pi == null)
            {
                //there is no matching property - notify the developer
                Debug.Fail(String.Format("OnPropertyChanged was invoked with invalid property name {0}: {0} is not a public property of {1}.", propertyName, type.FullName));
            }
        }
    }
}