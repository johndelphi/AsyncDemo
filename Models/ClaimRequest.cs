namespace AsyncDemo.Models;

public class ClaimRequest
{
    public string PolicyNumber { get; set; } = string.Empty;
    public decimal ClaimAmount { get; set; }
    public string ClaimType { get; set; } = string.Empty;
}
