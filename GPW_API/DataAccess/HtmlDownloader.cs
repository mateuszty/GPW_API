using System.Net;
using System.Threading.Tasks;

namespace GPW_API.DataAccess
{
    public static class HtmlDownloader
    {
        
        public static async Task<string> Download (string url)
        {

            string htmlCode;

            using (WebClient client = new WebClient())
            {
                htmlCode = await client.DownloadStringTaskAsync(url);
            }

            return htmlCode;

        }

    }
}
