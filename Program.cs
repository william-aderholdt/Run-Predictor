using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runPredictor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userSettings = System.IO.File.ReadAllLines(@"C:\Users\David\Documents\projects\runPredictor\settings.txt");
            foreach(var item in userSettings) //remove later
            {
                Console.WriteLine(item.ToString());
            }

            WebScrapeWeather(userSettings);
        }

        static void WebScrapeWeather(string[] userSettings)
        {
            Console.WriteLine(userSettings[0].Substring(9));
            Console.ReadLine(); //remove later
            // 'https://weather.com/weather/hourbyhour/l/ + userSettings[0] +:4:US'
        }

    }


}
