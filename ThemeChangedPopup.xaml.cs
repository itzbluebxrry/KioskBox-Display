﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml.Media.Animation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace KioskBox_Display
{
    public sealed partial class ThemeChangedPopup : ContentDialog
    {
        public ThemeChangedPopup()
        {
            this.InitializeComponent();
        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // Attempt restart, with arguments.
            AppRestartFailureReason result =
                await CoreApplication.RequestRestartAsync("-fastInit -level 1 -foo");
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private async void Restart_Click(object sender, RoutedEventArgs e)
        {
            // Attempt restart, with arguments.
            AppRestartFailureReason result =
                await CoreApplication.RequestRestartAsync("-fastInit -level 1 -foo");
        }

        private void Dismiss_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
