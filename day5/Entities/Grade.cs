using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace day5.Entities
{
    /// <summary>
    /// Thực thể Lớp học (Grade) theo Slide 20 & 22
    /// </summary>
    public class Grade
    {
        [Key] // Khóa chính
        public int GradeId { get; set; }

        public string GradeName { get; set; } = string.Empty;

        public string? Section { get; set; }

        // Quan hệ 1 - n: Một Grade có danh sách nhiều Student
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
