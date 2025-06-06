using System.Threading.Tasks;
using Xamarin.Forms;
using FanApp.FanClubApiClient;
using FanApp.Views;
using AppMobileOrders.ViewModels.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace FanApp.ViewModels
{
    public class AlbumListViewModel : AItemListViewModel<Albums>
    {
        public new Command AddItemCommand { get; }
        public Command<Albums> OpenDetailsCommand { get; }
        public Command<Albums> EditItemCommand { get; }

        public AlbumListViewModel() : base("Albums")
        {
            AddItemCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(NewAlbumPage)));
            OpenDetailsCommand = new Command<Albums>(async a => await Shell.Current.GoToAsync($"{nameof(AlbumDetailsPage)}?ItemId={a.Id}"));
            EditItemCommand = new Command<Albums>(async a => await Shell.Current.GoToAsync($"{nameof(EditAlbumPage)}?ItemId={a.Id}"));
        }

        public override Task GoToAddPage() =>
            Shell.Current.GoToAsync(nameof(NewAlbumPage));

        public override Task GoToDetailsPage(Albums album) =>
            Shell.Current.GoToAsync($"{nameof(AlbumDetailsPage)}?ItemId={album.Id}");
    }
}
