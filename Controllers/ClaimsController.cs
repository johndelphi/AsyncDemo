using Microsoft.AspNetCore.Mvc;
using AsyncDemo.Models;
using AsyncDemo.Services;

namespace AsyncDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClaimsController : ControllerBase
{
    private readonly ClaimProcessor _claimProcessor;
    private readonly ILogger<ClaimsController> _logger;

    public ClaimsController(ClaimProcessor claimProcessor, ILogger<ClaimsController> logger)
    {
        _claimProcessor = claimProcessor;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<ClaimDecision>> ProcessClaim(
        [FromBody] ClaimRequest claimRequest,
        CancellationToken cancellationToken)
    {
        try
        {
            var claim = new Claim
            {
                ClaimId = Guid.NewGuid().ToString(),
                PolicyNumber = claimRequest.PolicyNumber,
                ClaimAmount = claimRequest.ClaimAmount,
                ClaimType = claimRequest.ClaimType,
                IsActive = true
            };

            _logger.LogInformation("Processing claim {ClaimId}", claim.ClaimId);

            var decision = await _claimProcessor.processClaim(claim, cancellationToken);

            _logger.LogInformation(
                "Claim {ClaimId} processed. Approved: {IsApproved}",
                claim.ClaimId,
                decision.IsApproved);

            return Ok(decision);
        }
        catch (OperationCanceledException)
        {
            _logger.LogWarning("Claim processing was cancelled");
            return StatusCode(408, new { error = "Claim processing timeout" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing claim");
            return StatusCode(500, new { error = "Internal server error processing claim" });
        }
    }

    [HttpGet("{claimId}")]
    public ActionResult<string> GetClaimStatus(string claimId)
    {
        return Ok(new { claimId, status = "This endpoint would retrieve claim status" });
    }
}
