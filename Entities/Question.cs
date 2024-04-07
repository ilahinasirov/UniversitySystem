using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Question:IEntity
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
        public bool IsDeleted { get; set; }
        //public int CorrectOptionId {  get; set; }
        // Option sinifine referans add etmek uchun
        public Option CorrectOption { get; set; }
        public List<Option> Options { get; set; }
        public Exam Exam { get; set; }
    }
}
