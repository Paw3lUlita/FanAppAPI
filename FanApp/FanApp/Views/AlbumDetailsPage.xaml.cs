using FanApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FanApp.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlbumDetailsPage : ContentPage
    {
        public int ItemId { get; set; }

        private readonly AlbumDetailsViewModel _vm;

        public AlbumDetailsPage()
        {
            InitializeComponent();
            BindingContext = _vm = new AlbumDetailsViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _vm.LoadItem(ItemId);
        }
    }
}
