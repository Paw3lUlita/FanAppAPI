using AppMobileOrders.Services;
using FanApp.Views;
using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FanApp.FanClubApiClient;
using FanApp.ViewModels;

namespace FanApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var http = new HttpClient();
            var apiUrl = "http://localhost:5013";          
            var api = new FanClubApiClient.FanClubApiClient(apiUrl, http);

            DependencyService.RegisterSingleton(api);

            // Register DataStores
            DependencyService.Register<AlbumDataStore>();

            // Register ViewModels
            DependencyService.Register<AlbumListViewModel>();
            DependencyService.Register<AlbumDetailsViewModel>();
            DependencyService.Register<NewAlbumViewModel>();
            DependencyService.Register<UpdateAlbumViewModel>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
