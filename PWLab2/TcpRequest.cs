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
        public static bool MakeRequest(string adress)
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
                    if (str != null )
                    {
                        return true;
                    }
                    return false;
                }
            }
        }
    }
}
