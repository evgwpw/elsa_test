using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elsa.Extensions;
using Elsa.Workflows;
using Elsa.Workflows.Models;
//using Elsa.Workflows.Core.Models;

namespace Activitys
{
   
    public class MyActivity: CodeActivity<string>
    {
        public Input<string> Name1 { get; set; } = default!;
        protected override void Execute(ActivityExecutionContext context)
        {
            var name = Name1.Get(context);

            //context.SetResult(name + Random.Shared.Next());
            // base.Execute(context);
            Result.Set(context, name + Random.Shared.Next());
        }
    }
}
