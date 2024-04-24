using Elsa.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Workflows.UIHints;
using Elsa.Extensions;

namespace Activitys.Requests
{
    [Activity("Activitys", "MyFork", "My Fork.", Kind = ActivityKind.Task)]
    public class Approve: CodeActivity
    {
        [Input(UIHint = InputUIHints.SingleLine, Description = "Согласующий")]
        public Input<string> Person { get; set; } = default!;
        protected override void Execute(ActivityExecutionContext context)
        {
            var approver = Person.Get(context);
            Console.WriteLine(nameof(Approve) + " " + approver);
        }
    }
}
