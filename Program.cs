using System.Diagnostics;

namespace AsyncDemo;
using  AsyncDemo.Models;
using AsyncDemo.Services;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("-----Insurance Claim Processor -------");
        var claim = new Claim
        {
            ClaimId = Guid.NewGuid().ToString(),
            ClaimType = "Accident",
            ClaimAmount = 8000,
            PolicyNumber = "POL-12345",
            IsActive = true

        };
        
        using var cts = new CancellationTokenSource();
        cts.CancelAfter(5000);
        var sw = Stopwatch.StartNew();
        try
        {
            var processor = new ClaimProcessor();
            var decision = await processor.processClaim(claim, cts.Token);
            Console.WriteLine("/n ---Final Claim decision -----");
            Console.WriteLine($"Claim ID: {claim.ClaimId}");
            Console.WriteLine($"Approval:{claim.IsApproved}");
            Console.WriteLine($"Reason:{decision.payoutAmount}");
            //   Console.WriteLine($"payout:{}");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\nClaim processing cancelled due to timeout.");
        }
        sw.Stop(); 
        Console.WriteLine($"{sw.ElapsedMilliseconds} ms");
        
    }
}