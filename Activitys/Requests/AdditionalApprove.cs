using Elsa.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elsa.Workflows.Attributes;
using Elsa.Workflows.Activities;
using Elsa.Workflows.Models;
using Elsa.Expressions.Models;
using Elsa.Extensions;
using Elsa.Workflows.Runtime.Activities;

namespace Activitys.Requests
{
    [Activity("Activitys", "MyFork", "My Fork.", Kind = ActivityKind.Task)]
    public class AdditionalApprove: Composite<bool>
    {
        public Input<string> ActivityName { get; set; } = default!;
        public Input<string> ApproveName { get; set; } = default!;
        public Input<string> RejectName { get; set; } = default!;
        public AdditionalApprove()
        {
            Root = new Sequence
            {
                Activities =
                {
                    new MySendEmail
                    {
                        ApproveName = new (context => ApproveName.Get(context)),
                        RejectName = new (context => RejectName.Get(context)),
                        Text = new (context => ActivityName.Get(context))
                    },
                    new Fork
                    {
                        JoinMode = ForkJoinMode.WaitAny,
                        Branches =
                        {
                            new Sequence
                            {
                                Activities =
                                {
                                    new Event(c=>ApproveName.Get(c)),
                                    new WriteLine(c=> $"Approve {ActivityName.Get(c)}")
                                }
                            },
                            new Sequence
                            {
                                Activities =
                                {
                                    new Event(c=>RejectName.Get(c)),
                                    new WriteLine(c=> $"Reject {ActivityName.Get(c)}"),
                                    new CancelWorkflow()
                                }
                            }
                        }
                    }
                }
            };
        }
        //protected override void Execute(ActivityExecutionContext context)
        //{
        //    base.Execute(context);
        //    Console.WriteLine(nameof(AdditionalApprove));
        //}
       
    }
}
