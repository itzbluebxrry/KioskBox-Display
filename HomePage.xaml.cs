using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ViewManagement;
using KioskBox_Display.Helpers;
using KioskBox_Display.Enums;
using Windows.ApplicationModel.Core;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace KioskBox_Display
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page, INotifyPropertyChanged
    {
        private DispatcherTimer _timer;

        public HomePage()
        {
            this.InitializeComponent();
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };

            _timer.Tick += (sender, o) =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentTime)));

            _timer.Start();

            ;
        }

        public string CurrentTime => DateTime.Now.ToShortTimeString();
        public event PropertyChangedEventHandler PropertyChanged;

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {

        }

        public async void viewdark_Click(object sender, RoutedEventArgs e)
        {
            ApplicationData.Current.LocalSettings.Values["themeSetting"] = 1;
            var r = await MessageBox.Show(
                "Restart required",
                "To apply theme changes, you might need to restart the app.",
                MessageBoxButtons.Custom,
                "Restart Now",
                "Dismiss");
            if (r == MessageBoxResults.CustomResult1)
            {
                await CoreApplication.RequestRestartAsync("");
            }
        }

        public async void viewlight_Click(object sender, RoutedEventArgs e)
        {
            ApplicationData.Current.LocalSettings.Values["themeSetting"] = 0;
            var r = await MessageBox.Show(
                "Restart required",
                "To apply theme changes, you might need to restart the app.",
                MessageBoxButtons.Custom, 
                "Restart Now",
                "Dismiss");
            if(r == MessageBoxResults.CustomResult1)
            {
                await CoreApplication.RequestRestartAsync("");
            }
        }

        private async void about_Click(object sender, RoutedEventArgs e)
        {
            await new ContentDialog1().ShowAsync();
        }

        private void gradiyent_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Gradiyent), null, new DrillInNavigationTransitionInfo());
        }

        private void fullscreen_Click(object sender, RoutedEventArgs e)
        {
            {
                var view = ApplicationView.GetForCurrentView();
                if (view.IsFullScreenMode)
                {
                    view.ExitFullScreenMode();
                    ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.Auto;
                    // The SizeChanged event will be raised when the exit from full-screen mode is complete.
                }
                else
                {
                    if (view.TryEnterFullScreenMode())
                    {
                        ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
                        // The SizeChanged event will be raised when the entry to full-screen mode is complete.
                    }
                }
            }
        }
    }


}

