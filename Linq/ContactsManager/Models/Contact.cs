using System.ComponentModel.DataAnnotations;

namespace ContactsManager.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string Email { get; set; }
    }
}