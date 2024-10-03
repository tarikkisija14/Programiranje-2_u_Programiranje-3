using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kriteriji
{
    public  class Kolekcija<T1, T2>
    {
        private T1[] _elementi1;
        private T2[] _elementi2;
        private int _trenutno;
        private bool _omoguciDupliranje;

        public Kolekcija(bool omoguciDupliranje = true)
        {
            _elementi1 = new T1[0];
            _elementi2 = new T2[0];
            _trenutno = 0;
            _omoguciDupliranje = omoguciDupliranje;
        }

        public Kolekcija(Kolekcija<T1, T2> obj)
        {
            _trenutno = obj._trenutno;
            _omoguciDupliranje = obj._omoguciDupliranje;
            _elementi1 = new T1[_trenutno];
            _elementi2 = new T2[_trenutno];

            for (int i = 0; i < _trenutno; i++)
            {
                _elementi1[i] = obj._elementi1[i];
                _elementi2[i] = obj._elementi2[i];
            }
        }
        public void AddElement(T1 el1, T2 el2)
        {
            if (!_omoguciDupliranje)
            {
                for (int i = 0; i < _trenutno; i++)
                {
                    if (_elementi1[i].Equals(el1) && _elementi2[i].Equals(el2))
                        throw new Exception("Nije dozvoljeno dupliranje elemenata");
                }
            }

            Array.Resize(ref _elementi1, _trenutno + 1);
            Array.Resize(ref _elementi2, _trenutno + 1);

            _elementi1[_trenutno] = el1;
            _elementi2[_trenutno] = el2;
            _trenutno++;
        }

        public Kolekcija<T1, T2> InsertAt(int lokacija, T1 el1, T2 el2)
        {
            Array.Resize(ref _elementi1, _trenutno + 1);
            Array.Resize(ref _elementi2, _trenutno + 1);

            for (int i = _trenutno; i > lokacija; i--)
            {
                _elementi1[i] = _elementi1[i - 1];
                _elementi2[i] = _elementi2[i - 1];
            }

            _elementi1[lokacija] = el1;
            _elementi2[lokacija] = el2;
            _trenutno++;
            return this;
        }

        public T1 GetElement1(int lokacija)
        {
            return _elementi1[(int)lokacija];

        }
        public T2 GetElement2(int lokacija)
        {
            return _elementi2[(int)lokacija];
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
