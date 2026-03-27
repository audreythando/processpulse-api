using Microsoft.EntityFrameworkCore;
using ProcessPulse.Api.Data;
using ProcessPulse.Api.Dtos;
using ProcessPulse.Api.Models;

namespace ProcessPulse.Api.Services;

public class WorkflowService
{
    private readonly AppDbContext _context;

    public WorkflowService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Workflow>> GetAllAsync()
    {
        return await _context.Workflows
            .OrderByDescending(w => w.CreatedAt)
            .ToListAsync();
    }

    public async Task<Workflow?> GetByIdAsync(int id)
    {
        return await _context.Workflows.FindAsync(id);
    }

    public async Task<Workflow> CreateAsync(CreateWorkflowRequest request)
    {
        var workflow = new Workflow
        {
            Name = request.Name,
            Status = request.Status,
            Owner = request.Owner,
            CreatedAt = DateTime.UtcNow
        };

        _context.Workflows.Add(workflow);
        await _context.SaveChangesAsync();

        return workflow;
    }

    public async Task<Workflow?> UpdateAsync(int id, UpdateWorkflowRequest request)
    {
        var workflow = await _context.Workflows.FindAsync(id);

        if (workflow is null)
        {
            return null;
        }

        workflow.Name = request.Name;
        workflow.Status = request.Status;
        workflow.Owner = request.Owner;

        await _context.SaveChangesAsync();

        return workflow;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var workflow = await _context.Workflows.FindAsync(id);

        if (workflow is null)
        {
            return false;
        }

        _context.Workflows.Remove(workflow);
        await _context.SaveChangesAsync();

        return true;
    }
}