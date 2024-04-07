using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Option:IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsDeleted { get; set; }
        public int QuestionId { get; set; } 
        public string CorrectOption { get; set; }
        public Question Question { get; set; }

    }
}
