using Elsa.Extensions;
using Elsa.Workflows;
using Elsa.Workflows.Memory;
using Elsa.Workflows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activitys.Requests
{
    public class SetCurrentStep : CodeActivity<Step>
    {
        public Input<ICollection<Step>> steps = default!;
        public SetCurrentStep(Variable<ICollection<Step>> step)
        {
            steps = new Input<ICollection<Step>>(step);
        }
        protected override void Execute(ActivityExecutionContext context)
        {
            var st = steps.Get(context);

            var s = st.OrderBy(x => x.Number).FirstOrDefault(x => !x.SendDate.HasValue);
            if (s != null)
            {
                s.SendDate = DateTime.Now;
            }
            Result.Set(context, s);
        }
    }
}
