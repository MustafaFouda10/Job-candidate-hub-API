using Job_candidate_hub_API.Models;

namespace Job_candidate_hub_API.Repositories.IRepos
{
    public interface ICandidateRepo
    {
        public Task<Candidate> GetCandidateByEmail(string email);
        public Task<Candidate> Create(Candidate Candidate);
        public Task<Candidate> Update(string email, Candidate Candidate);

    }
}
