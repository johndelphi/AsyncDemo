using AsyncDemo.Utils;
using AsyncDemo.Models;
namespace AsyncDemo.Services;

public class FraudService
{
    public async Task<bool> CheckFraud(Claim claim, CancellationToken token)
    {
        await DelaySimulator.Simulate("Fraud Check",  token);
        return Random.Shared.Next(1, 10) == 5;
    }
}