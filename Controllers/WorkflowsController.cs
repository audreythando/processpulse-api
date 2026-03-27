using Microsoft.AspNetCore.Mvc;
using ProcessPulse.Api.Dtos;
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
    public async Task<IActionResult> GetWorkflows()
    {
        var workflows = await _workflowService.GetAllAsync();
        return Ok(workflows);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWorkflowById(int id)
    {
        var workflow = await _workflowService.GetByIdAsync(id);

        if (workflow is null)
        {
            return NotFound(new { message = $"Workflow with ID {id} was not found." });
        }

        return Ok(workflow);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWorkflow([FromBody] CreateWorkflowRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var workflow = await _workflowService.CreateAsync(request);
        return CreatedAtAction(nameof(GetWorkflowById), new { id = workflow.Id }, workflow);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWorkflow(int id, [FromBody] UpdateWorkflowRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedWorkflow = await _workflowService.UpdateAsync(id, request);

        if (updatedWorkflow is null)
        {
            return NotFound(new { message = $"Workflow with ID {id} was not found." });
        }

        return Ok(updatedWorkflow);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkflow(int id)
    {
        var deleted = await _workflowService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound(new { message = $"Workflow with ID {id} was not found." });
        }

        return NoContent();
    }
}