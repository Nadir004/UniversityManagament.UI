using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Cor.Domain.Abstract;
using UniversityManagement.Cor.Domain.Entities;

namespace UniversityManagement.Cor.Data_Access.SQLServer
{
    internal class SqlStudentRepository:IStudentRepository
    {
        private readonly string connectionString;
        public SqlStudentRepository(string connectionString)
        {
            connectionString = connectionString;
        }
        public void Add(Student student)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            const string query = @"insert into students(Firstname,Lastname,Phonenumber)
                               values(@firstname,@lastname,@phonenumber)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("firstname", student.Firstname);
            cmd.Parameters.AddWithValue("lastname", student.Lastname);
            cmd.Parameters.AddWithValue("phonenumber", student.Phonenumber);

            cmd.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            const string query = "delete from students where id=@id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", @id);

            cmd.ExecuteNonQuery();
        }
        public Student Get(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            const string query = "select * from students where id=@id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return SqlMapper.MapStudent(reader);
            }
            return null;
        }
      public List<Student> GetAll()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            const string query = "select*from students";
            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            List<Student> students = new List<Student>();
            while (reader.Read())
            {
                Student student = SqlMapper.MapStudent(reader);
            }
            return students;
        }
        public void Update(Student student)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            const string query = @"update students set firstname=@firstname,lastname=@lastname,
                               phonenumber=@phonenumber where id=@id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", student.Id);
            cmd.Parameters.AddWithValue("firstname", student.Firstname);
            cmd.Parameters.AddWithValue("lastname", student.Lastname);
            cmd.Parameters.AddWithValue("phonenumber", student.Phonenumber);

            cmd.ExecuteNonQuery();
        }
    }
}
 