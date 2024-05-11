using Job_candidate_hub_API.ApiResponse;
using Job_candidate_hub_API.Data;
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


        public async Task<ApiResponse<Candidate>> CreateUpdateCandidate(Candidate candidate)
        {
            Candidate candidateExisted = await _candidateRepo.GetCandidateByEmail(candidate.Email);
            ApiResponse<Candidate> response = new ApiResponse<Candidate>();

            if (candidateExisted != null)
                response = await _candidateRepo.Update(candidate);
            else
                response = await _candidateRepo.Create(candidate);

            _context.SaveChanges();
            return response;
        }
    }
}
