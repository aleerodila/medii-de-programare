using Salon.Models;
using System.Security.Policy;

namespace Salon.Models.ViewModels
{
    public class CategorieIndexData
    {
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieServiciu> CategoriiServiciu { get; set; }
        public IEnumerable<Serviciu> Servicii { get; set; }

    }
}
