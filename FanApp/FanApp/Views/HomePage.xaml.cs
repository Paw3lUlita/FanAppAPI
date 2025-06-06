using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FanApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void GoToNews(object sender, EventArgs e) =>
        await Shell.Current.GoToAsync("//news");

        private async void GoToConcerts(object sender, EventArgs e) =>
            await Shell.Current.GoToAsync("//concerts");

        private async void GoToAlbums(object sender, EventArgs e) =>
            await Shell.Current.GoToAsync("//albums");

        private async void GoToMembers(object sender, EventArgs e) =>
            await Shell.Current.GoToAsync("//members");

    }
}