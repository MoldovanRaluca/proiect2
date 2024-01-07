using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect2.Models
{
    public class Clinica
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ClinicName { get; set; }
        public string Adress { get; set; }
        public string ClinicDetails
        { get { return ClinicName + " "+Adress;} }
        [OneToMany]
        public List<ServList> ServLists { get; set; }
    }
}
