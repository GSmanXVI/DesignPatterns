using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            WebBrowserEngine engine = new WebBrowserEngine();
            WebBrowserFavoritesStorage favoritesStorage = new WebBrowserFavoritesStorage();
            WebBrowser browser = new WebBrowser(engine, favoritesStorage);

            int menuSelection;
            while (true)
            {
                Console.WriteLine("1 - Go to url");
                Console.WriteLine("2 - Add to favorites");
                menuSelection = int.Parse(Console.ReadLine());
                Console.Write(":");

                switch (menuSelection)
                {
                    case 1:
                        browser.GoToPage();
                        break;

                    case 2:
                        browser.AddToFavorites();
                        break;

                    default:
                        Console.WriteLine("Error!");
                        break;
                }
            }
        }
    }

    //UI
    class WebBrowser
    {
        private readonly WebBrowserEngine engine;
        private readonly WebBrowserFavoritesStorage favoritesStorage;

        public WebBrowser(WebBrowserEngine engine, WebBrowserFavoritesStorage favoritesStorage)
        {
            this.engine = engine;
            this.favoritesStorage = favoritesStorage;
        }

        public void GoToPage()
        {
            Console.WriteLine("Enter URL:");
            var url = Console.ReadLine();

            ICommand command = new GoToPageCommand(engine, url);
            command.Execute();
        }

        public void AddToFavorites()
        {
            Console.WriteLine("Enter URL:");
            var url = Console.ReadLine();
            Console.WriteLine("Enter title:");
            var title = Console.ReadLine();

            ICommand command = new AddToFavoritesCommand(favoritesStorage, url, title);
            command.Execute();
        }
    }

    //Base command
    interface ICommand
    {
        void Execute();        
    }

    class GoToPageCommand : ICommand
    {
        private WebBrowserEngine reciever;
        private string url;

        public GoToPageCommand(WebBrowserEngine reciever, string url)
        {
            this.url = url;
            this.reciever = reciever;
        }

        public void Execute()
        {
            var html = reciever.LoadWebPage(url);
            Console.WriteLine(html);
        }
    }

    class AddToFavoritesCommand : ICommand
    {
        private WebBrowserFavoritesStorage reciever;
        private string url;
        private string title;

        public AddToFavoritesCommand(WebBrowserFavoritesStorage reciever, string url, string title)
        {
            this.url = url;
            this.title = title;
            this.reciever = reciever;
        }

        public void Execute()
        {
            reciever.Add(new Favorite { Title = title, Url = url });
        }
    }

    //Buisnes logic
    class WebBrowserEngine
    {
        public string LoadWebPage(string url)
        {
            WebClient webClient = new WebClient();
            var html = webClient.DownloadString(url);
            return html;
        }
    }

    //Buisnes logic
    class WebBrowserFavoritesStorage
    {
        public List<Favorite> Favorites { get; set; } = new List<Favorite>();

        public void Add(Favorite favorite)
        {
            Favorites.Add(favorite);
        }
    }

    class Favorite
    {
        public string Title { get; set; }
        public string Url { get; set; }
    }
}





//Command
//GoToPageCommand
//AddToFavoritesCommand

//WebBrowserRenderingEngine
//WebBrowserFavoritesStorage

//WebBrowser







//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace Command
//{
//    abstract class Command
//    {
//        public abstract void Execute();
//    }

//    class BrowserCommand : Command
//    {
//        public string Url { get; set; }
//        public DateTime Date { get; set; }
//        public WebBrowserEngine Engine { get; set; } = new WebBrowserEngine();

//        public override void Execute()
//        {
//            try
//            {
//                Engine.LoadPage(Url);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//    }

//    class WebBrowserEngine
//    {
//        public void LoadPage(string url)
//        {
//            WebClient webClient = new WebClient();
//            try
//            {
//                var page = webClient.DownloadString(url);
//                Console.WriteLine(page);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//    }

//    class WebBrowser
//    {
//        private List<Command> history = new List<Command>();
//        private int historyPosition = -1;
//        private WebBrowserEngine engine = new WebBrowserEngine();


//        public void GoTo(string url)
//        {
//            var command = new BrowserCommand { Url = url, Date = DateTime.Now };
//            try
//            {
//                command.Execute();
//                history.Add(command);
//                historyPosition++;
//            }
//            catch (Exception)
//            {
//                Console.WriteLine("Page not found!");
//            }

//        }

//        public void GoBack()
//        {
//            if (historyPosition > 0)
//            {
//                historyPosition--;
//                history[historyPosition].Execute();
//            }
//            else
//            {
//                Console.WriteLine("Can't go back!");
//            }
//        }

//        public void GoForward()
//        {
//            if (historyPosition < history.Count - 1)
//            {
//                historyPosition++;
//                history[historyPosition].Execute();
//            }
//            else
//            {
//                Console.WriteLine("Can't go forward!");
//            }
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var browser = new WebBrowser();

//            while (true)
//            {
//                Console.Clear();
//                Console.WriteLine("1. Enter address");
//                Console.WriteLine("2. Go back");
//                Console.WriteLine("3. Go forward");

//                switch (Console.ReadKey(true).Key)
//                {
//                    case ConsoleKey.D1:
//                        Console.Write("Enter URL: ");
//                        var url = Console.ReadLine();
//                        browser.GoTo($"Pages/{url}.html");
//                        break;
//                    case ConsoleKey.D2:
//                        browser.GoBack();
//                        break;
//                    case ConsoleKey.D3:
//                        browser.GoForward();
//                        break;
//                    default:
//                        break;
//                }

//                Console.ReadKey();
//            }
//        }
//    }
//}