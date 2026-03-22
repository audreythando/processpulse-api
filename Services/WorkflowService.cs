using ProcessPulse.Api.Models;

namespace ProcessPulse.Api.Services;

public class WorkflowService
{
    private readonly  List<Workflow>  _workflows = new()
    {
        new Workflow
        {
            Id = 1,
            Name = "Employee Onboarding",
            Status = "Active",
            Owner = "HR Team"
        },

        new Workflow
        {
            Id = 2,
            Name = "Invoice Approval",
            Status = "Pending",
            Owner = "Finannce Team"
        }
    };

    public List<Workflow> GetAll()
    {
        return _workflows;
    }

    public Workflow GetById(int id)
    {
        // return _workflows.FirstOrDefault(w => w.Id == id);
        return _workflows[id - 1];
    }

    public Workflow Create(Workflow workflow)
    {
        var nextId = _workflows.Any() ?  _workflows.Max(w => w.Id) + 1 : 1;
        workflow.Id = nextId;
        workflow.CreatedAt = DateTime.Now;

        _workflows.Add(workflow);

        return workflow;
    }


    public bool Update(int id, Workflow workflow)
    {
        var existingWorkflow = _workflows.FirstOrDefault(w => w.Id == id);

        if (existingWorkflow == null)
        {
            return false;
        }

        existingWorkflow.Name = workflow.Name;
        existingWorkflow.Status = workflow.Status;
        existingWorkflow.Owner = workflow.Owner;

        return true;
    }

    public bool Delete(int id)
    {
        var workflow = _workflows.FirstOrDefault(w => w.Id == id);

        if (workflow == null)
        {
            return false;
        }

        _workflows.Remove(workflow);

        return true;
    }
}