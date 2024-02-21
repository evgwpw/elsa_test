using Elsa.Extensions;
using Elsa.Http;
using Elsa.Workflows;
using Elsa.Workflows.Activities;
using Elsa.Workflows.Contracts;
using Elsa.Workflows.Runtime.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activitys
{
    public class MySendWorkflow : WorkflowBase
    {
        protected override void Build(IWorkflowBuilder builder)
        {
            var approvedVariable = builder.WithVariable<bool>();
            builder.Root = new Sequence
            {
                Activities =
                {
                    new MySendEmail(),
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
                    },

                    new WriteLine(ct=>ct.GetVariable(approvedVariable.Name)?.Value?.ToString())
                }
            };
        }
    }
}
