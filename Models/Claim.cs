namespace AsyncDemo.Models;

public class Claim
{
    public string ClaimId{get; set;}
    public string PolicyNumber{get; set;}
    public string ClaimAmount { get; set; }
    public string ClaimType { get; set; }
    public bool IsActive{get; set;}
}