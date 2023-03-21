using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace contact_app.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Data annotation para el auto increment
        public int Id { get; set; }

        [Required]
        [NotNull]
        [MaxLength(100)]
        public String? Email { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        
        [Required]
        [NotNull]
        public string? Password { get; set; }

        public virtual ICollection<Contact>? Contacts { get; set; }
    }
}
