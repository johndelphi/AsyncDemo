namespace AsyncDemo.Services;
using AsyncDemo.Models;

public class ClaimProcessor
{
    private readonly PolicyService _policy;
    private readonly FraudService _fraud;
    private readonly CoverageService _coverage;
    private readonly PayoutService _payout;

    public ClaimProcessor(
        PolicyService policy,
        FraudService fraud,
        CoverageService coverage,
        PayoutService payout)
    {
        _policy = policy;
        _fraud = fraud;
        _coverage = coverage;
        _payout = payout;
    }

    public async Task<ClaimDecision> processClaim(Claim claim, CancellationToken token)
    {
        var policyTask =_policy.ValidatePolicy(claim.PolicyNumber, token);
        var fraudTask = _fraud.CheckFraud(claim, token);
        var coverageTask = _coverage.EvaulateCoverage(claim, token);
        var payoutTask = _payout.CalculatePayout(claim, token);
        
await Task.WhenAll(policyTask,fraudTask, coverageTask, payoutTask,policyTask);

if(!policyTask.Result)
    return new ClaimDecision(false, "INVALID_POLICY",0);
if(fraudTask.Result)
    return new ClaimDecision(false, "Fraud detected flaged for review",0);
if (!coverageTask.Result)
    return new ClaimDecision(false, "Claim Not covered", 0);
        return new ClaimDecision(true, "Claim Accepted", 0);}
}