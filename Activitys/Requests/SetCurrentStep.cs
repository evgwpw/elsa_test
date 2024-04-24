using Elsa.Extensions;
using Elsa.Workflows;
using Elsa.Workflows.Memory;
using Elsa.Workflows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elsa.Workflows.Attributes;

namespace Activitys.Requests
{
    [Activity("Activitys", "MyFork", "My Fork.", Kind = ActivityKind.Task)]
    public class SetCurrentStep : CodeActivity
    {
        public Input<ICollection<Step>> steps = default!;
        public Output<Step> output = default!;
        public SetCurrentStep(Variable<ICollection<Step>> step, Variable<Step> variable)
        {
            steps = new Input<ICollection<Step>>(step);
            output = new Output<Step>(variable);
           // Result = new Output<Step>();
        }
        protected override void Execute(ActivityExecutionContext context)
        {
            var st = steps.Get(context);

            var s = st.OrderBy(x => x.Number).FirstOrDefault(x => !x.SendDate.HasValue);
            if (s != null)
            {
                s.SendDate = DateTime.Now;
            }
            output.Set(context, s);
           // Result.Set(context, s);
        }
    }
}
