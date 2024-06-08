using Job_candidate_hub_API.ApiResponse;
using Job_candidate_hub_API.DTOs;
using Job_candidate_hub_API.Models;

namespace Job_candidate_hub_API.Repositories.IRepos
{
    public interface ICandidateRepo
    {
        public Task<Candidate> GetCandidateByEmail(string email);
        public Task<ApiResponse<CandidateDto>> Create(CandidateDto Candidate);
        public Task<ApiResponse<CandidateDto>> Update(CandidateDto Candidate);
    }
}
