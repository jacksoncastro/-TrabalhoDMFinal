using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjetoDMFinal
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class FavoritePage : Page
    {

        private const String Url = "https://gateway.marvel.com/v1/public/characters/{0}?apikey={1}&ts=1&hash={2}&limit{3}";
        private const String APIKey = "a2d01370e4278b621c371892e9041094";
        private const String Hash = "0137664330e5b71ccbdff2421cafa4d7";
        private const int Limit = 10;

        private List<int> favorites = new List<int>();

        public FavoritePage()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            favorites = e.Parameter as List<int>;
            foreach (var heroId in favorites)
            {
                LoadHeroes(heroId);
            }
        }


        public void LoadHeroes(int heroId)
        {
            string url = String.Format(Url, heroId, APIKey, Hash, Limit);
            Uri uri = new Uri(url, UriKind.Absolute);
            var request = (HttpWebRequest) WebRequest.Create(uri);
            request.Method = "GET";
            request.Accept = "application/json";
            request.BeginGetResponse((result) =>
            {
                var req = (HttpWebRequest)result.AsyncState;
                var response = req.EndGetResponse(result);
                var stream = response.GetResponseStream();
                if (stream != null)
                {
                    var serializer = new DataContractJsonSerializer(typeof(Request));

                    var results = (Request)serializer.ReadObject(stream);
                    if (results != null && results.Data != null && results.Data.Results != null)
                    {
                        this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            foreach(var hero in results.Data.Results)
                            {
                                this.listBoxHeros.Items.Add(hero);
                            }
                        }).AsTask().Wait();
                    }
                }
            },
            request);
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (MainPage), favorites);
        }

        private void Button_Remove_Favorite(object sender, RoutedEventArgs e)
        {
            int heroIdExclude = Int32.Parse((sender as Button).DataContext.ToString());
            this.favorites.Remove(heroIdExclude);
            this.listBoxHeros.Items.Clear();

            foreach (var heroId in favorites)
            {
                LoadHeroes(heroId);
            }
        }
    }
}
