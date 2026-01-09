using AsyncDemo.Utils;
using AsyncDemo.Models;
namespace AsyncDemo.Services;

public class PayoutService
{
 public async Task<decimal> CalculatePayout(Claim claim, CancellationToken token)
 {
  await DelaySimulator.Simulate("Payout Calculation", token);
  return claim.ClaimAmount * 0.8m;
 }
}