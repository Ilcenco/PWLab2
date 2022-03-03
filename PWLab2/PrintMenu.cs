using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWLab2
{
    public class PrintMenu
    {
        public void StartMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Main Menu v1.01");
            Console.WriteLine("Type a command to execute");
            Console.WriteLine("Type go2web -h for help");

            var command = Console.ReadLine();

            if(command == "go2web -h")
            {
                HelpMenu();
            }
            else if(command == null)
            {
                StartMenu();
            }
            else if(command.Contains("go2web -s"))
            {
                Console.Clear();
                Console.WriteLine("Establishing connection...");
                Thread.Sleep(2000);
                // establish connection tcp
                Console.WriteLine("Connection established, oppening browser with results");
                Thread.Sleep(2000);

                var term = command.Split("-s ")[1];
                RequestCustom.SearchGoogle(term);
            }
            else if(command.Contains("go2web -u"))
            {
                Console.Clear();
                Console.WriteLine("Establishing connection...");
                Thread.Sleep(2000);
                // establish connection tcp
                var term = command.Split("-u ")[1];
                if (TcpRequest.MakeRequest(term))
                {
                    Console.WriteLine("Connection established, oppening browser with results");
                }
                else
                {
                    Console.WriteLine("Connection didnt establish");

                }
                Thread.Sleep(2000);
                RequestCustom.OpenSite(term);
                

            }
        }
        public void HelpMenu()
        {
            Console.Clear();
            Console.WriteLine("go2web -u <URL> # make an HTTP request to URL and print the response");
            Console.WriteLine("go2web -s <search-term> # search the term in browser and open results");
            Console.WriteLine("Type go2web -main # to go to main menu");

            var command = Console.ReadLine();

            if (command == "go2web -main")
            {
                StartMenu();
            }
        }


    }
}
