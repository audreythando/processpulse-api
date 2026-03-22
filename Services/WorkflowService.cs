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
}