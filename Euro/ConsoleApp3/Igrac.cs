using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Igrac
    {
        static int _id { get; set; } = 1;
        string _ID { get; set; }
        string _imePrezime { get; set; }
        List<Pogodak> _pogoci { get; set; }


        public string KreirajID()
        {
            return Program.GenerisiID(_imePrezime, _id++);
        }


        public Igrac(string imePrezime)
        {
            _imePrezime = imePrezime;
            _ID = KreirajID();
            _pogoci = new List<Pogodak>();
        }
        public Igrac(Igrac obj)
        {
            _imePrezime=obj._imePrezime;
            _ID=obj._ID;
            _pogoci = obj._pogoci;
        }

        public static bool operator==(Igrac i1,Igrac i2)
        {
            return i1._ID==i2._ID;
        }
        public static bool operator !=(Igrac i1,Igrac i2)
        {
            return !(i1==i2);  
        }

        

        public bool AddGol(Pogodak pogodak)
        {
            for (int i = 0; i < _pogoci.Count; i++)
            {
                if (_pogoci[i].GetNapomena() == pogodak.GetNapomena())
                    return false;
            }
            _pogoci.Add(new Pogodak(pogodak));
            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{_ID} ---> {_imePrezime}");
            for (int i = 0; i < _pogoci.Count; i++)
            {
                sb.AppendLine(_pogoci[i].ToString());

            }
            return sb.ToString();
        }

        public string GetID()
        {
            return _ID;
        }
        public List<Pogodak> GetPogoci()
        {
            return _pogoci;
        }
        public string GetImePrezime()
        {
            return _imePrezime;
        }


    }
}
