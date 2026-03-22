namespace ProcessPulse.Api.Models;

public class Workflow
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public string Status { get; set; } = "Draft";
    
    public string Owner { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}