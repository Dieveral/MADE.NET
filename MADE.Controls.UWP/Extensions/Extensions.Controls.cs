﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Extensions.Controls.cs" company="MADE Apps">
//   Copyright (c) MADE Apps.
// </copyright>
// <summary>
//   Defines a collection of extensions for UWP controls.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MADE.Controls
{
    using Windows.UI.Xaml;

    /// <summary>
    /// Defines a collection of extensions for UWP controls.
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Sets the visibility of the given control by the given visible boolean value.
        /// </summary>
        /// <param name="control">
        /// The control to update visibility.
        /// </param>
        /// <param name="isVisible">
        /// A value indicating whether the control is visible.
        /// </param>
        public static void SetVisible(this Windows.UI.Xaml.Controls.Control control, bool isVisible)
        {
            if (control != null)
            {
                control.Visibility = isVisible ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }
}