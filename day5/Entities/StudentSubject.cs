using System.ComponentModel.DataAnnotations.Schema;

namespace day5.Entities
{
    /// <summary>
    /// Bảng trung gian quan hệ n - n giữa Student và Subject (Slide 16 & 18)
    /// </summary>
    public class StudentSubject
    {
        public string StudentId { get; set; } = string.Empty;
        public Student? Student { get; set; }

        public string SubjectId { get; set; } = string.Empty;
        public Subject? Subject { get; set; }

        public double? Score { get; set; }
    }
}
