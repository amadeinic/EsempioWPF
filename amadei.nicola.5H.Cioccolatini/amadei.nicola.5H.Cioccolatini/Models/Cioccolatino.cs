using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace amadei.nicola._5H.Cioccolatini
{
    public class Cioccolatino
    {
        public string Marca { get; set; }
        public string Nome { get; set; }

        public Cioccolatino(XElement e)
        {
            Marca = e.Attribute("Marca").Value;
            Nome = e.Value;
        }

        public Cioccolatino()
        {
        }
    }
}
