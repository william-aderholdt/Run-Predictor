using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runPredictor
{
    class WeatherCardClass
    {
        private string mWeatherCardTime;
        private int mWeatherCardTemp;
        private int mWeatherCardTempFeel;
        private int mWeatherCardPrecip;
        private int mWeatherCardWind;
        private bool mWeatherCardGoodRunTime;

        public WeatherCardClass(HtmlAgilityPack.HtmlNode TimeData, HtmlAgilityPack.HtmlNode TempData, HtmlAgilityPack.HtmlNode FeelData,
                                HtmlAgilityPack.HtmlNode PrecipData, HtmlAgilityPack.HtmlNode WindData)
            
        {
            this.mWeatherCardTime = TimeData.InnerText.Trim();
            Int32.TryParse(TempData.InnerText.Substring(0, 2), out this.mWeatherCardTemp);
            Int32.TryParse(FeelData.InnerText.Substring(0, 2), out this.mWeatherCardTempFeel);
            Int32.TryParse(PrecipData.InnerText.Substring(0, PrecipData.InnerText.Length - 1), out this.mWeatherCardPrecip);
            Int32.TryParse(WindData.InnerText.Substring(WindData.InnerText.Length -6, 2), out this.mWeatherCardWind);
            this.mWeatherCardGoodRunTime = true;
         
        }

        public string WeatherCardTime
        {
            get
            {
                return mWeatherCardTime;
            }
            set
            {
                this.mWeatherCardTime = value;
            }
        }

        public int WeatherCardTemp
        {
            get
            {
                return mWeatherCardTemp;
            }
            set
            {
                this.mWeatherCardTemp = value;
            }
        }

        public int WeatherCardTempFeel
        {
            get
            {
                return mWeatherCardTempFeel;
            }
            set
            {
                this.mWeatherCardTempFeel = value;
            }
        }

        public int WeatherCardPrecip
        {
            get
            {
                return mWeatherCardPrecip;
            }
            set
            {
                this.mWeatherCardPrecip = value;
            }
        }

        public int WeatherCardWind
        {
            get
            {
                return mWeatherCardWind;
            }
            set
            {
                this.mWeatherCardWind = value;
            }
        }

        public bool WeatherCardGoodRunTime
        {
            get
            {
                return mWeatherCardGoodRunTime;
            }
            set
            {
                this.mWeatherCardGoodRunTime = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Time:{0}, Temp:{1}, TempFeel:{2}, Precip:{3}, Wind:{4}, GoodRunTime:{5}",
                                this.WeatherCardTime, this.WeatherCardTemp, this.WeatherCardTempFeel, 
                                this.WeatherCardPrecip, this.WeatherCardWind, this.WeatherCardGoodRunTime);
        }

        
        public void Print()
        {
            Console.WriteLine(this.ToString());
            Console.ReadLine();
        }

    }
}
