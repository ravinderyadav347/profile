using System.ComponentModel.DataAnnotations;

namespace ProfileProjectMVC.Models
{
    public class Email
    {
        [Required(ErrorMessage = "Please enter Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage ="This is not a valid email address.")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please enter your subject.")]
        [MinLength(5, ErrorMessage = "Subject cannot be less than 5 characters.")]
        [MaxLength(50, ErrorMessage = "Subject cannot be longer than 50 characters.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Write your message.")]
        [MinLength(20, ErrorMessage = "Message cannot be less than 20 characters.")]
        [MaxLength(500, ErrorMessage = "Message cannot be longer than 500 characters.")]
        public string EmailBody { get; set; }
    }
}