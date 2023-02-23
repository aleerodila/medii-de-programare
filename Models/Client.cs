using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Salon.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string? Prenume { get; set; }
        public string? Nume { get; set; }
        public string? Adresa { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return Prenume + " " + Nume;
            }
        }

    }
}
