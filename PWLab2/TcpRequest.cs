using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PWLab2
{
    public static class TcpRequest
    {
        public static List<HtmlNode> MakeRequest(string adress)
        {
            var list = new List<string>();

            using (var client = new TcpClient(adress, 80))
            {
                using (var stream = client.GetStream())
                using (var writer = new StreamWriter(stream))
                using (var reader = new StreamReader(stream))
                {
                    writer.AutoFlush = true;
                    // Send request headers
                    writer.WriteLine("GET / HTTP/1.1");
                    writer.WriteLine("Host:" + adress + ":80");
                    writer.WriteLine("Connection: close");
                    writer.WriteLine();
                    var str = reader.ReadToEnd();
                    // Read the response from server
                    var result = str;

                    if (str != null )
                    {
                        return ParseHtml(str) ;
                    }
                    return null;
                }
            }
        }
        private static List<HtmlNode> ParseHtml(string html)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var programmerLinks = htmlDoc.DocumentNode.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "").Contains("g")).Take(10).ToList();
            return programmerLinks;
        }
    }
}
