using System.ComponentModel.DataAnnotations;

namespace ProcessPulse.Api.Dtos;

public class CreateWorkflowRequest
{
    [Required]
[StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Status { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Owner{ get; set; } = string.Empty;

}