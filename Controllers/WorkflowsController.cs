using Microsoft.AspNetCore.Mvc;
using ProcessPulse.Api.Dtos;
using ProcessPulse.Api.Models;
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

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var workflow = _workflowService.GetById(id);

        if (workflow is null)
        {
            return NotFound(new { message = $"Workflow with id {id} was not found." });
        }

        return Ok(workflow);
    }

[HttpPost]
public IActionResult Create([FromBody] CreateWorkflowRequest request)
{
    var workflow = new Workflow
    {
        Name = request.Name,
        Status = request.Status,
        Owner = request.Owner
    };

    var created = _workflowService.Create(workflow);

    return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
}

[HttpPut("{id}")]
public IActionResult Update(int id, [FromBody] UpdateWorkflowRequest request)
{
    var workflow = new Workflow
    {
        Name = request.Name,
        Status = request.Status,
        Owner = request.Owner
    };

    var updated = _workflowService.Update(id, workflow);

    if (!updated)
    {
        return NotFound(new { message = $"Workflow with id {id} was not found." });
    }

    return NoContent();
}

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _workflowService.Delete(id);

        if (!deleted)
        {
            return NotFound(new { message = $"Workflow with id {id} was not found." });
        }

        return NoContent();
    }
}