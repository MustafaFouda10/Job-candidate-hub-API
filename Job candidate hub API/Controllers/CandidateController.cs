using Job_candidate_hub_API.ApiResponse;
using Job_candidate_hub_API.Models;
using Job_candidate_hub_API.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_candidate_hub_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost("InsertCandidate")]
        public async Task<IActionResult> CreateUpdateCandidate([FromBody] Candidate candidate)
        {
            var response = await _candidateService.CreateUpdateCandidate(candidate);

            if (!ModelState.IsValid)
            {
                 response.Errors = ModelState.Values.SelectMany(v => v.Errors)
                                         .Select(e => e.ErrorMessage)
                                         .ToList();

                
                return BadRequest(response);
            }
    
            return Ok(response);
            
        }
    }
}
