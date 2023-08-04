#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
#endregion Using

namespace _7211_Assignment_1_App
{
    internal class Profile
    {
        // Fields
        // The name of the character
        public string Name { get; set; }

        // The file name of the Profile Image
        public string ProfileImage { get; set; }

        //The file name of the Banner Image
        public string BannerImage { get; set; }

        //Information about the character
        public string About { get; set; }

        // Constructors
        // Default constructor
        public Profile() { }

        // Parameterized constructor
        public Profile(string name, string profileImage, string bannerImage, string about)
        {
            Name = name;
            ProfileImage = profileImage;
            BannerImage = bannerImage;
            About = about;
        }
    }
}
