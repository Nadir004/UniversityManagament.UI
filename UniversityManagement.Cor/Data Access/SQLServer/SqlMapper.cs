using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Cor.Domain.Entities;
using UniversityManagement.Cor.Domain.Enums;

namespace UniversityManagement.Cor.Data_Access.SQLServer
{
    internal static class SqlMapper
    {
        internal static Teacher MapTeacher(SqlDataReader reader)
        {
            return new Teacher
            {
                Id = (int)reader["Id"],
                Firstname = (string)reader["Firstname"],
                Lastname = (string)reader["Lastname"],
                TheLessonTought = (TheLessonTought)reader["TheLessonThought"],
                Email = (string)reader["Email"]
            };
        }
        internal static Lesson MapLesson(SqlDataReader reader)
        {
             Lesson lesson = new Lesson
            {
                Name = (string)reader["Name"],

                Teacher = new Teacher
                {
                    Id = (int)reader["Id"]
                   
                }
            };
            return lesson;
        }
        internal static Student MapStudent(SqlDataReader reader)
        {
            return new Student
            {
                Id = (int)reader["Id"],
                Firstname = (string)reader["Firstname"],
                Lastname = (string)reader["Lastname"],
                Phonenumber = (int)reader["Phonenumber"]
            };
        }
        internal static StudentLesson MapStudentLesson(SqlDataReader reader)
        {
            return new StudentLesson
            {
                Id = (int)reader["Id"],
                Lesson = new Lesson
                {
                    Id = (int)reader["LessonId"],
                    Name = (String)reader["LessonName"],
                    Teacher = new Teacher
                    {
                        Id = (int)reader["LessonTeacherId"]
                    }
                },
                Student = new Student
                {
                    Id = (int)reader["StudentId"],
                    Firstname = (string)reader["StudentFirstname"],
                    Lastname = (string)reader["StudentLastname"],
                    Phonenumber = (int)reader["StudentPhonenumber"]
                }
            };
            
        }
    }
}
