using Elsa.Expressions.Models;
using Elsa.Extensions;
using Elsa.Workflows;
using Elsa.Workflows.Activities;
using Elsa.Workflows.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activitys
{
    public class RequestWorkflow : WorkflowBase
    {
        protected override void Build(IWorkflowBuilder builder)
        {
            var intVar = builder.WithVariable<int>();
            var rand = new Random();
            builder.Root = new Sequence
            {

                Activities = {
                    new SetVariable<int>
                    {
                        Variable = intVar,
                        Value = new Elsa.Workflows.Models.Input<int>(()=>rand.Next(1, 3))
                    },
                    new Switch()
                    {
                        Cases =
                        {
                            new SwitchCase
                            {
                                Activity = new WriteLine("1"),
                                Condition = Expression.LiteralExpression(1),
                                Label = "1"
                            },
                            new SwitchCase
                            {
                                Activity = new WriteLine("2"),
                                Condition = Expression.LiteralExpression(2),
                                Label = "2"
                            },
                               new SwitchCase
                            {
                                Activity = new WriteLine("3"),
                                Condition = Expression.LiteralExpression(3),
                                Label = "3"
                            }
                        }
                    }
                }
            };
        }
    }
}
