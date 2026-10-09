using System;
using System.Collections.Generic;

namespace day4.Models
{
    public class SchoolClass
    {
        public string ClassId { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public List<Student> Students { get; set; } = new List<Student>();

        public SchoolClass()
        {
        }

        public SchoolClass(string classId, string className)
        {
            ClassId = classId;
            ClassName = className;
        }

        public void AddStudent(Student student)
        {
            if (student != null && !Students.Exists(s => s.StudentId == student.StudentId))
            {
                student.ClassId = this.ClassId;
                student.ClassName = this.ClassName;
                Students.Add(student);
            }
        }

        public bool RemoveStudent(string studentId)
        {
            var student = Students.Find(s => s.StudentId == studentId);
            if (student != null)
            {
                return Students.Remove(student);
            }
            return false;
        }

        public override string ToString()
        {
            return ClassName;
        }
    }
}
