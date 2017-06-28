using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LakewoodScoop.Api
{
    public class LkwdScoopScraper
    {
        public IEnumerable<LkwdScoopItem> GetItems ()
        {
            using (var client = new WebClient())
            {
                client.Headers["User-Agent"] = "HELLO!!";
                string html = client.DownloadString("http://www.thelakewoodscoop.com/");
                var parser = new HtmlParser();
                var document = parser.Parse(html);
                var divs = document.QuerySelectorAll("div.post");
                List<LkwdScoopItem> result = new List<LkwdScoopItem>();
                foreach (var div in divs)
                {
                    LkwdScoopItem item = new LkwdScoopItem();
                    item.Title = div.QuerySelector("h2").TextContent;
                    item.DatePosted = div.QuerySelector(".postmetadata-top").TextContent;
                    var image = div.QuerySelector("img");
                    if (image != null)
                    {
                        item.Image = div.QuerySelector("img").GetAttribute("src");
                    }
                    item.Text = div.QuerySelector("p").TextContent;
                    item.Url = div.QuerySelector("a").GetAttribute("href");
                    result.Add(item);
                }

                return result;
            }
        }
    }
}
