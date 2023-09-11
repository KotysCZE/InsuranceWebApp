using System.ComponentModel.DataAnnotations;

namespace MVCProjekt.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Zadejte jméno")]
        public string Name { get; set; } = "";
        [Required(ErrorMessage = "Zadejte přijímení")]
        public string Surnname { get; set; } = "";
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Zadejte platnou e-mailovou adresu")]
        public string Email { get; set; } = "";
        [Required(ErrorMessage = "Zadejte ulici bydliště")]
        public string Street { get; set; } = "";
        [Required(ErrorMessage = "Zadejte poštovní směrovací číslo")]
        [RegularExpression(@"[0-9]{5}", ErrorMessage = "Zadejte prosím správný formát PSČ")]
        public virtual string PSC { get; set; } = "";
        [Required(ErrorMessage = "Zadejte město bydliště")]
        public string City { get; set; } = "";
        [Required(ErrorMessage = "Zadejte stát ")]
        public string State { get; set; } = "";
        public string Insurance_name { get; set; } = "";
        [Required]
        [RegularExpression(@"[0-9]{9}", ErrorMessage ="Zadejte prosím správný formát telefonního čísla bez předvolby")]

        public string Phone { get; set; } = "";



    }
}
