﻿using Elsa.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activitys.Requests
{
    public class SdTask: CodeActivity
    {
        protected override void Execute(ActivityExecutionContext context)
        {
            base.Execute(context);
            Console.WriteLine(nameof(SdTask));
        }
    }
}
