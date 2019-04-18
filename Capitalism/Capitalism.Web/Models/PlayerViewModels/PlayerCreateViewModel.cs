using System.ComponentModel.DataAnnotations;

namespace Capitalism.Web.Models.PlayerViewModels
{
    public class PlayerCreateViewModel
    {
        [Display(Name = "Display Name")]
        [Required]
        [MinLength(2, ErrorMessage = "Your display name must be between 2 and 20 characters.")]
        [MaxLength(20, ErrorMessage = "Your display name must be between 2 and 20 characters.")]
        public string DisplayName { get; set; }
    }
}
