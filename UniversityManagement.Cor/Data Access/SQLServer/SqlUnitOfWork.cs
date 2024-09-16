using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Cor.Domain.Abstract;

namespace UniversityManagement.Cor.Data_Access.SQLServer
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly string connectionstring;
        public SqlUnitOfWork(string connectionstring)
        {
            connectionstring = connectionstring;
        }
        public ITeacherRepository TeacherRepository => new SqlTeacherRepository(connectionstring);

        public ILessonRepository LessonRepository => new SqlLessonRepository(connectionstring);

        public IStudentRepository studentRepository => new SqlStudentRepository(connectionstring);

        public IStudentLessonRepository studentLessonRepository => throw new NotImplementedException();

        public bool CheckConnection()
        {
            try
            {
                using SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
