using System;
using System.ComponentModel.DataAnnotations;

namespace day5.Entities
{
    /// <summary>
    /// Thực thể Độc giả trong Quản Lý Thư Viện (QLTV)
    /// </summary>
    public class Reader
    {
        [Key]
        public int ReaderId { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        public DateTime? RegisteredDate { get; set; } = DateTime.Now;
    }
}
