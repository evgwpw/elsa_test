
using Elsa.Expressions.Models;
using Elsa.Extensions;
using Elsa.Workflows;
using Elsa.Workflows.Activities;
using Elsa.Workflows.Contracts;
using Elsa.Workflows.Memory;
using Elsa.Workflows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Activitys.Requests
{
    public class Workl : WorkflowBase
    {
        private Variable<Step> step = new Variable<Step>();
        private Variable<ICollection<Step>> steps = new Variable<ICollection<Step>>();
        private SetCurrentStep setCurrent = default!;
        private Sequence Body = default!;
        public Input<ICollection<Step>> Steps { get; set; } = default!;
        protected override void Build(IWorkflowBuilder builder)
        {
            var sts = builder.WithVariable(steps);
            builder.WithVariable(step);
            //Body = new Sequence() 
            //{
            //    Activities = 
            //    {
            //        new OneStep(step),
            //        setCurrent
            //    }
            //};
            builder.Root = new Sequence()
            {
                Activities = 
                {
                    new SetVariable<ICollection<Step>>(steps,Steps),
                    new SetCurrentStep(steps, step),
                    new While(ctx => Condition(ctx), new Sequence
                    {
                        Activities = 
                        {
                            new OneStep(step),
                            new SetCurrentStep(steps, step)
                        }
                    })
                }
            
            };
            
        }
        //public Workl(ICollection<Step> stepsArg)
        //{
        //    steps = new Variable<ICollection<Step>>(stepsArg);
        //}
        public Workl() { 
        //steps = new Variable<ICollection<Step>>(Steps.Get(this.))
        }
        private bool Condition(ExpressionExecutionContext context)
        {
            var res = step.Get(context);// GetResult<Step>(context);
            //step = new Variable<Step>(res);
           // step.Value = res;
            return res != null;
        }
    }
}
