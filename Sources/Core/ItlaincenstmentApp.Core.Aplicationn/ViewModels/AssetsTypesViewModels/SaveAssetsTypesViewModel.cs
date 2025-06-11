using System.ComponentModel.DataAnnotations;

namespace ItlaincenstmentApp.Core.Aplicationn.ViewModels.AssetsTypesViewModels
{
    public class SaveAssetsTypesViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="pero desgraciado te pesa ponele un nombre no joda")]
        public required string Name { get; set; }
        public string? Description { get; set; }
        public bool Remove { get; set; } = false; 
    }
}
