using Job_candidate_hub_API.ApiResponse;
using Job_candidate_hub_API.DTOs;
using Job_candidate_hub_API.Models;
using Job_candidate_hub_API.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        public async Task<IActionResult> CreateUpdateCandidate([FromBody] CandidateDto candidate)
        {
            var response = await _candidateService.CreateUpdateCandidate(candidate);

            if (response.IsValidResponse == false)
                return BadRequest(response);
            else
                return Ok(response);
        }
    }
}
