using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect2.Models
{
    public class Medic
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        
        public string Nume { get; set; }
    }
}
