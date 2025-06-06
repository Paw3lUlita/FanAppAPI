using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FanApp.FanClubApiClient;
using Xamarin.Forms;
using AppMobileOrders.ViewModels.Abstract;

namespace FanApp.ViewModels
{
    public class AlbumDetailsViewModel : AItemDetailsViewModel<Albums>
    {
        private string _title;
        private string _coverUrl;
        private DateOnly _releaseDate;
        private List<Songs> _songs;

        public string TitleText { get => _title; set => SetProperty(ref _title, value); }
        public string CoverUrl { get => _coverUrl; set => SetProperty(ref _coverUrl, value); }
        public DateOnly ReleaseDate { get => _releaseDate; set => SetProperty(ref _releaseDate, value); }
        public List<Songs> Songs { get => _songs; set => SetProperty(ref _songs, value); }

        public AlbumDetailsViewModel() : base("Album details") 
        {
            Songs = new List<Songs>();
        }

        protected override async Task GoToUpdatePage()
            => await Shell.Current.GoToAsync($"EditAlbumPage?ItemId={ItemId}");

        public override async Task LoadItem(int id)
        {
            var item = await DataStore.GetItemAsync(id);
            if (item == null) return;
            ItemId = item.Id;
            TitleText = item.Title;
            CoverUrl = item.CoverUrl;
            ReleaseDate = item.ReleaseDate;
            Songs = item.Songs?.ToList() ?? new List<Songs>();
        }
    }
}

