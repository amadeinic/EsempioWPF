using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amadei.nicola._5H.ASPMVC.Models
{
    public class Utente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }

    }

    public class Utenti : List<Utente>
    {
        public int NumeroDiUtenti { get { return this.Count; } }
    }
}