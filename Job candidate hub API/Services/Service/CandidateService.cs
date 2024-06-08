using Job_candidate_hub_API.ApiResponse;
using Job_candidate_hub_API.Data;
using Job_candidate_hub_API.DTOs;
using Job_candidate_hub_API.Models;
using Job_candidate_hub_API.Repositories.IRepos;
using Job_candidate_hub_API.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace Job_candidate_hub_API.Services.Service
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepo _candidateRepo;
        private readonly CandidateHubDBContext _context;

        public CandidateService(ICandidateRepo candidateRepo, CandidateHubDBContext context)
        {
            _candidateRepo = candidateRepo;
            _context = context;
        }


        public async Task<ApiResponse<CandidateDto>> CreateUpdateCandidate(CandidateDto candidate)
        {
            Candidate candidateExisted = await _candidateRepo.GetCandidateByEmail(candidate.Email);
            ApiResponse<CandidateDto> response = new ApiResponse<CandidateDto>();

            if (!string.IsNullOrEmpty(candidate.FirstName) && !string.IsNullOrEmpty(candidate.LastName) && !string.IsNullOrEmpty(candidate.Email) && !string.IsNullOrEmpty(candidate.FreeTextComment))
            {
                if (candidateExisted != null)
                    response = await _candidateRepo.Update(candidate);
                else
                    response = await _candidateRepo.Create(candidate);

                _context.SaveChanges();
                return response;
            }
            else
            {
                response.Errors = new List<string>();

                if (string.IsNullOrEmpty(candidate.FirstName))
                    response.Errors.Add("FirstName is required");  

                if (string.IsNullOrEmpty(candidate.LastName))
                    response.Errors.Add("LastName is required");          
                
                if (string.IsNullOrEmpty(candidate.Email))
                    response.Errors.Add("Email is required");     
                
                if (string.IsNullOrEmpty(candidate.FreeTextComment))
                    response.Errors.Add("FreeTextComment is required");

                response.IsValidResponse = false;
                response.ResponseData = null;
                response.CommandMessage = "oOoh Sorry! Please check if there is any missed input";
                
                return response;
            }

        }
    }
}
