using System;
using System.Collections.Generic;
using System.Linq;
using day4.Models;

namespace day4.Services
{
    public class StudentManager
    {
        public List<SchoolClass> Classes { get; set; } = new List<SchoolClass>();

        public StudentManager()
        {
            SeedInitialData();
        }

        private void SeedInitialData()
        {
            var classKtpm = new SchoolClass("KTPM01", "Kỹ thuật phần mềm 01");
            var classTtnt = new SchoolClass("TTNT01", "Trí tuệ nhân tạo 01");
            var classKhdl = new SchoolClass("KHDL01", "Khoa học dữ liệu 01");

            classKtpm.AddStudent(new Student(
                "SV000123", "Nguyễn Văn An", new DateTime(2006, 8, 15),
                "Nam", "an.nv@vju.ac.vn", "0912345678", 8.5,
                classKtpm.ClassId, classKtpm.ClassName, "Đang học"
            ));

            classTtnt.AddStudent(new Student(
                "SV000124", "Trần Minh Anh", new DateTime(2006, 1, 22),
                "Nữ", "anh.tm@vju.ac.vn", "0987654321", 9.0,
                classTtnt.ClassId, classTtnt.ClassName, "Đang học"
            ));

            classKtpm.AddStudent(new Student(
                "SV000125", "Lê Hoàng Bình", new DateTime(2006, 5, 9),
                "Nam", "binh.lh@vju.ac.vn", "0355556677", 7.4,
                classKtpm.ClassId, classKtpm.ClassName, "Đang học"
            ));

            classKhdl.AddStudent(new Student(
                "SV000126", "Đỗ Thị Hồng", new DateTime(2006, 11, 30),
                "Nữ", "hong.dt@vju.ac.vn", "0777888999", 8.1,
                classKhdl.ClassId, classKhdl.ClassName, "Đang học"
            ));

            Classes.Add(classKtpm);
            Classes.Add(classTtnt);
            Classes.Add(classKhdl);
        }

        public List<Student> GetAllStudents()
        {
            return Classes.SelectMany(c => c.Students).OrderBy(s => s.StudentId).ToList();
        }

        public bool Exists(string studentId)
        {
            return Classes.Any(c => c.Students.Any(s => s.StudentId.Equals(studentId, StringComparison.OrdinalIgnoreCase)));
        }

        public bool AddStudent(Student student)
        {
            if (student == null || Exists(student.StudentId)) return false;

            var targetClass = Classes.FirstOrDefault(c => c.ClassName == student.ClassName);
            if (targetClass == null)
            {
                targetClass = new SchoolClass($"CLASS{Classes.Count + 1}", student.ClassName);
                Classes.Add(targetClass);
            }

            student.ClassId = targetClass.ClassId;
            student.ClassName = targetClass.ClassName;
            targetClass.AddStudent(student);
            return true;
        }

        public bool UpdateStudent(Student updatedStudent)
        {
            if (updatedStudent == null) return false;

            Student? existing = null;
            SchoolClass? oldClass = null;

            foreach (var c in Classes)
            {
                var s = c.Students.FirstOrDefault(st => st.StudentId.Equals(updatedStudent.StudentId, StringComparison.OrdinalIgnoreCase));
                if (s != null)
                {
                    existing = s;
                    oldClass = c;
                    break;
                }
            }

            if (existing == null || oldClass == null) return false;

            // Update basic info
            existing.FullName = updatedStudent.FullName;
            existing.DateOfBirth = updatedStudent.DateOfBirth;
            existing.Gender = updatedStudent.Gender;
            existing.Email = updatedStudent.Email;
            existing.Phone = updatedStudent.Phone;
            existing.Score = updatedStudent.Score;
            existing.Status = updatedStudent.Status;

            // If class changed, move student
            if (oldClass.ClassName != updatedStudent.ClassName)
            {
                oldClass.RemoveStudent(existing.StudentId);

                var newClass = Classes.FirstOrDefault(c => c.ClassName == updatedStudent.ClassName);
                if (newClass == null)
                {
                    newClass = new SchoolClass($"CLASS{Classes.Count + 1}", updatedStudent.ClassName);
                    Classes.Add(newClass);
                }

                existing.ClassId = newClass.ClassId;
                existing.ClassName = newClass.ClassName;
                newClass.AddStudent(existing);
            }

            return true;
        }

        public bool DeleteStudent(string studentId)
        {
            foreach (var c in Classes)
            {
                if (c.RemoveStudent(studentId))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Student> Search(string keyword, string? className, double minScore)
        {
            var query = GetAllStudents().AsEnumerable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim().ToLowerInvariant();
                query = query.Where(s =>
                    s.StudentId.ToLowerInvariant().Contains(keyword) ||
                    s.FullName.ToLowerInvariant().Contains(keyword) ||
                    s.Email.ToLowerInvariant().Contains(keyword) ||
                    s.Phone.ToLowerInvariant().Contains(keyword)
                );
            }

            if (!string.IsNullOrWhiteSpace(className) && className != "Tất cả lớp")
            {
                query = query.Where(s => s.ClassName == className);
            }

            if (minScore > 0)
            {
                query = query.Where(s => s.Score >= minScore);
            }

            return query.ToList();
        }
    }
}
