using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace day5.Entities
{
    /// <summary>
    /// Thực thể Môn học (Subject) theo Slide 18
    /// </summary>
    public class Subject
    {
        [Key]
        public string SubjectId { get; set; } = string.Empty;

        public string SubjectName { get; set; } = string.Empty;

        public int Credit { get; set; } = 3;

        // Quan hệ 1 - n với StudentSubject
        public IList<StudentSubject> StudentSubjects { get; set; }

        public Subject()
        {
            StudentSubjects = new List<StudentSubject>();
        }
    }
}
