using System;
using AppMobileOrders.ViewModels.Abstract;
using FanApp.FanClubApiClient;

namespace FanApp.ViewModels
{
    public class NewAlbumViewModel : ANewItemViewModel<Albums>
    {
        private string _title;
        private string _coverUrl;
        private DateTime _releaseDate = DateTime.Today;

        public string TitleText { get => _title; set => SetProperty(ref _title, value); }
        public string CoverUrl { get => _coverUrl; set => SetProperty(ref _coverUrl, value); }
        public DateTime ReleaseDate { get => _releaseDate; set => SetProperty(ref _releaseDate, value); }

        public NewAlbumViewModel() : base("New album") { }

        public override bool ValidateSave() => !string.IsNullOrWhiteSpace(TitleText);

        public override Albums SetItem() => new Albums
        {
            Title = TitleText,
            CoverUrl = CoverUrl,
            ReleaseDate = new FanApp.FanClubApiClient.DateOnly {
                Year = ReleaseDate.Year,
                Month = ReleaseDate.Month,
                Day = ReleaseDate.Day
            }
        };
    }
}


