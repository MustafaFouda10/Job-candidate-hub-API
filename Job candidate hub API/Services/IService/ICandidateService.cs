using Job_candidate_hub_API.ApiResponse;
using Job_candidate_hub_API.DTOs;
using Job_candidate_hub_API.Models;

namespace Job_candidate_hub_API.Services.IService
{
    public interface ICandidateService
    {
        public Task<ApiResponse<CandidateDto>> CreateUpdateCandidate(CandidateDto candidate);
    }
}
