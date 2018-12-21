using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runPredictor
{
    class Settings
    {
        public string Location;
        public string ZipCode;
        public int Hours;
        public int TempMax;
        public int TempMin;
        public int PrecipMax;
        public int WindMax; 

        public Settings ()
        {
            string[] settingsCapture = System.IO.File.ReadAllLines(@"F:\projects\runPredictor\runPredictor\source\settings.txt"); //need to update this manually for now

            ZipCode = settingsCapture[0].Substring(8);
            Int32.TryParse(settingsCapture[1].Substring(6), out Hours);
            Int32.TryParse(settingsCapture[2].Substring(8), out TempMax);
            Int32.TryParse(settingsCapture[3].Substring(8), out TempMin);
            Int32.TryParse(settingsCapture[4].Substring(10), out PrecipMax);
            Int32.TryParse(settingsCapture[5].Substring(8), out WindMax);
        }

        public void Test()
        {
            Console.WriteLine(ZipCode + " :zip code created."); //test userSettings capture
            Console.WriteLine(Hours + " :hours created.");
            Console.WriteLine(TempMax + " :maximum temperature created.");
            Console.WriteLine(TempMin + " :minimum temperature created.");
            Console.WriteLine(PrecipMax + " :precipitation created.");
            Console.WriteLine(WindMax + " :maximum wind created.");
            Console.ReadLine();
        }

    }
}


    




