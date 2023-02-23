using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Salon.Models
{
    public class Profesionist
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        [Display(Name = "Profesionist")]
        public string FullName
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }


        public ICollection<Serviciu>? Servicii { get; set; }
    }
}
