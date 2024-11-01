// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App4;

public sealed partial class ComboBoxControl : UserControl
{
    public event PropertyChangedEventHandler PropertyChanged;
    public event SelectionChangedEventHandler SelectionChanged;

    public ComboBoxControl()
    {
        this.InitializeComponent();
    }

    public IEnumerable ItemsSource
    {
        get { return (IEnumerable)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }

    public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
        "ItemsSource",
        typeof(IEnumerable),
        typeof(ComboBoxControl),
        new PropertyMetadata(null));

    public int SelectedIndex
    {
        get => (int)GetValue(SelectedIndexProperty);
        set => SetValue(SelectedIndexProperty, value);
    }

    // we had the property changed handler to the PropertyMetadata
    // and the handler is based in from the viewmodel component to SelectionChanged
    public static readonly DependencyProperty SelectedIndexProperty = DependencyProperty.Register(
        "SelectedIndex",
        typeof(int),
        typeof(ComboBoxControl),
        new PropertyMetadata(false, new PropertyChangedCallback(OnSelectedIndexPropertyChanged)));

    private static void OnSelectedIndexPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        ComboBoxControl input = (ComboBoxControl)sender;
        if (input != null)
        {
            input.OnSelectedIndexChanged();
        }
    }

    private void OnSelectedIndexChanged()
    {
        // this propagates the changes upwards to the actual components
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedIndex"));
    }
}
