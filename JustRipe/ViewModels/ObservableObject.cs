﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

namespace JustRipe.Models
{
   public abstract class ObservableObject : INotifyPropertyChanged
   {
      #region Debugging Aides

      /// <summary>
      /// Warns the developer if this object does not have
      /// a public property with the specified name. This 
      /// method does not exist in a Release build.
      /// </summary>
      [Conditional("DEBUG")]
      [DebuggerStepThrough]
      public virtual void VerifyPropertyName(string propertyName)
      {
         // Verify that the property name matches a real,  
         // public, instance property on this object.
         if (TypeDescriptor.GetProperties(this)[propertyName] == null)
         {
            string msg = "Invalid property name: " + propertyName;

            if (ThrowOnInvalidPropertyName)
               throw new Exception(msg);
            else
               Debug.Fail(msg);
         }
      }

      /// <summary>
      /// Returns whether an exception is thrown, or if a Debug.Fail() is used
      /// when an invalid property name is passed to the VerifyPropertyName method.
      /// The default value is false, but subclasses used by unit tests might 
      /// override this property's getter to return true.
      /// </summary>
      protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

      #endregion // Debugging Aides




      #region Toogle Visibility binding of controls
      private Visibility _visibility = Visibility.Collapsed;

      public Visibility FormVisibility
      {
         get { return _visibility; }
         set { _visibility = value; OnPropertyChanged(nameof(FormVisibility)); }
      }

      protected void HideForm()
      {
         FormVisibility = Visibility.Collapsed;
      }
      protected void ShowForm()
      {
         FormVisibility = Visibility.Visible;
      }
      protected void ToggleVisibility()
      {
         FormVisibility = (FormVisibility == Visibility.Collapsed) ? Visibility.Visible : Visibility.Collapsed;
      }

      #endregion // Toogle Visibility binding of controls

      #region INotifyPropertyChanged Members

      /// <summary>
      /// Raises the PropertyChange event for the property specified
      /// </summary>
      /// <param name="propertyName">Property name to update. Is case-sensitive.</param>
      public virtual void RaisePropertyChanged(string propertyName)
      {
         VerifyPropertyName(propertyName);
         OnPropertyChanged(propertyName);
      }

      /// <summary>
      /// Raised when a property on this object has a new value.
      /// </summary>
      public event PropertyChangedEventHandler PropertyChanged;

      /// <summary>
      /// Raises this object's PropertyChanged event.
      /// </summary>
      /// <param name="propertyName">The property that has a new value.</param>
      protected virtual void OnPropertyChanged(string propertyName)
      {
         VerifyPropertyName(propertyName);

         PropertyChangedEventHandler handler = PropertyChanged;
         if (handler != null)
         {
            var e = new PropertyChangedEventArgs(propertyName);
            handler(this, e);
         }
      }

      #endregion // INotifyPropertyChanged Members
   }
}