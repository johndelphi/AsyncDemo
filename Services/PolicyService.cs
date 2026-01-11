using AsyncDemo.Utils;

namespace AsyncDemo.Services;

public class PolicyService
{
    public async Task<bool> ValidatePolicy(string policyNuber, CancellationToken token)
    {
        await DelaySimulator.Simulate("Policy Validation", token);
        return policyNuber.StartsWith("POL");
    }
    
}