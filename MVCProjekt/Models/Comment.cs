using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProjekt.Models
{
    public class Comment
    {
        public virtual Client? Client { get; set; }
        [Key]
        public int CommentId { get; set; }
        [ForeignKey(name: "ClientId")]
        public int ClientId { get; set; }
        [Required(ErrorMessage = "Zadejte text poznámky")]
        public DateTime DateOfInsert { get; set; }
        public string CommentText { get; set; }

    }
}
