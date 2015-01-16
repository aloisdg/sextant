using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Dynamic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Goggles.Model;
using Newtonsoft.Json;

// http://stackoverflow.com/q/27937040/1248177
// http://www.searchr.it/
// https://developers.google.com/api-client-library/dotnet/get_started

namespace Goggles.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand Search { get; private set; }

        public string Query { get; set; }
        public ObservableCollection<Result> Results { get; set; }
        public GoogleObject GoogleObject { get; set; }

        public MainViewModel()
        {
            Results = new ObservableCollection<Result>();
            Search = new RelayCommand(SearchExecute);
        }

        private async void SearchExecute()
        {
            if (String.IsNullOrEmpty(Query)) return;
            var json = await GetAsync(String.Format("https://ajax.googleapis.com/ajax/services/search/web?v=1.0&rsz=large&start={0}&q={1}", 0, Query));
            GoogleObject = JsonConvert.DeserializeObject<GoogleObject>(json);

            foreach (var result in GoogleObject.ResponseData.Results)
                Results.Add(result);
        }

        private static async Task<string> GetAsync(string url)
        {
            string result;
            using (var client = new HttpClient())
            {
                result = await client.GetStringAsync(url);
            }
            return result;
        }

        //private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        //{
        //    var query = "(404)8271500";

        //    //var nbPages= JsonConvert.DeserializeObject<GoogleObject>(json).ResponseData.Cursor.Pages.Length;

        //    for (int i = 0; i < 4; i++)
        //    {
        //        //string json = "";
        //        //using (var client = new HttpClient())
        //        //{
        //        //    json = await client.GetStringAsync(String.Format("https://ajax.googleapis.com/ajax/services/search/web?v=1.0&rsz=large&start={0}&q={1}", i * 8, query));
        //        //}

        //        //var googleObject = JsonConvert.DeserializeObject<GoogleObject>(json);
        //        //Results = new ObservableCollection<Result>(googleObject.ResponseData.Results);
        //        //foreach (var item in googleObject.ResponseData.Results)
        //        //{
        //        //    Results.Add(new Result{});
        //        //    Console.WriteLine(item.Title);
        //        //    Console.WriteLine(item.Url);
        //        //}
        //        Results.Add(new Result { Title = (i * 213897).ToString(), Url = "https://ajax.googleapis.com/ajax/services/search/web?v=1." });
        //    }
        //}
    }
}