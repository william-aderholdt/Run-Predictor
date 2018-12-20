using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runPredictor
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<WeatherCardClass> weatherCardList = new List<WeatherCardClass>();
            Settings userSettings = new Settings();

            WebScrapeWeather(userSettings, weatherCardList); 
            BestRunTimes(userSettings, weatherCardList);
            PrintBestTimes(userSettings, weatherCardList);
            
        }

        static List<WeatherCardClass> WebScrapeWeather(Settings userSettings, List<WeatherCardClass> weatherCardList)
            //Function to scrape information from website and store in objects for later use.
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://weather.com/weather/hourbyhour/l/" + userSettings.ZipCode + ":4:US"); 
            //Captures all html from the website at the url.

            var timeData = doc.DocumentNode.SelectNodes("//div[@class='hourly-time']");
            var tempData = doc.DocumentNode.SelectNodes("//td[@class='temp']");
            var feelData = doc.DocumentNode.SelectNodes("//td[@class='feels']");
            var precipData = doc.DocumentNode.SelectNodes("//td[@class='precip']");
            var windData = doc.DocumentNode.SelectNodes("//td[@class='wind']");
            var locationData = doc.DocumentNode.SelectNodes("//div[@class='locations-title hourly-page-title']/h1");

            userSettings.Location = locationData[0].InnerText.Substring(0, locationData[0].InnerText.Length - 15);
            //Adds location to the userSettings object.

            int i = 0;
            while (i < timeData.Count)
            {
                WeatherCardClass weatherCard = new WeatherCardClass(timeData[i], tempData[i], feelData[i], precipData[i], windData[i]);
                //Creates objects for each row in the table.

                weatherCardList.Add(weatherCard);
                //Creates a list of the objects.

                i++;

            }

            return weatherCardList;
            

        }

        static List<WeatherCardClass> BestRunTimes(Settings userSettings, List<WeatherCardClass> weatherCardList)
            //Function to determine which times would be the best to run in.
        {
            foreach (var weatherCard in weatherCardList)
            {
                if (weatherCard.Temp > userSettings.TempMax ||
                    weatherCard.Temp < userSettings.TempMin ||
                    weatherCard.Wind > userSettings.WindMax ||
                    weatherCard.Precip > userSettings.PrecipMax)
                    //Algoithim to check weather data against user's settings.
                {
                    weatherCard.GoodRunTime = false;
                }
            }

            return weatherCardList;
        }
        
        static void PrintBestTimes(Settings userSettings, List<WeatherCardClass> weatherCardList)
            //Function to print the best running times.
        {
            Console.WriteLine("The best times to run today in " + userSettings.Location + " are:");
            foreach (var weatherCard in weatherCardList)
            {
                if (weatherCard.GoodRunTime == true)
                {
                    Console.WriteLine(weatherCard.Time);
                }

            }

            Console.ReadLine();
        }
    }


}
