using Job_candidate_hub_API.ApiResponse;
using Job_candidate_hub_API.Models;

namespace Job_candidate_hub_API.Repositories.IRepos
{
    public interface ICandidateRepo
    {
        public Task<Candidate> GetCandidateByEmail(string email);
        public Task<ApiResponse<Candidate>> Create(Candidate Candidate);
        public Task<ApiResponse<Candidate>> Update(Candidate Candidate);
    }
}
