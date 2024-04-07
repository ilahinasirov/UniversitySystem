using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Exam:IEntity
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
        public User User { get; set; }
        public bool IsDeleted { get; set; }

        public List<Question> Questions { get; set; }
        public List<Group> Groups { get; set; }
        public Lesson Lesson { get; set; }
    }
}
