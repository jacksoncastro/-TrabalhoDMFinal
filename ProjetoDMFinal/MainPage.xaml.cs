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
using System.Text;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace ProjetoDMFinal
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.LoadCustomers();
        }

        public void LoadCustomers()
        {
            string url = "https://gateway.marvel.com/v1/public/characters?nameStartsWith=spider&orderBy=name&apikey=a2d01370e4278b621c371892e9041094&ts=1&hash=0137664330e5b71ccbdff2421cafa4d7";
            Uri uri = new Uri(url, UriKind.Absolute);
            var request = (HttpWebRequest) WebRequest.Create(uri);
            request.Method = "GET";
            request.Accept = "application/json";
            request.BeginGetResponse((result) =>
            {
                var req = (HttpWebRequest) result.AsyncState;
                var response = req.EndGetResponse(result);
                var stream = response.GetResponseStream();
                if (stream != null)
                {
                    var serializer = new DataContractJsonSerializer(typeof(Request));

                    var results = (Request) serializer.ReadObject(stream);
                    if (result != null) { 
                    }
                    //Customers.Clear();
                    //foreach (Customer customer in results)
                    //{
                    //    Customers.Add(customer);
                    //}
                }
            },
            request);
        }

    }
}
