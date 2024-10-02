using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{




    public class Pogodak
    {
        Vrijeme _vrijemePogotka { get; set; }
        string _napomena { get; set; }

       public Pogodak(Vrijeme vrijeme, string napomena)
        {
            _vrijemePogotka = vrijeme;
            _napomena = napomena;

        }
       public Pogodak(Pogodak obj)
        {
            _vrijemePogotka = obj._vrijemePogotka;
            _napomena = obj._napomena;
        }

       public  static bool operator==(Pogodak p1, Pogodak p2)
        {
            if (p1._vrijemePogotka != p2._vrijemePogotka)
            {
                return false;
            }
            if (p1._napomena != p2._napomena)
            {
                return false;
            }
            return true;
        }
        public static bool operator!=(Pogodak p1, Pogodak p2)
        {
            return !(p1== p2);
        }

       public string GetNapomena()
        { return _napomena; }

        public Vrijeme GetVrijemePogotka()
        {
            return _vrijemePogotka;
        }

    }
}
