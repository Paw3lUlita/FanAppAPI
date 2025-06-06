using Xamarin.Forms;

namespace FanApp.Views
{
    public partial class AlbumListPage : ContentPage
    {
        public AlbumListPage()
        {
            InitializeComponent();
            BindingContext = new FanApp.ViewModels.AlbumListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as FanApp.ViewModels.AlbumListViewModel)?.LoadItemsCommand.Execute(null);
        }
    }
} 