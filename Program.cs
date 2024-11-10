using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Configuration;

namespace discord_tools
{
    internal class Program
    {
        static string Webhook = "empty";
        static string settingspath = "settings.txt";

        static void Main()
        {

            Console.Clear();
            Console.Title = "C# Tools";

            Banner();
            MenuOptions();

            ConsoleKeyInfo input = Console.ReadKey();
            char option = input.KeyChar;
            Console.WriteLine(option);

            switch (option)
            {
                case '1':
                    WebhookMessage();
                    return;

                case '2':
                    WebhookEmbed();
                    return;

                case '3':
                    meow();
                    return;

                case 'q':
                    Settings();
                    return;

                case 'e':
                    return;

            }
            
        }

        static void Banner()
        {
            Console.WriteLine(@"

    _________    _  _    ___________           .__          
    \_   ___ \__| || |__ \__    ___/___   ____ |  |   ______
    /    \  \/\   __   /   |    | /  _ \ /  _ \|  |  /  ___/
    \     \____|  ||  |    |    |(  <_> |  <_> )  |__\___ \ 
     \______  /_  ~~  _\   |____| \____/ \____/|____/____  >
            \/  |_||_|                                   \/ 

            ");
        }

        static void MenuOptions()
        {
            Console.WriteLine(@"
          __________________________
         /                          \
        | 1. Discord Webhook Sender  |
        | 2. Discord Embed Sender    |
        | 3. Meow                    |
        |                            |
        | Q. Settings                |
        | E. Exit                    |
         \__________________________/

");

            }

            static void SettingsOptions()
        {
            Console.WriteLine(@"
          __________________________
         /                          \
        | 1. Discord Webhook Link    |
        | 2. test 1                  |
        | 3. test 2                  |
        |                            |
        |                            |
        | Q. Back                    |
         \__________________________/

");
        }

        /// <summary>
        /// Settingssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
        /// </summary>
        static void Settings()
        {
            Console.Clear();
            Banner();
            SettingsOptions();

            ConsoleKeyInfo input = Console.ReadKey();
            char option = input.KeyChar;
            Console.WriteLine(option);

            switch (option)
            {
                case '1':
                    WebhookChanger1();
                    return;

                case '2':
                    return;

                case '3':
                    return;

                case 'q':
                    Main();
                    return;
            }
        }

        static void meow()
        {
            Console.WriteLine(@"
   |\---/|
   | ,_, |
    \_`_/-..----.
 ___/ `   ' ,""+ \  sk
(__...'   __\    |`.___.';
  (_,...'(_,.`__)/'.....+

");
            //Console.WriteLine("\nPress Any Key To Continue");
            Console.ReadKey();
            Main();
        }

        static void WebhookChanger1()
        {
            Console.Clear();
            Banner();

            Console.WriteLine($@"
          __________________________
         /                          \
        | Current URL: {Webhook}
        | Do You Wish To Change?     | Bye Bye Border
        |                            |
        | 1. Yes                     |
        | 2. No                      |
        |                            |
         \__________________________/

");

            ConsoleKeyInfo input = Console.ReadKey();
            char option = input.KeyChar;
            Console.WriteLine(option);

            switch (option)
            {
                case '1':
                    WebhookChanger2();
                    return;

                case '2':
                    Settings();
                    return;

            }
        }

        static void WebhookChanger2()
        {
            Console.Clear();
            Banner();

            Console.Write("Enter New Webhook URL: ");
            Webhook = Console.ReadLine();
            Console.WriteLine("\nPress Any Key To Continue");
            Console.ReadKey();
            Main();
        }


        /// <summary>
        /// Functionsssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
        /// </summary>



        static void WebhookMessage()
        {
            Console.Clear();
            Banner();
            Console.WriteLine(" ____");
            Console.WriteLine(" /   Type a message or type Q to go back to the main menu");
            Console.WriteLine("|");
            Console.Write(@" \___ ");
            string message = Console.ReadLine();

            string json = $"{{\"content\":\"{message}\"}}";

            if (IsValidUrl(Webhook))
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    client.PostAsync(Webhook, content);

                    Console.WriteLine("Press Any Key To Continue");
                    Console.ReadKey();
                    Main();
                }
            }
            else if (message == "q")
            {
                Main();
            }
            else
            {
            
                Console.WriteLine("Webhook was invalid or not set correctly in settings");
                Console.WriteLine("Press Any Key To Continue");
                Console.ReadKey();
                Main();
            
            }
        }

        static void WebhookEmbed()
        {
            Console.Clear();
            Banner();

            Console.WriteLine(" ____");
            Console.WriteLine(" /   Type a title or type Q to go back to the main menu");
            Console.WriteLine("|");
            Console.Write(@" \___ ");
            string title = Console.ReadLine();

            Console.WriteLine("\n ____");
            Console.WriteLine(" /   Type a message");
            Console.WriteLine("|");
            Console.Write(@" \___ ");
            string description = Console.ReadLine();

            string json = $"{{\"embeds\":[{{\"title\":\"{title}\",\"description\":\"{description}\"}}]}}";


            if (IsValidUrl(Webhook))
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    client.PostAsync(Webhook, content);

                    Console.WriteLine("Press Any Key To Continue");
                    Console.ReadKey();
                    Main();
                }
            }
            else if (title == "q")
            {
                Main();
            }
            else
            {

                Console.WriteLine("Webhook was invalid or not set correctly in settings");
                Console.WriteLine("Press Any Key To Continue");
                Console.ReadKey();
                Main();

            }
        }

        static bool IsValidUrl(string url)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult))
            {
                return uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps;
            }

            return false;
        }

    }
}
