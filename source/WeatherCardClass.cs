using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runPredictor
{
    class WeatherCardClass
    {
        public string Time;
        public int Temp;
        public int TempFeel;
        public int Precip;
        public int Wind;
        public bool GoodRunTime;

        public WeatherCardClass(HtmlAgilityPack.HtmlNode timeData, HtmlAgilityPack.HtmlNode tempData, 
                                HtmlAgilityPack.HtmlNode feelData, HtmlAgilityPack.HtmlNode precipData, 
                                HtmlAgilityPack.HtmlNode windData)
        {
            Time = timeData.InnerText.Trim();
            Int32.TryParse(tempData.InnerText.Substring(0, 2), out Temp);
            Int32.TryParse(feelData.InnerText.Substring(0, 2), out TempFeel);
            Int32.TryParse(precipData.InnerText.Substring(0, precipData.InnerText.Length - 1), out Precip);
            Int32.TryParse(windData.InnerText.Substring(windData.InnerText.Length -6, 2), out Wind);
            GoodRunTime = true;
         
        }

        public void Test()
        {
            Console.WriteLine(Time);
            Console.WriteLine(Temp);
            Console.WriteLine(TempFeel);
            Console.WriteLine(Precip);
            Console.WriteLine(Wind);
            Console.WriteLine(GoodRunTime);
            Console.ReadLine();
        }
    }
}
