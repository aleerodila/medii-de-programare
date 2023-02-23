using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Salon.Models
{
    public class Serviciu
    {
        public int ID { get; set; }

        [Display(Name = "Nume serviciu")]
        public string Numeserviciu {get; set;}

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        public int? OrarID { get; set; }
        public Orar? Orar{ get; set; }

        public int? ProfesionistID { get; set; }
        public Profesionist? Profesionist{ get; set; }

        [Display(Name = "Categorie serviciu")]
        public ICollection<CategorieServiciu>? CategoriiServiciu { get; set; }
    }
}
