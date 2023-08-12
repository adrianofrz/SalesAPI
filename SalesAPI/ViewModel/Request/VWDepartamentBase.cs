using System.ComponentModel.DataAnnotations;

namespace SalesAPI.ViewModel.Request
{
    public class VWDepartamentBase
    {
        [Required]
        public string NomeDepartamento { get; set; }
    }
}
