using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Salon.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        [Display(Name = "Categorie")]
        public string Numecategorie { get; set; }
        public ICollection<CategorieServiciu>? CategoriiServiciu { get; set; }
    }
}
