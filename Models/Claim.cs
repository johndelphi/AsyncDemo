namespace AsyncDemo.Models;

public class Claim
{
    public string ClaimId{get; set;}
    public string PolicyNumber{get; set;}
    public decimal ClaimAmount { get; set; }
    public string ClaimType { get; set; }
    public bool IsActive{get; set;}
    public string Decision { get; set; }
    public bool IsApproved{get; set;}
}