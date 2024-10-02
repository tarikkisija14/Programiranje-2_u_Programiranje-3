using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karakteristike
{
    public class Kolekcija<T1,T2>
    {
        private T1[] _elementi1 { get; set; }
        private T2[] _elementi2 { get; set; }
        private int _trenutno { get; set; }
        private bool _omoguciDupliranje { get; set; }

        public Kolekcija(bool omoguciDupliranje = true)
        {
            _omoguciDupliranje = omoguciDupliranje;
            _trenutno = 0;
            _elementi1 = new T1[_trenutno];
            _elementi2 = new T2[_trenutno];
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
                        throw new Exception("Element already exists.");
                }
            }

            T1[] temp1 = new T1[_trenutno + 1];
            T2[] temp2 = new T2[_trenutno + 1];
           
            for (int i = 0; i < _trenutno; i++)
            {
                temp1[i] = _elementi1[i];
                temp2[i] = _elementi2[i];
            }

            temp1[_trenutno] = el1;
            temp2[_trenutno] = el2;

            _elementi1 = temp1;
            _elementi2 = temp2;
            _trenutno++;
        }

        public Kolekcija<T1,T2>GetRange(int from,int to,bool akcija=false)
        {
            if (from < 0 || to >= _trenutno || from > to)
                throw new Exception("izvan opsega");
            var obj = new Kolekcija<T1, T2>(_omoguciDupliranje);
            if (akcija)
            {
                for (int i = to; i >= from; i--)
                    obj.AddElement(_elementi1[i], _elementi2[i]);
            }
            else
            {
                for (int i = from; i <= to; i++)
                    obj.AddElement(_elementi1[i], _elementi2[i]);
            }
            return obj;

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

        public bool GetOmoguciDupliranje()
        {
            return _omoguciDupliranje;
        }

        public override string ToString()
        {
           StringBuilder COUT= new StringBuilder();
            for (int i = 0; i < _trenutno; i++)
            {
                COUT.AppendLine($"{_elementi1[i]}  {_elementi2[i]}");
            }
            return COUT.ToString();

        }
    }
}
