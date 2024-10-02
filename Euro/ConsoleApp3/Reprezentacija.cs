using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp3
{
    public class Reprezentacija
    {
        Drzava _drzava;
        List<Igrac> _igraci;

        public Reprezentacija(Drzava drzava = Drzava.BOSNA_I_HERCEGOVINA)
        {
            _drzava = drzava;
            _igraci=new List<Igrac>();
        }
       public  Reprezentacija(Reprezentacija obj)
       {
            _drzava = obj._drzava;
            _igraci = obj._igraci;

       }

        public static bool operator ==(Reprezentacija r1, Reprezentacija r2)
        {
            if (r1._drzava != r2._drzava) return false;
            if (r1._igraci.Count != r2._igraci.Count) return false;
            for (int i = 0; i < r1._igraci.Count; i++)
            {
                if (r1._igraci[i] != r2._igraci[i]) return false;
            }
            return true;
        }

        public static bool operator !=(Reprezentacija r1, Reprezentacija r2)
        {
            return !(r1 == r2);
        }


       public  List<Igrac> GetStrijelci()
        {
            List<Igrac> Madrid=new List<Igrac>();
            for (int i = 0; i < _igraci.Count; i++)
            {
                if (_igraci[i].GetPogoci().Count>0)
                {
                    Madrid.Add(_igraci[i]);
                }
            }
            return Madrid;
        }

        public void AddIgrac(Igrac igrac)
        {
            for (int i = 0; i <_igraci.Count; i++)
            {
                if (_igraci[i].GetID() == igrac.GetID())
                    throw new Exception("igrac vec dodat");
            }
            _igraci.Add(igrac); 
        }

        public int GetbrojPogodaka()
        {
            int brojac = 0;
            for (int i = 0; i < _igraci.Count; i++)
            {
                brojac += _igraci[i].GetPogoci().Count;
            }
            return brojac;
        }

        public Drzava GetDrzava()
        {
            return _drzava;
        }

       public List<Igrac> GetIgraci()
        {
            return _igraci;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drzava: {_drzava}");
            sb.AppendLine($"Igraci: ");
            for (int i = 0; i < _igraci.Count; i++)
            {
                sb.AppendLine(_igraci[i].ToString());
            }
            return sb.ToString();
        }

    }
}
