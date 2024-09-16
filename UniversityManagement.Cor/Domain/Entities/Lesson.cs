using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement.Cor.Domain.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public Teacher Teacher { get; set; }
        public string Name { get; set; }
    }
}
