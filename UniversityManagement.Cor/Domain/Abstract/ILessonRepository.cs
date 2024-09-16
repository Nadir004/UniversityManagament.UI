using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Cor.Domain.Entities;

namespace UniversityManagement.Cor.Domain.Abstract
{
    public interface ILessonRepository
    {
        void Add(Lesson lesson);
        void Update(Lesson lesson);
        void Delete(int id);
        Lesson Get(int id);
        List<Lesson> GetAll();
    }
}
