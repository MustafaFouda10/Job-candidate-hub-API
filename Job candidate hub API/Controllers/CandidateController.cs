using Job_candidate_hub_API.ApiResponse;
using Job_candidate_hub_API.Models;
using Job_candidate_hub_API.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_candidate_hub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost("InsertCandidate")]
        public async Task<IActionResult> CreateUpdateCandidate(Candidate candidate)
        {
            var response = await _candidateService.CreateUpdateCandidate(candidate);
            if (response.IsValidResponse == true)
                return Ok(response);
            
            return BadRequest(response);
        }
    }
}
