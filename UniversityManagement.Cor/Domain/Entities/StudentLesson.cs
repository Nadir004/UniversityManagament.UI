using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement.Cor.Domain.Entities
{
     public class StudentLesson
    {
        public int Id { get; set; }
        public Lesson Lesson { get; set; }
        public Student Student { get; set; }
    }
}
