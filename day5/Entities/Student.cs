using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace day5.Entities
{
    /// <summary>
    /// Thực thể Student (Slide 16 & 20)
    /// </summary>
    public class Student
    {
        [Key] // Khóa chính (Slide 16)
        public string StudentId { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public DateTime? DateofBirth { get; set; }

        public string? Address { get; set; }

        // Quan hệ 1 - n: Grade (Lớp học) -> Student (Slide 20 & 22)
        public int? GradeId { get; set; }
        public Grade? Grade { get; set; }

        // Quan hệ n - n với Subject qua bảng trung gian (Slide 16 & 18)
        public IList<StudentSubject> StudentSubjects { get; set; }

        public Student()
        {
            StudentSubjects = new List<StudentSubject>();
        }
    }
}
