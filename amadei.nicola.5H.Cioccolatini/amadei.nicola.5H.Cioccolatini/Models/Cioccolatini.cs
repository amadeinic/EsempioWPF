using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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
                this.Clear();
                XElement dati = XElement.Load(FilePath);
                IEnumerable<XElement> ieCioccolatini = dati
                       .Element("Cioccolatini")
                       .Elements("Cioccolatino");

                foreach (XElement c in ieCioccolatini)
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
            //Da fare

            //XElement elemento = new XElement("Root",
            //                                   new XElement("Cioccolatini", this.Select(x => new XElement("Cioccolatino",                                              
            //                                   new XAttribute("Marca", x.Marca),
            //                                   new XText(x.Nome)))));          
            throw new NotImplementedException();
        }
    }
}
