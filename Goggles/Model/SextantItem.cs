using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Goggles.Model
{
    public class SextantItem
    {
        public string UnescapedUrl { get; set; }
        public string Url { get; set; }
        public string VisibleUrl { get; set; }
        public string CacheUrl { get; set; }
        public string Title { get; set; }
        public string TitleNoFormatting { get; set; }
        public string Content { get; set; }
        public string ImageSource { get; set; }

        public SextantItem()
        {
        }

        // mapper ? heritage ? reflection ?
        public SextantItem(Result result)
        {
            UnescapedUrl = result.UnescapedUrl;
            Url = result.Url;
            VisibleUrl = result.VisibleUrl;
            CacheUrl = result.CacheUrl;
            Title = result.Title;
            TitleNoFormatting = result.TitleNoFormatting;
            Content = result.Content;
            ImageSource = GetImageFromHtml(result.UnescapedUrl);
        }

        private static string GetImageFromHtml(string url)
        {
            var htmlDocument = new HtmlWeb().Load(url);
            var zelda = new Collection<string>();
            foreach (var link in htmlDocument.DocumentNode.SelectNodes("//img/@src"))
                zelda.Add(link.Attributes["src"].Value);

            var s = (from link in zelda
                     where !String.IsNullOrWhiteSpace(link)
                     select link).FirstOrDefault();

            if (s != null && s.StartsWith("http"))
                return s;
            if (s != null && s.StartsWith("//"))
                return "http:" + s;
            var index = url.LastIndexOf("/", StringComparison.Ordinal);
            if (index > 0)
                s = (index > 0) ? (url.Substring(0, index) + s) : "http://img.xooimage.com/files105/8/2/6/131118_jdgbaffe-43f39d2.jpg";
            return s;
        }
    }
}
