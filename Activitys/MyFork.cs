using Elsa.Http;
using Elsa.Workflows;
using Elsa.Workflows.Activities;
using Elsa.Workflows.Memory;
using Elsa.Workflows.Runtime.Activities;
using Elsa.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elsa.Workflows.Attributes;

namespace Activitys
{
    [Activity("Activitys", "MyFork", "My Fork.", Kind = ActivityKind.Task)]
    public class MyFork: Composite<bool>
    {
        private readonly Variable<bool> approvedVariable = new();
        MyFork() 
        {
            Root = new Sequence
            {
                Activities = 
                {
                    new Fork
                    {
                        JoinMode = ForkJoinMode.WaitAny,
                        Branches =
                        {
                            new Sequence
                            {
                                Activities =
                                {
                                    new Event("Approve"),
                                    
                                    new SetVariable
                                    {
                                        Variable = approvedVariable,
                                        Value = new(true)
                                    },
                                    new WriteHttpResponse
                                    {
                                        Content = new("Approve"),
                                    }
                                }
                            },
                            new Sequence
                            {
                                Activities  =
                                {
                                    new Event("Reject"),
                                    new SetVariable
                                    {
                                        Variable = approvedVariable,
                                        Value = new(false)
                                    },
                                    new WriteHttpResponse
                                    {
                                        Content = new("Reject"),
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
        protected override void OnCompleted(ActivityCompletedContext context)
        {
            var res = approvedVariable.Get<bool>(context.TargetContext);
            context.TargetContext.Set(Result, res);
        }
    }
}
