﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
using Windows.UI;
using KioskBox_Display.Enums;

namespace KioskBox_Display.Helpers
{/// <summary>
 /// A <see cref="ContentDialog"/> as a MessageBox...<br/>
 /// Copied From the Emerald.UWP
 /// </summary>
    public class MessageBox : ContentDialog
    {
        public MessageBoxResults? Result { get; set; } = null;
        public MessageBox(string title, string caption, MessageBoxButtons buttons, string cusbtn1 = null, string cusbtn2 = null)
        {
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
            Title = title;
            this.Content = new Microsoft.Toolkit.Uwp.UI.Controls.MarkdownTextBlock() { Text = caption, Background = new SolidColorBrush(Colors.Transparent) };
            if (buttons == MessageBoxButtons.Ok)
            {
                PrimaryButtonText = "";
                SecondaryButtonText = Localized.OK.Localize();
                DefaultButton = ContentDialogButton.None;
            }
            else if (buttons == MessageBoxButtons.OkCancel)
            {
                PrimaryButtonText = Localized.OK.Localize();
                SecondaryButtonText = Localized.Cancel.Localize();
                DefaultButton = ContentDialogButton.Primary;
            }
            else if (buttons == MessageBoxButtons.YesNo)
            {
                PrimaryButtonText = Localized.Yes.Localize();
                SecondaryButtonText = Localized.No.Localize();
                DefaultButton = ContentDialogButton.Primary;
            }
            else if (buttons == MessageBoxButtons.Custom)
            {
                if (!string.IsNullOrEmpty(cusbtn1))
                {
                    PrimaryButtonText = cusbtn1;
                }
                if (!string.IsNullOrEmpty(cusbtn2))
                {
                    SecondaryButtonText = cusbtn2;
                }
                if (string.IsNullOrEmpty(cusbtn2) && string.IsNullOrEmpty(cusbtn1))
                {
                    PrimaryButtonText = Localized.Yes.Localize();
                    SecondaryButtonText = Localized.No.Localize();
                    DefaultButton = ContentDialogButton.Primary;
                }
            }
            else if (buttons == MessageBoxButtons.CustomWithCancel)
            {
                if (!string.IsNullOrEmpty(cusbtn1))
                {
                    PrimaryButtonText = cusbtn1;
                }
                if (!string.IsNullOrEmpty(cusbtn2))
                {
                    SecondaryButtonText = cusbtn2;
                }
                if (string.IsNullOrEmpty(cusbtn2) && string.IsNullOrEmpty(cusbtn1))
                {
                    DefaultButton = ContentDialogButton.Primary;
                    PrimaryButtonText = Localized.Yes.Localize();
                    SecondaryButtonText = Localized.No.Localize();
                }
                CloseButtonText = Localized.Cancel.Localize();
            }
            PrimaryButtonClick += ContentDialog_PrimaryButtonClick;
            SecondaryButtonClick += ContentDialog_SecondaryButtonClick;
        }
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (sender.PrimaryButtonText == Localized.OK.Localize())
            {
                Result = MessageBoxResults.Ok;
            }
            else if (sender.PrimaryButtonText == Localized.Yes.Localize())
            {
                Result = MessageBoxResults.Yes;
            }
            else
            {
                Result = MessageBoxResults.CustomResult1;
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (sender.SecondaryButtonText == Localized.OK.Localize())
            {
                Result = MessageBoxResults.Ok;
            }
            else if (sender.SecondaryButtonText == Localized.Cancel.Localize())
            {
                Result = MessageBoxResults.Cancel;
            }
            else if (sender.SecondaryButtonText == Localized.No.Localize())
            {
                Result = MessageBoxResults.No;
            }
            else
            {
                Result = MessageBoxResults.CustomResult2;
            }
        }
        public static async Task<MessageBoxResults> Show(string title, string caption, MessageBoxButtons buttons, string customResult1 = null, string customResult2 = null)
        {
            var d = new MessageBox(title, caption, buttons, customResult1, customResult2);
            try
            {
                await d.ShowAsync();
            }
            catch
            {
                throw new NotSupportedException("Cannot show 2 or more dialogs once");
            }
            return d.Result == null ? MessageBoxResults.Cancel : d.Result.Value;
        }
        public static async Task<MessageBoxResults> Show(string text)
        {
            var d = new MessageBox("Information", text, MessageBoxButtons.Ok);
            try
            {
                await d.ShowAsync();
            }
            catch
            {
                throw new NotSupportedException("Cannot show 2 or more dialogs once");
            }
            return d.Result == null ? MessageBoxResults.Cancel : d.Result.Value;
        }
    }
}
