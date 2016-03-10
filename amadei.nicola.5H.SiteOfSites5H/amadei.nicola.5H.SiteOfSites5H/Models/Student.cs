using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace amadei.nicola._5H.SiteOfSites5H.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Motto { get; set; }        
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string FbId { get; set; }
        public string GitId { get; set; }
        public string WebURL { get; set; }
        public Student(XElement element)
        {
            Name = element.Element("name").Value;
            Surname = element.Element("surname").Value;
            Motto = element.Element("motto").Value;
            Description = element.Element("description").Value;
            ImageURL = element.Element("imageURL").Value;
            FbId = element.Element("fbId").Value;
            GitId = element.Element("gitId").Value;
            WebURL = element.Element("webURL").Value;
        }
    }

    public class SchoolClass:List<Student>
    {
        public int NumberOfStudents { get { return this.Count; } }
        public string Name { get; set; }
        public string NameShort { get; set; }

    }
}