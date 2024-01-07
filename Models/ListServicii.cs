using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace proiect2.Models
{
    public class ListServicii
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(ServList))]
        public int ServListID { get; set; }
        public int ServiciiID { get; set; }
    }
}
