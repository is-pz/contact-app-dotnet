using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace contact_app.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [NotNull]
        [MaxLength(10)]
        public int PhoneNumber { get; set; }

        public virtual User? User { get; set; }

    }
}
