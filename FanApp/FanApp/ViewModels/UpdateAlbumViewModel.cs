using System;
using System.Threading.Tasks;
using AppMobileOrders.ViewModels.Abstract;
using FanApp.FanClubApiClient;

namespace FanApp.ViewModels
{
    public class UpdateAlbumViewModel : AItemUpdateViewModel<Albums>
    {
        private string _title;
        private string _coverUrl;
        private DateOnly _releaseDate;

        public string TitleText { get => _title; set => SetProperty(ref _title, value); }
        public string CoverUrl { get => _coverUrl; set => SetProperty(ref _coverUrl, value); }
        public DateOnly ReleaseDate { get => _releaseDate; set => SetProperty(ref _releaseDate, value); }

        public UpdateAlbumViewModel() : base("Edit album") { }

        public override bool ValidateSave() => !string.IsNullOrWhiteSpace(TitleText);

        public override Albums SetItem() => new Albums
        {
            Id = ItemId,
            Title = TitleText,
            CoverUrl = CoverUrl,
            ReleaseDate = ReleaseDate
        };

        public override async Task LoadItem(int id)
        {
            var item = await DataStore.GetItemAsync(id);
            if (item == null) return;
            ItemId = item.Id;
            TitleText = item.Title;
            CoverUrl = item.CoverUrl;
            ReleaseDate = item.ReleaseDate;
        }
    }
}

