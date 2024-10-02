using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Predmeti
{
    public class Ispit
    {
        private Predmet _predmet { get; set; }
        private List<Pitanje> _pitanjaOdgovori { get; set; }

        public Ispit(Predmet predmet = Predmet.UIT)
        {
            _predmet = predmet;
            _pitanjaOdgovori = new List<Pitanje>();
        }
        public Ispit(Ispit obj)
        {
            _predmet = obj._predmet;
            _pitanjaOdgovori = new List<Pitanje>(obj._pitanjaOdgovori);
        }

        public float ProsjekIspit()
        {
            float sum = 0.0f;
            if (_pitanjaOdgovori.Count == 0) return 0.0f;
            for (int i = 0; i < _pitanjaOdgovori.Count; i++)
            {
                sum += _pitanjaOdgovori[i].ProsjekPitanje();
            }
            return sum / _pitanjaOdgovori.Count();
        }

        public static bool operator ==(Ispit i1, Ispit i2)
        {

            if (i1._predmet != i2._predmet) return false;
            if (i1._pitanjaOdgovori.Count != i2._pitanjaOdgovori.Count) return false;
            for (int i = 0; i < i1._pitanjaOdgovori.Count; i++)
            {
                if (i1._pitanjaOdgovori[i] != i2._pitanjaOdgovori[i]) return false;
            }
            return true;

        }
        public static bool operator !=(Ispit i1, Ispit i2)
        {
            return !(i1 == i2);
        }

        public List<Pitanje> GetPitanjaOdgovore()
        {
            return _pitanjaOdgovori;
        }
        public Predmet GetPredmet()
        { return _predmet; }

        public override string ToString()
        {
            StringBuilder COUT = new StringBuilder();

            COUT.AppendLine($"Predmet: {_predmet}");
            for (int i = 0; i < _pitanjaOdgovori.Count; i++)
            {
                COUT.Append($"{_pitanjaOdgovori[i]}");
            }
            COUT.AppendLine($"Prosjek: {ProsjekIspit()}");
            return COUT.ToString();
        }

    }
}
