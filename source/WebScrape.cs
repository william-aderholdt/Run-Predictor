using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runPredictor
{
    class WebScrape
    {

        private HtmlAgilityPack.HtmlNodeCollection mTimeData;
        private HtmlAgilityPack.HtmlNodeCollection mTempData;
        private HtmlAgilityPack.HtmlNodeCollection mFeelData;
        private HtmlAgilityPack.HtmlNodeCollection mPrecipData;
        private HtmlAgilityPack.HtmlNodeCollection mWindData;
        private HtmlAgilityPack.HtmlNodeCollection mLocationData;

        /*
            Constuctor: Scrapes weather.com's hour-by-hour data for time, temperature, temperature feeling, precipation %, wind speed,
            and location.  Location comes from the zip code provided by the user.

            Try/Catch: Pulls data based on zip code provided by the user.

            Attributes: Selects nodes of HTML by specifically looking for class names.

            userSettings.Location: This pulls city and state from weather.com based on zip code provided by the user.
        */
        public WebScrape(ref Settings lUserSettings)
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            try
            {
                doc = web.Load("https://weather.com/weather/hourbyhour/l/" + lUserSettings.ZipCode + ":4:US");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            this.mTimeData = doc.DocumentNode.SelectNodes("//div[@class='hourly-time']");
            this.mTempData = doc.DocumentNode.SelectNodes("//td[@class='temp']");
            this.mFeelData = doc.DocumentNode.SelectNodes("//td[@class='feels']");
            this.mPrecipData = doc.DocumentNode.SelectNodes("//td[@class='precip']");
            this.mWindData = doc.DocumentNode.SelectNodes("//td[@class='wind']");
            this.mLocationData = doc.DocumentNode.SelectNodes("//div[@class='locations-title hourly-page-title']/h1");

            lUserSettings.Location = this.mLocationData[0].InnerText.Substring(0, this.mLocationData[0].InnerText.Length - 15);

        }

        public HtmlAgilityPack.HtmlNodeCollection TimeData
        {
            get
            {
                return this.mTimeData;
            }
            set
            {
                this.mTimeData = value;
            }
        }

        public HtmlAgilityPack.HtmlNodeCollection TempData
        {
            get
            {
                return this.mTempData;
            }
            set
            {
                this.mTempData = value;
            }
        }

        public HtmlAgilityPack.HtmlNodeCollection FeelData
        {
            get
            {
                return this.mFeelData;
            }
            set
            {
                this.mFeelData = value;
            }
        }

        public HtmlAgilityPack.HtmlNodeCollection PrecipData
        {
            get
            {
                return this.mPrecipData;
            }
            set
            {
                this.mPrecipData = value;
            }
        }

        public HtmlAgilityPack.HtmlNodeCollection WindData
        {
            get
            {
                return this.mWindData;
            }
            set
            {
                this.mWindData = value;
            }
        }

        public HtmlAgilityPack.HtmlNodeCollection LocationData
        {
            get
            {
                return this.mLocationData;
            }
            set
            {
                this.mLocationData = value;
            }
        }

    }
}
