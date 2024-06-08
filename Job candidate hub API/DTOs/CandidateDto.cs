using System.ComponentModel.DataAnnotations;

namespace Job_candidate_hub_API.DTOs
{
    public class CandidateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string TimeInterval { get; set; }
        public string LinkedInProfileURL { get; set; }
        public string GitHubProfileURL { get; set; }
        public string FreeTextComment { get; set; }
    }
}
