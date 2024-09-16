using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Cor.Domain.Entities;

namespace UniversityManagement.Cor.Domain.Abstract
{
    public interface ITeacherRepository
    {
        void Add(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(int id);
        Teacher Get(int id);
        List<Teacher> GetAll();
    }
}
