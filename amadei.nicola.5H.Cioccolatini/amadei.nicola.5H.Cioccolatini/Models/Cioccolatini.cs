using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace amadei.nicola._5H.Cioccolatini
{
    public class Cioccolatini : ObservableCollection<Cioccolatino>
    {
        public string FilePath { get; set; }

        public Cioccolatini()
        {

        }
        public Cioccolatini(string filePath)
        {
            FilePath = filePath;
            this.Load();
        }

        public void Load()
        {
            try
            {
                XElement dati = XElement.Load(FilePath);
                IEnumerable<XElement> cioccolatini = dati
                       .Element("cioccolatini")
                       .Elements("cioccolatino");

                foreach (XElement c in cioccolatini)
                {
                    Add(new Cioccolatino(c));
                }
            }
            catch(Exception erore)
            {
                throw erore;
            }

        }
        public void Save()
        {
            XElement elemento = new XElement("cioccolatini", this.Select(x => new XElement("cioccolatino",                                              
                                               new XAttribute("Marca", x.Marca),
                                               new XText(x.Nome))));
           //E ADESSO COME LO SALVO??


        }
    }
}
