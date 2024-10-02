using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Kolekcija<T1,T2>
    {
        T1[] _elementi1 { get; set; }
        T2[] _elementi2 { get; set; }
        int _trenutno { get; set; }
       

       public Kolekcija(int max) 
       { 
         _elementi1 = new T1[max];
         _elementi2 = new T2[max];
         _trenutno = 0;
       }
       
       public Kolekcija(Kolekcija<T1,T2> obj)
       {
            _elementi1 = new T1[obj._elementi1.Length];
            _elementi2=new T2[obj._elementi2.Length];

            Array.Copy(obj._elementi1, _elementi1, obj._elementi1.Length);
            Array.Copy(obj._elementi2, _elementi2, obj._elementi2.Length);

            _trenutno=obj._trenutno;
        }

        public void AddElement(T1 el1, T2 el2)
        {
            if (_trenutno == _elementi1.Length)
                throw new Exception("izvan opsega");

            _elementi1[_trenutno] = el1;
            _elementi2[_trenutno]=el2;
            _trenutno++;
        }

        public Kolekcija<T1, T2> InsertAt(T1 el1, T2 el2,int lokacija)
        {
            _trenutno++;
            for (int i = _trenutno-1; i >lokacija ; i--)
            {
                _elementi1[i] = _elementi1[i - 1];
                _elementi2[i] = _elementi2[i - 1];
            }
            _elementi1[lokacija] = el1;
            _elementi2[lokacija] = el2;
            return this;

        }
        public Kolekcija<T1, T2>RemoveRange(int from,int to)
        {
            if (from < 0 || to >= _trenutno || from > to)
            {
                throw new Exception("izvan opsega niza");
            }
           Kolekcija<T1, T2> obrisani = new Kolekcija<T1, T2>(to - from + 1);
           int pozicija = to - from + 1;

           for (int i = from; i <=to; i++)
           {
               obrisani.AddElement(_elementi1[i], _elementi2[i]);
           }

           for (int i = to+1; i <_trenutno;i++)
            {
                _elementi1[i-pozicija]=_elementi1[i];
                _elementi2[i-pozicija] = _elementi2[i]; 
            }

            _trenutno -= pozicija;
            return obrisani;

            
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _trenutno; i++)
            {
                sb.AppendLine($"{_elementi1[i]} {_elementi2[i]}");
            }
            return sb.ToString();
        }

        public int GetTrenutno()
        {
            return _trenutno;
        }

        public T1 GetElementi1(int index)
        {
            return _elementi1[index];
        }
        public T2 GetElementi2(int index)
        {
            return _elementi2[index];
        }

    }
}
