namespace AsyncDemo.Models;

public class ClaimDesicion
{
    public bool IsApproved { get; set; }
    public string PolicyNumber { get; set; }
    public decimal payoutAmount { get; set; }

    public ClaimDesicion(bool isApproved, string reason, decimal payout)
    {
        IsApproved = isApproved;
        PolicyNumber = reason;
        payoutAmount = payout;   
        
    }
}