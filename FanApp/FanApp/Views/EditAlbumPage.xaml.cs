using FanApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FanApp.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAlbumPage : ContentPage
    {
        public int ItemId { get; set; }
        private readonly UpdateAlbumViewModel _vm;

        public EditAlbumPage()
        {
            InitializeComponent();
            BindingContext = _vm = new UpdateAlbumViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _vm.LoadItem(ItemId);
        }
    }
}
