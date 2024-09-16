using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Cor.Domain.Enums;

namespace UniversityManagement.Cor.Domain.Entities
{
     public class Teacher
    {
        public int Id { get; set; } 
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public TheLessonTought TheLessonTought { get; set; }
        public string Email { get; set; }
    }
}
