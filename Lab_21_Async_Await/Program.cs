using System;
using System.IO;
using System.Threading;
using System.Net;
using System.Diagnostics;


namespace Lab_21_Async_Await
{
    class Program
    {
        static Uri uri = new Uri("https://www.bbc.co.uk/sport");
        static void Main(string[] args)
        {
            //Main method here 
            File.WriteAllText("data.csv", "ID,Name,Age");
            File.AppendAllText("data.csv", "\n1, Tom, 21");
            File.AppendAllText("data.csv", "\n2, James, 22");
            File.AppendAllText("data.csv", "\n3, Mike, 23");


            GetWebPageSync();
            //syncyMethod : wait for it 

            ReadDataSync();
            GetWebPageAync();

            // AsyncMethod: Dont wait for it


            ReadDataAsync();
            Console.WriteLine("Code has finished");
            Console.ReadLine();

          


        }

        static void ReadDataSync()
        {
            var output = File.ReadAllText("data.csv");
           // Thread.Sleep(5000);
            Console.WriteLine("\nSync\n");
            Console.WriteLine(output);

        }

         static async void ReadDataAsync()
         {
            var output = await File.ReadAllTextAsync("data.csv");
           // Thread.Sleep(5000);
            Console.WriteLine("\nAync\n");
            Console.WriteLine(output);

         }

        static void GetWebPageSync()
        {
          
            

            var webClient = new WebClient { Proxy = null };
            webClient.DownloadFile(uri, "localPage.html");
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "localPage.html");
        }

         async static void GetWebPageAync()
         {

            
          

            var webClient = new WebClient { Proxy = null };
            var werbpage =  webClient.DownloadStringTaskAsync(uri);
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "localPage.html");

         }
    }
}
