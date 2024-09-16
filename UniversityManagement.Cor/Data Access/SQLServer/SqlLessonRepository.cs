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
    internal class SqlLessonRepository:ILessonRepository
    {
        private readonly string connectionString;
        public SqlLessonRepository(string connectionString)
        {
            connectionString = connectionString;
        }
        public void Add(Lesson lesson)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            const string query = @"insert into lessons(teacher.id,name)
                                   values(@teacher.Id,@name)";

            SqlCommand cmd  = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("teacher.id", lesson.Teacher.Id);
            cmd.Parameters.AddWithValue("name", lesson.Name);

            cmd.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            const string query = "delete from lessons where id=@id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        } 
        public Lesson Get(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            const string query = "select *from lessons where id=@id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return SqlMapper.MapLesson(reader);
            }
            return null;
        }
        public List<Lesson> GetAll()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            const string query = "select * from lessons";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Lesson> lessons = new List<Lesson>();
            while (reader.Read())
            {
                Lesson lesson  = SqlMapper.MapLesson(reader);
            }
            return lessons;
        }
        public void Update(Lesson lesson)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            const string query = @"update lessons set teacher.Id=@teacher.Id,name=@name 
                                where id=@id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("teacher.Id", lesson.Teacher.Id);
            cmd.Parameters.AddWithValue("name", lesson.Name);

            cmd.ExecuteNonQuery();
        }
    }
}
