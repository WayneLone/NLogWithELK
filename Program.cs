using Microsoft.Owin.Hosting;
using System;

namespace NLogWithELK
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Web API Service starting...");
            string baseAddress = "http://localhost:9000/";
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine($"Web API Service start successfully. The URI: {baseAddress}");
                Console.WriteLine("Press any key to stop.");
                Console.ReadKey();
            }
        }
    }
}
