using AsyncDemo.Utils;
using AsyncDemo.Models;

namespace AsyncDemo.Services;

public class CoverageService
{
    public async Task<bool> EvaulateCoverage(Claim claim, CancellationToken token)
    {
        await DelaySimulator.Simulate("Coverage Evaluation", token);
        return claim.ClaimType == "Malpractice";
    }
}