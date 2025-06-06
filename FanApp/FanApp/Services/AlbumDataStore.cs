using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using FanApp.FanClubApiClient;          // wygenerowany klient NSwag
using AppMobileOrders.Helpers;          // rozszerzenie HandleRequest
using AppMobileOrders.Services.Abstract;

namespace AppMobileOrders.Services
{
    /// <summary>
    /// CRUD dla tabeli Albums (REST).
    /// </summary>
    public class AlbumDataStore : AListDataStore<Albums>
    {
        // 1) wczytanie wszystkich rekordów przy starcie
        public AlbumDataStore()
            => items = DependencyService
                        .Get<FanClubApiClient>()
                        .AlbumsAllAsync()
                        .GetAwaiter()
                        .GetResult()
                        .ToList();

        // 2) CREATE
        public override async Task<bool> AddItemToService(Albums item)
            => await DependencyService
                    .Get<FanClubApiClient>()
                    .AlbumsPOSTAsync(item)
                    .HandleRequest();

        // 3) READ (pojedynczy element w pamięci)
        public override Albums Find(Albums item)
            => items.FirstOrDefault(a => a.Id == item.Id);

        public override Albums Find(int id)
            => items.FirstOrDefault(a => a.Id == id);

        // 4) UPDATE
        public override async Task<bool> UpdateItemInService(Albums item)
            => await DependencyService
                    .Get<FanClubApiClient>()
                    .AlbumsPUTAsync(item.Id, item)
                    .HandleRequest();

        // 5) DELETE
        public override async Task<bool> DeleteItemFromService(Albums item)
            => await DependencyService
                    .Get<FanClubApiClient>()
                    .AlbumsDELETEAsync(item.Id)
                    .HandleRequest();

        // 6) REFRESH (przeładuj całą kolekcję z serwera)
        public override async Task Refresh()
            => items = (await DependencyService
                            .Get<FanClubApiClient>()
                            .AlbumsAllAsync())
                       .ToList();
    }
}

