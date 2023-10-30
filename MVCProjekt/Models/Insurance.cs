using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProjekt.Models
{
    public class Insurance
    {
        public virtual Client? Client { get; set; }

        [Key]
        public int InsuranceId { get; set; }

        [ForeignKey(name: "ClientId")]
        public int ClientId { get; set; }
        [Required(ErrorMessage = "Zadejte název pojištění")]
        public string InsuranceName { get; set; }
        [Required(ErrorMessage = "Zadejte výši pojistného krytí")]
        public string InsuranceValue { get; set; }
        [Required(ErrorMessage = "Zadejte prosím předmět pojistného krytí")]
        public string ObjectOfInsurance { get; set; }

    }
}