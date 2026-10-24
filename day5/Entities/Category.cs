using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace day5.Entities
{
    /// <summary>
    /// Thực thể Thể loại sách trong Quản Lý Thư Viện (QLTV)
    /// </summary>
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }

        // Mối quan hệ 1 - N: Một thể loại có nhiều cuốn sách
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
