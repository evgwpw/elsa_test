﻿using Elsa.Extensions;
using Elsa.Workflows.Activities;
using Elsa.Workflows.Memory;
using Elsa.Workflows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activitys.Requests
{
    public class OneStep : Composite
    {
        public Input<Step> Input { get; set; } = default!;
        public OneStep(Variable<Step> variable)
        {
            Input = new Input<Step>(variable);
            Root = new Switch()
            {
                Cases =
                [
                    new SwitchCase("Approve", c => Input.Get(c).StepType == StepTypes.Approve, new Approve()),
                    new SwitchCase("AdditionalApprove", c => Input.Get(c).StepType == StepTypes.AdditionalApprove, new AdditionalApprove()),
                    new SwitchCase("Inform", c => Input.Get(c).StepType == StepTypes.Inform, new Inform()),
                    new SwitchCase("SdTask", c => Input.Get(c).StepType == StepTypes.SdTask, new SdTask()),
                    new SwitchCase("Send", c => Input.Get(c).StepType == StepTypes.Send, new Send()),
                    new SwitchCase("Transfer", c => Input.Get(c).StepType == StepTypes.Transfer, new Transfer())
                ],
                Default = new WriteLine("Нет ничего")
            };
        }
    }
}
