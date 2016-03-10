using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amade.nicola._5H.SiteOfSites.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string FbId { get; set; }
        public string GitId { get; set; }
        public string WebId { get; set; }
    }

    public class Class:List<Student>
    {
        public int NumberOfStudents { get { return this.Count; } }
        public string Name { get; set; }
        public string NameShort { get; set; }

    }
}