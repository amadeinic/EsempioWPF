using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amadei.nicola._5H.libri
{
    class Libro
    {
        private string isbn;
        public string ISBN
        {
            get { return isbn; }
            set { isbn = value; }
        }
        //tryparse usa un ref
        //se passo per out sicuramente modifico, se passo per ref non è detto.
        //props non passabili per ref7

        private int data;

        public int Data
        {
            get { return data; }
            set { data = value; }
        }

        private string titolo;

        public string Titolo
        {
            get { return titolo.Substring(0,3) + "-" + titolo.Substring(titolo.Length-3,3); }
            set {
                if(value.Length<6)
                {
                    throw new Exception("Non si fa!!! NO!!!");
                }
                titolo = value;
            }
        }


    }
}
