#region Using
using System;
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
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Media.SpeechSynthesis;
using System.Diagnostics;
#endregion Using

namespace _7211_Assignment_1_App
{
    public sealed partial class DetailPage : Page
    {
        public DetailPage()
        {
            this.InitializeComponent();

            #region Device sizing
            ApplicationView.GetForCurrentView().TryResizeView(new Size(App.DeviceScreenWidth, App.DeviceScreenHeight));
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(App.DeviceMinimumScreenWidth, App.DeviceMinimumScreenHeight));
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            #endregion Device sizing
        }

        #region Extra
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ApplicationView.GetForCurrentView().TryResizeView(new Size(App.DeviceScreenWidth, App.DeviceScreenHeight));
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Lock the device sizing for the application
            // ApplicationView.GetForCurrentView().TryResizeView(new Size(App.DeviceScreenWidth, App.DeviceScreenHeight));
        }
        #endregion Extra

        private void GotoHomePageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
