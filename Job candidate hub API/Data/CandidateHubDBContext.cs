using Job_candidate_hub_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security;

namespace Job_candidate_hub_API.Data
{
    public class CandidateHubDBContext : DbContext
    {
        public CandidateHubDBContext(DbContextOptions options) : base(options)
        {
        }

        protected CandidateHubDBContext()
        {
        }

        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().HasData(new Candidate[] {
                new Candidate{
                    FirstName = "Mustafa",
                    LastName = "Fouda",
                    PhoneNumber= "+201206670459", 
                    Email="moustafafouda17@gmail.com",
                    TimeInterval = "1 hour",
                    LinkedInProfileURL = "linkedin.com/in/mustafa-fouda-/",
                    GitHubProfileURL = "github.com/MustafaFouda10",
                    FreeTextComment = "I am a Software Engineer at Network International"
                }
            });
        }
    }
}
