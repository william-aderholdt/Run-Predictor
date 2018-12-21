using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runPredictor
{
    class Settings
    {
        private string mLocation;
        private string mZipCode;
        private int mHours;
        private int mTempMax;
        private int mTempMin;
        private int mPrecipMax;
        private int mWindMax; 

        public Settings()
        {
            string[] settingsCapture = System.IO.File.ReadAllLines(@"F:\projects\Run-Predictor\source\settings.txt"); //need to update this manually for now

            this.mZipCode = settingsCapture[0].Substring(8);
            Int32.TryParse(settingsCapture[1].Substring(6), out this.mHours);
            Int32.TryParse(settingsCapture[2].Substring(8), out this.mTempMax);
            Int32.TryParse(settingsCapture[3].Substring(8), out this.mTempMin);
            Int32.TryParse(settingsCapture[4].Substring(10), out this.mPrecipMax);
            Int32.TryParse(settingsCapture[5].Substring(8), out this.mWindMax);
        }

        public string Location
        {
            get
            {
                return mLocation;
            }
            set
            {
                mLocation = value;
            }
        }

        public string ZipCode
        {
            get
            {
                return mZipCode;
            }
            set
            {
                mZipCode = value;
            }
        }

        public int Hours
        {
            get
            {
                return mHours;
            }
            set
            {
                mHours = value;
            }
        }

        public int TempMax
        {
            get
            {
                return mTempMax;
            }
            set
            {
                mTempMax = value;
            }
        }

        public int TempMin
        {
            get
            {
                return mTempMin;
            }
            set
            {
                mTempMin = value;
            }
        }

        public int PrecipMax
        {
            get
            {
                return mPrecipMax;
            }
            set
            {
                mPrecipMax = value;
            }
        }

        public int WindMax
        {
            get
            {
                return mWindMax;
            }
            set
            {
                mWindMax = value;
            }
        }



        public override string ToString()
        {
            return String.Format("Location:{0}, ZipCode:{1}, Hours:{2}, TempMax:{3}, TempMin:{4}, PrecipMax:{5}, WindMax:{6}",
                                this.Location, this.ZipCode, this.Hours, this.TempMax, this.TempMin, this.PrecipMax, this.WindMax);
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
            Console.ReadLine();
        }

    }
}


    




