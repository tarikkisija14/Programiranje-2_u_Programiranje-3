using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Vrijeme
    {
        public int _sat { get; set; }
        public int _minuta { get; set; }
        public int _sekunda { get; set; }

        public Vrijeme(int sat=10,int minuta=0,int sekunda=0)
        {
            _sat = sat;
            _minuta = minuta; 
            _sekunda = sekunda;
        }

        public Vrijeme(Vrijeme obj)
        {
            _sat = obj._sat;
            _minuta=obj._minuta;
            _sekunda=obj._sekunda;
        }

        public int GetV()
        { 
         return _sat*3600+_minuta*60+_sekunda;
        
        }

        public static bool operator==(Vrijeme v1,Vrijeme v2)
        {
            if(ReferenceEquals(v1,null))
            {
              return ReferenceEquals(v2,null);
            }
            return v1.GetV() == v2.GetV();
        }

        public static bool operator !=(Vrijeme v1, Vrijeme v2)
        {
            return !(v1 == v2);
        }

        public static bool operator < (Vrijeme v1,Vrijeme v2)
        {
            return v1.GetV() < v2.GetV();
        }
        public static bool operator >(Vrijeme v1, Vrijeme v2)
        {
            return v1.GetV() > v2.GetV();
        }

        public static bool operator <=(Vrijeme v1, Vrijeme v2)
        {
            return v1.GetV() <= v2.GetV();
        }

        public static bool operator >=(Vrijeme v1, Vrijeme v2)
        {
            return v1.GetV() >= v2.GetV();
        }

        public override string ToString()
        {
            return $"{_sat} : {_minuta} : {_sekunda}";
        }

    }
}
