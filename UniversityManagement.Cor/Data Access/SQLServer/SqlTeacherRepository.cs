using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Cor.Domain.Abstract;
using UniversityManagement.Cor.Domain.Entities;

namespace UniversityManagement.Cor.Data_Access.SQLServer
{
    internal class SqlTeacherRepository : ITeacherRepository
    {
        private readonly string connectionstring;
        public SqlTeacherRepository(string connectionstring)
        {
            connectionstring = connectionstring;
        }
        public void Add(Teacher teacher)
        {
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            const string query = @"insert into teachers(Firstname,Lastname,TheLessonTought,Email)
                            values(@firstname,@lastname,@theLessonTought,@email)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("firstname", teacher.Firstname);
            cmd.Parameters.AddWithValue("lastname", teacher.Lastname);
            cmd.Parameters.AddWithValue("theLessonTought", teacher.TheLessonTought);
            cmd.Parameters.AddWithValue("email", teacher.Email);
            cmd.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            const string query = "delete from teachers where id=@id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }
      public Teacher Get(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            const string query = "select *from teachers where id=@id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return SqlMapper.MapTeacher(reader);
            }
            return null;  
        }
        public List<Teacher> GetAll()
        {
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            const string query = "select * from teachers";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Teacher> teachers = new List<Teacher>();

            while (reader.Read())
            {
                Teacher teacher = SqlMapper.MapTeacher(reader);
            }
            return teachers;
        }
        public void Update(Teacher teacher)
        {
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            const string query = @"update teachers set firstname=@firstname,lastname=@lastname,
                         theLessonTought=@theLessonThought,email=@email where id=@id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", teacher.Id);
            cmd.Parameters.AddWithValue("firstname", teacher.Firstname);
            cmd.Parameters.AddWithValue("lastname", teacher.Lastname);
            cmd.Parameters.AddWithValue("thelessontought", teacher.TheLessonTought);
            cmd.Parameters.AddWithValue("email", teacher.Email);

            cmd.ExecuteNonQuery();
        }
    }
}    

