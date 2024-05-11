using Job_candidate_hub_API.ApiResponse;
using Job_candidate_hub_API.Data;
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


        public async Task<ApiResponse<Candidate>> Create(Candidate Candidate)
        {
            if (Candidate.FirstName != null && Candidate.LastName != null && Candidate.Email != null && Candidate.FreeTextComment != null)
            {
                _dBContext.Candidates.Add(Candidate);
                return new ApiResponse<Candidate>
                {
                    ResponseData = Candidate,
                    CommandMessage = "Candidate Added Successfully",
                    IsValidResponse = true
                };
            }

            return new ApiResponse<Candidate>
            {
                ResponseData = null,
                CommandMessage = "Error! Please check the inputs again",
                IsValidResponse = false
            };

        }

 
        public async Task<ApiResponse<Candidate>> Update(Candidate Candidate)
        {
            Candidate oldCandidate = _dBContext.Candidates.FirstOrDefault(c => c.Email == Candidate.Email);

            if (oldCandidate != null)
            {
                if (Candidate.FirstName != null && Candidate.LastName != null && Candidate.Email != null && Candidate.FreeTextComment != null)
                {
                    oldCandidate.FirstName = Candidate.FirstName;
                    oldCandidate.LastName = Candidate.LastName;
                    oldCandidate.PhoneNumber = Candidate.PhoneNumber;
                    oldCandidate.TimeInterval = Candidate.TimeInterval;
                    oldCandidate.LinkedInProfileURL = Candidate.LinkedInProfileURL;
                    oldCandidate.GitHubProfileURL = Candidate.GitHubProfileURL;
                    oldCandidate.FreeTextComment = Candidate.FreeTextComment;

                    return new ApiResponse<Candidate>
                    {
                        ResponseData = Candidate,
                        CommandMessage = "Candidate Updated Successfully",
                        IsValidResponse = true
                    };
                }
            }

            return new ApiResponse<Candidate>
            {
                ResponseData = null,
                CommandMessage = "Error! Please check the inputs again",
                IsValidResponse = false
            };
        }
    }
}
