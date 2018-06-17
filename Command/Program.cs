using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    abstract class Command
    {
        public abstract void Execute();
    }

    class BrowserCommand : Command
    {
        public string Url { get; set; }
        public DateTime Date { get; set; }
        public WebBrowserEngine Engine { get; set; } = new WebBrowserEngine();

        public override void Execute()
        {
            try
            {
                Engine.LoadPage(Url);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    class WebBrowserEngine
    {
        public void LoadPage(string url)
        {
            WebClient webClient = new WebClient();
            try
            {
                var page = webClient.DownloadString(url);
                Console.WriteLine(page);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    class WebBrowser
    {
        private List<Command> history = new List<Command>();
        private int historyPosition = -1;
        private WebBrowserEngine engine = new WebBrowserEngine();


        public void GoTo(string url)
        {
            var command = new BrowserCommand { Url = url, Date = DateTime.Now };
            try
            {
                command.Execute();
                history.Add(command);
                historyPosition++;
            }
            catch (Exception)
            {
                Console.WriteLine("Page not found!");
            }

        }

        public void GoBack()
        {
            if (historyPosition > 0)
            {
                historyPosition--;
                history[historyPosition].Execute();
            }
            else
            {
                Console.WriteLine("Can't go back!");
            }
        }

        public void GoForward()
        {
            if (historyPosition < history.Count - 1)
            {
                historyPosition++;
                history[historyPosition].Execute();
            }
            else
            {
                Console.WriteLine("Can't go forward!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var browser = new WebBrowser();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Enter address");
                Console.WriteLine("2. Go back");
                Console.WriteLine("3. Go forward");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Console.Write("Enter URL: ");
                        var url = Console.ReadLine();
                        browser.GoTo($"Pages/{url}.html");
                        break;
                    case ConsoleKey.D2:
                        browser.GoBack();
                        break;
                    case ConsoleKey.D3:
                        browser.GoForward();
                        break;
                    default:
                        break;
                }

                Console.ReadKey();
            }
        }
    }
}
