using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Lesson:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public bool IsDeleted { get; set; }
        public List<Exam> Exams { get; set; }
        public List<Group> Groups { get; set; }
        public List<User> Users { get; set; }

    }
}
