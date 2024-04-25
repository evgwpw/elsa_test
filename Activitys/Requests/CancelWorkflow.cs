using Elsa.Workflows;
using Elsa.Workflows.Runtime.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activitys.Requests
{
    public class CancelWorkflow: CodeActivity
    {
        protected override void Execute(ActivityExecutionContext context)
        {
           // var cancelService = context.GetRequiredService<IWorkflowCancellationService>();
            context.WorkflowExecutionContext.Cancel();
            base.Execute(context);
        }
    }
}
