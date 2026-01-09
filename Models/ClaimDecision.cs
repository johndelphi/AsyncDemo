namespace AsyncDemo.Models;

public class ClaimDecision
{
    public bool IsApproved { get; set; }
    public string PolicyNumber { get; set; }
    public decimal payoutAmount { get; set; }

    public ClaimDecision(bool isApproved, string reason, decimal payout)
    {
        IsApproved = isApproved;
        PolicyNumber = reason;
        payoutAmount = payout;   
        
    }
}