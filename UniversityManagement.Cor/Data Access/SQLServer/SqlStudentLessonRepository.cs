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
    internal class SqlStudentLessonRepository:IStudentLessonRepository
    {
        private readonly string connectionstring;
        public SqlStudentLessonRepository(string connectionstring)
        {
            connectionstring = connectionstring;
        }
        public void Add(StudentLesson studentlesson)
        {
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            const string query = "insert into studentLessons(studentid,lessonid) values(@studentid,@lessonid)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("studentId", studentlesson.Student.Id);
            cmd.Parameters.AddWithValue("lessonId", studentlesson.Lesson.Id);

            cmd.ExecuteNonQuery();

        }
        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            const string query = "delete from studentlessons where id=@id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }
        public List<StudentLesson> GetByStudentId(int studentId)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            const string query = @"
 select
ab.Id,
LessonId,
TeacherId LessonTeacherId,
Name LessonName,
b.Id StudentId,
Firstname StudentFirstname,
Lastname StudentLastname,
Phonenumber StudentPhonenumber
from StudentLessons ab
join Lessons a on a.Id=ab.LessonId
join Students b on b.Id=ab.StuduentId
where ab.studentid=@studentid";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("studentId", studentId);
            SqlDataReader reader = cmd.ExecuteReader();
            List<StudentLesson> studentLessons = new List<StudentLesson>();
            while (reader.Read())
            {
                StudentLesson studentlesson = SqlMapper.MapStudentLesson(reader);
                studentLessons.Add(studentlesson);
            }
            return studentLessons;
        }
        public List<StudentLesson> GetByLessonId(int lessonId)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            const string query = @"
 select
ab.Id,
LessonId,
TeacherId LessonTeacherId,
Name LessonName,
b.Id StudentId,
Firstname StudentFirstname,
Lastname StudentLastname,
Phonenumber StudentPhonenumber
from StudentLessons ab
join Lessons a on a.Id=ab.LessonId
join Students b on b.Id=ab.StuduentId
where ab.lessonid=@lessonId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("lessonId", lessonId);
            SqlDataReader reader = cmd.ExecuteReader();
            List<StudentLesson> studentLessons = new List<StudentLesson>();
            while (reader.Read())
            {
                StudentLesson studentlesson = SqlMapper.MapStudentLesson(reader);
                studentLessons.Add(studentlesson);
            }
            return studentLessons;
        }
    }
}
