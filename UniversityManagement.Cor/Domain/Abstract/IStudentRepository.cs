using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Cor.Domain.Entities;

namespace UniversityManagement.Cor.Domain.Abstract
{
    public interface IStudentRepository
    {
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);
        Student Get(int id);
        List<Student> GetAll();


    }
}
