using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amadei.nicola._5H.CioccoASP.Models
{
    public class Cioccolatino
    {
        public string Marca { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int Calorie { get; set; }

    }
    public class Cioccolatini : List<Cioccolatino>
    {       
        public int NumeroDiCioccolatini
        {
            get { return this.Count; }            
        }

    }
}