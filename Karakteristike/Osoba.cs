using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karakteristike
{
    public abstract class Osoba
    {
        private string _imePrezime;
        private Datum _datumRodjenja;

        public Osoba(string imePrezime = "", Datum datumRodjenja = null)
        {
            _imePrezime = imePrezime;
            _datumRodjenja = datumRodjenja ?? new Datum(); 
        }
        public Osoba(Osoba obj)
        {
            _imePrezime = obj._imePrezime;
            _datumRodjenja = new Datum(obj._datumRodjenja);
        }

        public string GetImePrezime()
        {
            return _imePrezime;
        }
        public Datum GetDatumRodjenja()
        { 
            return _datumRodjenja;

        }
        public abstract void Info();

        public override string ToString()
        {
            StringBuilder COUT=new StringBuilder();
            COUT.AppendLine($"Ime i Prezime: {_imePrezime}");
            COUT.AppendLine($"Datum rodjenja: {_datumRodjenja}");
            return COUT.ToString();
        }
    }
}
