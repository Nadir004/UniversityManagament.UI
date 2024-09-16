using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Cor.Domain.Entities;

namespace UniversityManagement.Cor.Domain.Abstract
{
    public interface  IStudentLessonRepository
    {
        void Add(StudentLesson studentLesson);
        void Delete(int id);
        List<StudentLesson> GetByStudentId(int StudentId);
        List<StudentLesson> GetByLessonId(int LessonId);
    }
}
