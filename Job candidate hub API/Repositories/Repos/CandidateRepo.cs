using Job_candidate_hub_API.ApiResponse;
using Job_candidate_hub_API.Data;
using Job_candidate_hub_API.DTOs;
using Job_candidate_hub_API.Models;
using Job_candidate_hub_API.Repositories.IRepos;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Job_candidate_hub_API.Repositories.Repos
{
    public class CandidateRepo : ICandidateRepo
    {
        private readonly CandidateHubDBContext _dBContext;

        public CandidateRepo(CandidateHubDBContext dBContext)
        {
            _dBContext = dBContext;
        }


        public async Task<Candidate> GetCandidateByEmail(string email)
        {
            return await _dBContext.Candidates.FirstOrDefaultAsync(c => c.Email == email);
        }


        public async Task<ApiResponse<CandidateDto>> Create(CandidateDto Candidate)
        {
                _dBContext.Candidates.AddAsync(new Candidate
                {
                    FirstName = Candidate.FirstName,
                    LastName = Candidate.LastName,
                    PhoneNumber = Candidate.PhoneNumber,
                    Email= Candidate.Email,
                    TimeInterval = Candidate.TimeInterval,
                    LinkedInProfileURL = Candidate.LinkedInProfileURL,
                    GitHubProfileURL = Candidate.GitHubProfileURL,
                    FreeTextComment = Candidate.FreeTextComment,
                });

                return new ApiResponse<CandidateDto>
                {
                    ResponseData = Candidate,
                    CommandMessage = "Candidate Added Successfully",
                    IsValidResponse = true
                };

        }

 
        public async Task<ApiResponse<CandidateDto>> Update(CandidateDto Candidate)
        {
            Candidate oldCandidate = await GetCandidateByEmail(Candidate.Email);

            oldCandidate.FirstName = Candidate.FirstName;
            oldCandidate.LastName = Candidate.LastName;
            oldCandidate.PhoneNumber = Candidate.PhoneNumber;
            oldCandidate.TimeInterval = Candidate.TimeInterval;
            oldCandidate.LinkedInProfileURL = Candidate.LinkedInProfileURL;
            oldCandidate.GitHubProfileURL = Candidate.GitHubProfileURL;
            oldCandidate.FreeTextComment = Candidate.FreeTextComment;

            return new ApiResponse<CandidateDto>
            {
                ResponseData = Candidate,
                CommandMessage = "Candidate Updated Successfully",
                IsValidResponse = true
            };
        }
    }
}
