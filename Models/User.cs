using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace contact_app.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [NotNull]
        [MaxLength(100)]
        public int Email { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        
        [Required]
        [NotNull]
        public string? Password { get; set; }

        public virtual ICollection<Contact>? Contacts { get; set; }
    }
}
