using HtmlAgilityPack;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading;
using System.Net;

namespace PWLab2
{
    public static class RequestCustom
    {

        public static void SearchGoogle(string query)
        {
            Process.Start(new ProcessStartInfo("http://google.com/search?q=" + query) { UseShellExecute = true });
        }
        public static void OpenSite(string adress)
        {
            Process.Start(new ProcessStartInfo(adress) { UseShellExecute = true });
        }

    }
}
