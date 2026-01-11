namespace AsyncDemo.Services;
using AsyncDemo.Models;

public class ClaimProcessor
{
    private readonly PolicyService _policy = new();
    private readonly FraudService _fraud = new();
    private readonly CoverageService _coverage = new();
    private readonly PayoutService _payout = new();

    public async Task<ClaimDecision> ProcessClaim(Claim claim, CancellationToken token)
    {
        if (claim == null)
        {
            throw new ArgumentNullException(nameof(claim), "Claim cannot be null.");
        }

        // Start all tasks concurrently
        var policyTask = _policy.ValidatePolicy(claim.PolicyNumber, token);
        var fraudTask = _fraud.CheckFraud(claim, token);
        var coverageTask = _coverage.EvaulateCoverage(claim, token);
        var payoutTask = _payout.CalculatePayout(claim, token);

        // Await all tasks to complete
        await Task.WhenAll(policyTask, fraudTask, coverageTask, payoutTask);

        // Evaluate results
        if (!await policyTask)
        {
            return new ClaimDecision(false, "Invalid policy.", 0);
        }

        if (await fraudTask)
        {
            return new ClaimDecision(false, "Fraud detected. Flagged for review.", 0);
        }

        if (!await coverageTask)
        {
            return new ClaimDecision(false, "Claim not covered.", 0);
        }

        var payout = await payoutTask;
        return new ClaimDecision(true, "Claim accepted.", payout);
    }
}