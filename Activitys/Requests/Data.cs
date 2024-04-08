using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activitys.Requests
{
    public class Data
    {
        public static readonly IList<IList<Step>> Steps = new List<IList<Step>>()
        {
            new List<Step>()
            {
                new Step()
                {
                    Id = 1,
                    Email = "q1@q.ru",
                    Name = "Name1",
                    Number = 1,
                    StepType =  StepTypes.Approve,
                    Title = "Title1"
                },
                 new Step()
                {
                    Id = 2,
                    Email = "q1@q.ru",
                    Name = "Name2",
                    Number = 2,
                    StepType =  StepTypes.SdTask,
                    Title = "Title2"
                }, new Step()
                {
                    Id = 3,
                    Email = "q3@q.ru",
                    Name = "Name",
                    Number = 3,
                    StepType =  StepTypes.AdditionalApprove,
                    Title = "Title3"
                }, new Step()
                {
                    Id = 4,
                    Email = "q4@q.ru",
                    Name = "Name4",
                    Number = 4,
                    StepType =  StepTypes.SdTask,
                    Title = "Title4"
                },
                  new Step()
                {
                    Id = 5,
                    Email = "q5@q.ru",
                    Name = "Name5",
                    Number = 5,
                    StepType =  StepTypes.SendData,
                    Title = "Title5"
                }, new Step()
                {
                    Id = 6,
                    Email = "q6@q.ru",
                    Name = "Name6",
                    Number = 6,
                    StepType =  StepTypes.Approve,
                    Title = "Title6"
                },
                   new Step()
                {
                    Id = 7,
                    Email = "q7@q.ru",
                    Name = "Name7",
                    Number = 7,
                    StepType =  StepTypes.Send,
                    Title = "Title7"
                }
            },
            new List<Step>()
            {
                 new Step()
                {
                    Id = 8,
                    Email = "q10@q.ru",
                    Name = "Name",
                    Number = 1,
                    StepType =  StepTypes.Approve,
                    Title = "Title10"
                },
                  new Step()
                {
                    Id = 9,
                    Email = "q11@q.ru",
                    Name = "Name",
                    Number = 2,
                    StepType =  StepTypes.AdditionalApprove,
                    Title = "Title11"
                },
                   new Step()
                {
                    Id = 10,
                    Email = "q12@q.ru",
                    Name = "Name",
                    Number = 3,
                    StepType =  StepTypes.Approve,
                    Title = "Title12"
                },
                    new Step()
                {
                    Id = 11,
                    Email = "q13@q.ru",
                    Name = "Name",
                    Number = 4,
                    StepType =  StepTypes.SdTask,
                    Title = "Title13"
                }, new Step()
                {
                    Id = 12,
                    Email = "q14@q.ru",
                    Name = "Name",
                    Number = 5,
                    StepType =  StepTypes.Approve,
                    Title = "Title14"
                },
                     new Step()
                {
                    Id = 13,
                    Email = "q15@q.ru",
                    Name = "Name",
                    Number = 6,
                    StepType =  StepTypes.Inform,
                    Title = "Title15"
                }, new Step()
                {
                    Id = 14,
                    Email = "q61@q.ru",
                    Name = "Name",
                    Number = 7,
                    StepType =  StepTypes.Transfer,
                    Title = "Title16"
                }

            }
        };
    }
}
