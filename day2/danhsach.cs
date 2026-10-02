using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiTap.Entity
{
    public class DanhSach
    {
        public List<Student> Students { get; set; }

        public DanhSach()
        {
            Students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void RemoveStudent(string stuID)
        {
            Students.RemoveAll(s => s.StuID == stuID);
        }

        public Student GetStudentById(string stuID)
        {
            return Students.Find(s => s.StuID == stuID);
        }

        public List<Student> GetStudents()
        {
            return Students;
        }

        public List<Student> SortByName()
        {
            return Students
                .OrderBy(s => s.Name)
                .ToList();
        }

        public List<Student> SortByAverageDescending()
        {
            return Students
                .OrderByDescending(s => s.GetAverage())
                .ToList();
        }

        public void Display()
        {
            foreach (Student student in Students)
            {
                Console.WriteLine(
                    $"{student.StuID} | " +
                    $"{student.Name} | " +
                    $"Mid: {student.MidPoint} | " +
                    $"Final: {student.FinalPoint} | " +
                    $"Average: {student.GetAverage():F2} | " +
                    $"{student.Email}"
                );
            }
        }
    }
}