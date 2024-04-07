using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Group:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Exam> Exams { get; set; }
        public bool IsDeleted { get; set; }

    }
}
