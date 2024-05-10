using System.ComponentModel.DataAnnotations;

namespace Job_candidate_hub_API.Models
{
    public class Candidate
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Key]
        [Required]
        public string Email { get; set; }
        public string TimeInterval { get; set; }
        public string LinkedInProfileURL { get; set; }
        public string GitHubProfileURL { get; set; }
        [Required]
        public string FreeTextComment { get; set; }
    }
}
