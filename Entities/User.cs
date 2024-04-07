using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User :IdentityUser, IEntity
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        //public string Email { get; set; }


        //public int RoleId { get; set; }
        //public Role Role { get; set; }

        public List<Group> Groups { get; set; }
        public List<Exam> Exams { get; set; }
        public List<Lesson> Lessons { get; set; }

      
    }
}
