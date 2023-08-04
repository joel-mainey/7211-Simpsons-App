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
using System.Collections.ObjectModel;
#endregion Using

namespace _7211_Assignment_1_App
{
    public sealed partial class MainPage : Page
    {
        #region Fields & Constants
        // Fields
        MediaElement media = new MediaElement();
        Random random;
        int rand;
        #endregion Fields & Constants

        #region Dictionary
        // Dictionary to store profile information
        Dictionary<string, Profile> profileDictionary = new Dictionary<string, Profile>()
        {
            // Key-value pairs representing profiles and their details
            {"Homer", new Profile() { Name = "Homer", ProfileImage = "homer.png", BannerImage = "homer.jpg", About = "Homer's greed is often foiled by his stupidity, though his failed schemes usually are saved by the big heart he has for his family. His warped perception of himself and the world and his hours drinking at Moe's Tavern are hysterical." } },
            {"Marge", new Profile() { Name = "Marge", ProfileImage = "marge.png", BannerImage= "marge.jpg", About = "Marge is recognizable by her green, strapless dress and mile-high blue hair. She's more than a stay-at-home mom, opening businesses and standing up for her beliefs. Although she's left Homer several times, she remains loyal." } },
            {"Bart", new Profile() { Name = "Bart", ProfileImage = "bart.png", BannerImage= "bart.jpg", About = "Bart is the bad kid in all of us: a prankster, smart-mouth, and vandal. Yet he shows great compassion and tenderness for his family." } },
            {"Lisa", new Profile() { Name = "Lisa", ProfileImage = "lisa.png", BannerImage= "lisa.jpg", About = "Lisa's sharp wit is as funny as her overachievements. She's so strait-laced that when we discover quirks—like her love of Corey, the overly cool face of a girls' chat line—they're even funnier." } },
            {"Maggie", new Profile() { Name = "Maggie", ProfileImage = "maggie.png", BannerImage= "maggie.jpg", About = "Maggie is more than just an accessory baby in the family. In one episode she pulls a gun from under her crib mattress to protect her family from mobsters, then calmly goes back to sleep." } }
        };
        #endregion Dictionary

        #region Constructor
        public MainPage()
        {
            this.InitializeComponent();

            random = new Random();

            // Convert the dictionary to ObservableCollection of KeyValuePair
            var profileList = new ObservableCollection<KeyValuePair<string, Profile>>(profileDictionary);

            // Set the DataContext of the MainPage to the ObservableCollection
            DataContext = profileList;

            #region Device sizing
            ApplicationView.GetForCurrentView().TryResizeView(new Size(App.DeviceScreenWidth, App.DeviceScreenHeight));
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(App.DeviceMinimumScreenWidth, App.DeviceMinimumScreenHeight));
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            #endregion Device sizing
        }
        #endregion Constructor

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



        #region Methods
        // Methods
        // Displays a random profile when button is clicked
        private void GenerateProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rand = random.Next(0, 5);

                Profile theProfile = profileDictionary[profileDictionary.Keys.ElementAt(rand)];

                Background.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Simpsons/background.jpg"));
                Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/Simpsons/"));

                Name.Text = theProfile.Name.ToString();
                About.Text = theProfile.About.ToString();

                Banner.Source = new BitmapImage(new Uri("ms-appx:///Assets/Simpsons/BannerImage/" + theProfile.BannerImage.ToString(), UriKind.RelativeOrAbsolute));
                ProfileImage.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Simpsons/ProfileImage/" + theProfile.ProfileImage.ToString(), UriKind.RelativeOrAbsolute));

                ListBox.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot get profile: {ex.Message}");
            }
        }

        // Change About text when listbox selection clicked
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Profile theProfile = profileDictionary[profileDictionary.Keys.ElementAt(0)];

            // Get the selected profile from the ListBox
            if (ListBox.SelectedItem is KeyValuePair<string, Profile> selectedProfile)
            {
                Name.Text = selectedProfile.Value.Name;

                var bitmap1 = new BitmapImage(new System.Uri("ms-appx:///Assets/Simpsons/ProfileImage/" + selectedProfile.Value.ProfileImage));
                ProfileImage.ImageSource = bitmap1;

                var bitmap2 = new BitmapImage(new System.Uri("ms-appx:///Assets/Simpsons/BannerImage/" + selectedProfile.Value.BannerImage));
                Banner.Source = bitmap2;

                About.Text = selectedProfile.Value.About;
            }
        }

        // Perform speech synthesis for the given message using the provided MediaElement
        private async void Talk(string message, MediaElement media)
        {
            using (var reader = new SpeechSynthesizer())
            {
                var stream = await reader.SynthesizeTextToStreamAsync(message);
                media.SetSource(stream, stream.ContentType);
                media.Play();
            }
        }

        // Handle the double tap event of the about text
        private void About_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var Aboutstring = $"{About.Text} {About.Text} ";
            Talk(Aboutstring, media);
        }
        #endregion Methods

        private void GotoDetailPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DetailPage));
        }
    }
}
