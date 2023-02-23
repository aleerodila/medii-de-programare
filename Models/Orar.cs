using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Salon.Models
{
    public class Orar
    {
        public int ID { get; set; }

        [Display(Name = "Orar")]
        public string Numeorar { get; set; }
        public ICollection<Serviciu>? Servicii { get; set; }
    }
}
