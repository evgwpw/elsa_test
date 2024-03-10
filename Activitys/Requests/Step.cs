using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activitys.Requests
{
    public class Step
    {
        public string? Name {  get; set; }
        public string? Title { get; set; }
        public StepTypes StepType { get; set; }
        public int Id { get; set; }
        public int Number { get; set; }
        public string? Email {  get; set; } 
        public DateTime? SendDate { get; set; }
    }
}
