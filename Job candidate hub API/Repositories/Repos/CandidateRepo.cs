using Job_candidate_hub_API.Data;
using Job_candidate_hub_API.Models;
using Job_candidate_hub_API.Repositories.IRepos;
using Microsoft.EntityFrameworkCore;

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


        public async Task<Candidate> Create(Candidate Candidate)
        {
            if (Candidate.FirstName != null && Candidate.LastName != null && Candidate.Email != null && Candidate.FreeTextComment != null)
            {
                _dBContext.Candidates.Add(Candidate);
                _dBContext.SaveChanges();
            }

            return Candidate;
        }

 
        public async Task<Candidate> Update(string email, Candidate Candidate)
        {
            Candidate oldCandidate = _dBContext.Candidates.FirstOrDefault(c => c.Email == email);

            if (oldCandidate != null)
            {
                if (Candidate.FirstName != null && Candidate.LastName != null && Candidate.Email != null && Candidate.FreeTextComment != null)
                {
                    oldCandidate.FirstName = Candidate.FirstName;
                    oldCandidate.LastName = Candidate.LastName;
                    oldCandidate.PhoneNumber = Candidate.PhoneNumber;
                    oldCandidate.Email = Candidate.Email;
                    oldCandidate.TimeInterval = Candidate.TimeInterval;
                    oldCandidate.LinkedInProfileURL = Candidate.LinkedInProfileURL;
                    oldCandidate.GitHubProfileURL = Candidate.GitHubProfileURL;
                    oldCandidate.FreeTextComment = Candidate.FreeTextComment;
                }
            }
               
            return Candidate;
        }
    }
}
