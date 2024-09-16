using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement.Cor.Domain.Abstract
{
    public interface IUnitOfWork
    {
        ITeacherRepository TeacherRepository { get; }
        ILessonRepository LessonRepository { get; }
        IStudentRepository studentRepository { get; }
        IStudentLessonRepository studentLessonRepository { get; }
        bool CheckConnection();
    }
}
