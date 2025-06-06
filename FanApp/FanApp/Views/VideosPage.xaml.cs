using FanApp.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FanApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideosPage : ContentPage
    {
        // Przykładowa lista wideo z YouTube
        private List<VideoItem> _videoList = new List<VideoItem>
        {
            new VideoItem { Title = "Koniec Listopada - Reklamiarze", YoutubeId = "6z9JVDV9d5M" },
            new VideoItem { Title = "Koniec Listopada - cZŁOwiek", YoutubeId = "SnVS3rml_w4" },
            new VideoItem { Title = "Koniec Listopada - Shell shock", YoutubeId = "KJeiNN6wszk" }
        };

        public VideosPage()
        {
            InitializeComponent();

            // Przypisz listę do CollectionView
            VideosCollectionView.ItemsSource = _videoList;
        }

        // Gdy użytkownik wybierze klip z listy:
        private void OnVideoSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection == null || e.CurrentSelection.Count == 0)
                return;

            var selectedItem = e.CurrentSelection[0] as VideoItem;
            if (selectedItem == null)
                return;

            // Generujemy HTML z iframe
            var htmlSource = new HtmlWebViewSource
            {
                Html = $@"<html>
                            <head>
                              <meta name='viewport' content='initial-scale=1.0' />
                            </head>
                            <body style='margin:0;padding:0; background-color: black;'>
                              <iframe width='100%' height='315'
                                src='https://www.youtube.com/embed/{selectedItem.YoutubeId}'
                                frameborder='0' allow='autoplay; encrypted-media'
                                allowfullscreen>
                              </iframe>
                            </body>
                          </html>"
            };

            PlayerWebView.Source = htmlSource;
        }
    }
}
