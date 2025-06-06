using FanApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FanApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewAlbumPage : ContentPage
    {
        public NewAlbumPage()
        {
            InitializeComponent();
            BindingContext = new NewAlbumViewModel();
        }
    }
}
