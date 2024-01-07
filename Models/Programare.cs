using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect2.Models
{
    [Table("Programare")]
    public class Programare
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Required(ErrorMessage = "Data programarii este obligatorie.")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Ora programarii este obligatorie.")]
        [DataType(DataType.Time)]
        public TimeSpan Ora { get; set; }

        [Required(ErrorMessage = "Numărul de persoane este obligatoriu.")]
        [Range(1, int.MaxValue, ErrorMessage = "Numărul de persoane trebuie să fie cel puțin 1.")]
        public int NumarPersoane { get; set; }

        [ForeignKey(typeof(Clinica))]
        public int? ClinicaID { get; set; }

        [ManyToOne(nameof(ClinicaID))]
        public Clinica? Clinica { get; set; }

    }
}