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
            List<WeatherCardClass> lWeatherCardList = new List<WeatherCardClass>();
            Settings lUserSettings = new Settings();
            WebScrape lWebscrapeData = new WebScrape(ref lUserSettings);

            MakeWeatherCards(ref lUserSettings, ref lWeatherCardList, ref lWebscrapeData); //need to make something to store the data
            BestRunTimes(ref lUserSettings, ref lWeatherCardList);
            PrintBestTimes(ref lUserSettings, ref lWeatherCardList);
            
        }


        /*
          Function makes the objects to store weather information for each point in time using information from the 
          user settings and thepreviously web scraped data.

          For Loop: Iterates through every row of data captured from weather.com's hour-by-hour forecast. Adds weather 
          card to the list for later retrieval.

          Return: Returns the list of weather cards created.
        */
        private static List<WeatherCardClass> MakeWeatherCards(ref Settings lUserSettings, ref List<WeatherCardClass> lWeatherCardList,
                                                                ref WebScrape lWebscrapeData)

        {

            for (int lTimeDataIndex = 0; lTimeDataIndex < lWebscrapeData.TimeData.Count(); ++lTimeDataIndex)
            {
                WeatherCardClass weatherCard = new WeatherCardClass(lWebscrapeData.TimeData[lTimeDataIndex], 
                                                                    lWebscrapeData.TempData[lTimeDataIndex],
                                                                    lWebscrapeData.FeelData[lTimeDataIndex], 
                                                                    lWebscrapeData.PrecipData[lTimeDataIndex], 
                                                                    lWebscrapeData.WindData[lTimeDataIndex]);
                lWeatherCardList.Add(weatherCard);

            };

            return lWeatherCardList;
            

        }

        /*
          Function to determine which times would be the best to run in.  Uses an if statement to compare times weather attributes.
        */
        static void BestRunTimes(ref Settings lUserSettings, ref List<WeatherCardClass> lWeatherCardList)

        {
            foreach (var weatherCard in lWeatherCardList)
            {
                if (weatherCard.WeatherCardTemp > lUserSettings.TempMax ||
                    weatherCard.WeatherCardTemp < lUserSettings.TempMin ||
                    weatherCard.WeatherCardWind > lUserSettings.WindMax ||
                    weatherCard.WeatherCardPrecip > lUserSettings.PrecipMax)
                {
                    weatherCard.WeatherCardGoodRunTime = false;
                }
            }

        }


        /*
         * Function to print the best running times.
         */
        static void PrintBestTimes(ref Settings lUserSettings, ref List<WeatherCardClass> lWeatherCardList)
        {
            Console.WriteLine("The best times to run today in " + lUserSettings.Location + " are:");
            foreach (var weatherCard in lWeatherCardList)
            {
                if (weatherCard.WeatherCardGoodRunTime == true)
                {
                    Console.WriteLine(weatherCard.WeatherCardTime);
                }

            }

            Console.ReadLine();
        }
    }


}
