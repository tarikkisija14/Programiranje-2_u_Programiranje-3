using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predmeti
{
    public class Kolekcija<T1, T2>
    {
        private T1[] _elementi1 { get; set; }
        private T2[] _elementi2 { get; set; }
        private int _trenutno { get; set; }
        private int _max { get; set; }

        public Kolekcija(int max = 10)
        {
            _elementi1 = new T1[max];
            _elementi2 = new T2[max];
            _trenutno = 0;
            _max = max;
        }
        public Kolekcija(Kolekcija<T1, T2> obj)
        {
            _max = obj._max;
            _elementi1 = new T1[_max];
            _elementi2 = new T2[_max];
            _trenutno = obj._trenutno;
            for (int i = 0; i < _trenutno; i++)
            {
                _elementi1[i] = obj._elementi1[i];
                _elementi2[i] = obj._elementi2[i];
            }
        }

        public void AddElement(T1 el1, T2 el2, int lokacija = -1)
        {
            if (lokacija == -1)
            {
                if (_trenutno == _max)
                    throw new Exception("pun niz");
                _elementi1[_trenutno] = el1;
                _elementi2[_trenutno] = el2;
                _trenutno++;
            }
            else
            {
                for (int i = _trenutno; i > lokacija; i--)
                {
                    _elementi1[i] = _elementi1[i - 1];
                    _elementi2[i] = _elementi2[i - 1];
                }
                _elementi1[lokacija] = el1;
                _elementi2[lokacija] = el2;
                _trenutno++;
            }
        }

        public Kolekcija<T1, T2> GetRange(int from, int to)
        {
            if (from < 0 || to >= _trenutno)
                throw new Exception("Izvan opsega niza");

            Kolekcija<T1, T2> obj = new Kolekcija<T1, T2>();
            for (int i = from; i <= to; i++)
            {
                obj.AddElement(_elementi1[i], _elementi2[i]);
            }
            return obj;
        }

        public T2 this[T1 el1]
        {
            get
            {
                for (int i = 0; i < _trenutno; i++)
                {
                    if (_elementi1[i].Equals(el1))
                        return _elementi2[i];
                }
                throw new Exception("Nije pronadjen element");
            }
            set
            {
                for (int i = 0; i < _trenutno; i++)
                {
                    if (_elementi1[i].Equals(el1))
                    {
                        _elementi2[i] = value;
                        return;
                    }
                }
                throw new Exception("Nije pronadjen element");
            }
        }

        public T1 GetElement1(int index)
        {
            return _elementi1[index];
        }
        public T2 GetElement2(int index)
        {
            return _elementi2[index];
        }

        public int GetTrenutno()
        {
            return _trenutno;
        }

        public override string ToString()
        {
            StringBuilder COUT = new StringBuilder();
            for (int i = 0; i < _trenutno; i++)
            {
                COUT.AppendLine($"{_elementi1[i]}  {_elementi2[i]}");
            }
            return COUT.ToString();
        }


    }
}
