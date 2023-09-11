using System.ComponentModel.DataAnnotations;

namespace MVCProjekt.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Vyplňte e-mailovou adresu")]
        [EmailAddress(ErrorMessage = "Neplatná e-mailová adresa")]
        [Display(Name = "Email")]
        public string Email { get; set; } = "";



        [Required(ErrorMessage = "Zadejte heslo")]
        [StringLength(15, ErrorMessage = "Heslo musí mít délku minimálně 6 znaků a maximální délku 15 znaků",MinimumLength = 6 )]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Zadejte heslo")]
        [DataType(DataType.Password)]
        [Display(Name = "Potvrzení hesla")]
        [Compare(nameof(Password),ErrorMessage = "Hesla se musí shodovat")]
        public string ConfirmPassword { get; set; } = "";
    }
}
