using Microsoft.Owin.Hosting;
using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:8080/";
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine($"The Server is Running in {url}");
                Console.ReadLine();
            }

        }
    }
}
