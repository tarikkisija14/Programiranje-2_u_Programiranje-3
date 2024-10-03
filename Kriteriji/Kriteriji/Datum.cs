using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kriteriji
{
    public class Datum
    {
        private int _dan { get; set; }
        private int _mjesec { get; set; }
        private int _godina { get; set; }

        public Datum(int dan = 1, int mjesec = 1, int godina = 2000)
        {
            _dan = dan;
            _mjesec = mjesec;
            _godina = godina;
        }
        public Datum(Datum obj)
        {
            _dan = obj._dan;
            _mjesec = obj._mjesec;
            _godina = obj._godina;
        }

        public int GetDays()
        {
            return _godina * 365 + _mjesec * 30 + _dan;
        }

        public static bool operator ==(Datum d1, Datum d2)
        {
            return d1.GetDays() == d2.GetDays();
        }
        public static bool operator !=(Datum d1, Datum d2)
        {
            return !(d1 == d2);
        }

        public static bool operator <(Datum d1, Datum d2)
        {
            return d1.GetDays() < d2.GetDays();
        }
        public static bool operator >(Datum d1, Datum d2)
        {
            return d1.GetDays() > d2.GetDays();
        }

        public static int operator -(Datum d1, Datum d2)
        {
            return Math.Abs(d1.GetDays() - d2.GetDays());

        }

        public override string ToString()
        {
            StringBuilder COUT = new StringBuilder();

            COUT.AppendLine($"{_dan}.{_mjesec}.{_godina}");
            return COUT.ToString();
        }
    }
}