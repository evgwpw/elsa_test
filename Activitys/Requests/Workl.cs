
using Elsa.Expressions.Models;
using Elsa.Extensions;
using Elsa.Workflows;
using Elsa.Workflows.Activities;
using Elsa.Workflows.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Activitys.Requests
{
    public class Workl : Sequence
    {
        private Variable<Step> step = new Variable<Step>();
        private Variable<ICollection<Step>> steps = new Variable<ICollection<Step>>();
        private SetCurrentStep setCurrent = default!;
        private Sequence Body = default!;
        public Workl()
        {
            Body = new Sequence()
            {
                Variables = [step, steps],
                Activities = 
                [
                    new OneStep(step),
                    setCurrent
                ]
            };
            setCurrent = new SetCurrentStep(steps);
            Variables = [step, steps];
            Activities =
            [
                setCurrent,
                new While(Condition, Body)
            ];
        }
        private bool Condition(ExpressionExecutionContext context)
        {
            var res = setCurrent.GetResult<Step>(context);
            step = new Variable<Step>(res);
            return res != null;
        }
    }
}
