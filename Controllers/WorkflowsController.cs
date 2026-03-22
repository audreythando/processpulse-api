using Microsoft.AspNetCore.Mvc;
using ProcessPulse.Api.Services;

namespace ProcessPulse.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkflowsController : ControllerBase
{
    private readonly WorkflowService _workflowService;

    public WorkflowsController(WorkflowService workflowService)
    {
        _workflowService = workflowService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_workflowService.GetAll());
    }
}