using Elsa.Expressions.Models;
using Elsa.Extensions;
using Elsa.Workflows;
using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Activitys
{
    [Activity("Elsa", "My", "My send an email message.", Kind = ActivityKind.Task)]
    public class MySendEmail: CodeActivity
    {
        public Input<string> Text { get; set; } = default!;
        public Input<string> ApproveName { get; set; } = default!;
        public Input<string> RejectName {  get; set; } = default!;

        [JsonConstructor]
        public MySendEmail(string? source = default, int? line = default) : base(source, line)
        {
        }
       // public MySendEmail(Expression expression, [CallerFilePath] string? source = default, [CallerLineNumber] int? line = default) : this(source, line) => Text = new Input<string>(expression, new MemoryBlockReference());
       // public MySendEmail(Func<ExpressionExecutionContext, string?> text, [CallerFilePath] string? source = default, [CallerLineNumber] int? line = default)
       //: this(Expression.DelegateExpression(text), source, line)
       // {
       // }
        protected override void Execute(ActivityExecutionContext context)
        {
            var eee = context.ExpressionExecutionContext;
            var approve = ApproveName.Get(context);
            var reject = RejectName.Get(context);
            var text = Text.Get(context);
            ///Передача ссылок во вне
            var url = GenerateSignalUrl(eee, approve);
            Console.WriteLine($"Approve {text} {url}");
            url = GenerateSignalUrl(eee, reject);
            Console.WriteLine($"Reject {text} {url}");
            base.Execute(context);
        }
        private string GenerateSignalUrl(ExpressionExecutionContext context, string signalName)
        {
            return context.GenerateEventTriggerUrl(signalName);
        }
    }
}
