using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Goggles.Model;
using HtmlAgilityPack;
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
        public ObservableCollection<SextantItem> SextantItems { get; set; }
        public GoogleObject GoogleObject { get; set; }

        public MainViewModel()
        {
            SextantItems = new ObservableCollection<SextantItem>();
            Search = new RelayCommand(SearchExecute);
        }

        private async void SearchExecute()
        {
            if (String.IsNullOrEmpty(Query)) return;
            var json = await GetAsync(String.Format("https://ajax.googleapis.com/ajax/services/search/web?v=1.0&rsz=large&start={0}&q={1}", 0, Query));
            GoogleObject = JsonConvert.DeserializeObject<GoogleObject>(json);

            foreach (var result in GoogleObject.ResponseData.Results)
                SextantItems.Add(new SextantItem(result));
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
    }
}