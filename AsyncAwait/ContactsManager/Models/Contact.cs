using System.ComponentModel.DataAnnotations;

namespace ContactsManager.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string FirstName { get; set; }
        [Required, StringLength(50)]
        public string LastName { get; set; }
        [Required, StringLength(50)]
        public string Email { get; set; }
    }
}