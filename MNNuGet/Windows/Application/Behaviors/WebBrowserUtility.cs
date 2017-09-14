﻿using System;
using System.Windows;
using System.Windows.Controls;
using Multinerd.Extensions;

namespace Multinerd.Windows.Application.Behaviors
{
    [UsedImplicitly]
    public static class WebBrowserUtility
    {
        public static readonly DependencyProperty BindableSourceProperty = DependencyProperty.RegisterAttached("BindableSource", typeof(string), typeof(WebBrowserUtility), new UIPropertyMetadata(null, BindableSourcePropertyChanged));

        [UsedImplicitly]
        public static string GetBindableSource(DependencyObject obj)
        {
            return (string)obj.GetValue(BindableSourceProperty);
        }

        [UsedImplicitly]
        public static void SetBindableSource(DependencyObject obj, string value)
        {
            obj.SetValue(BindableSourceProperty, value);
        }

        private static void BindableSourcePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var browser = o as WebBrowser;
            if (browser == null) return;

            var uri = e.NewValue as string;
            browser.Source = !string.IsNullOrEmpty(uri) ? new Uri(uri) : null;
        }

    }
}
