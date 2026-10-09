using System;

namespace day4.Models
{
    public class Student
    {
        public string StudentId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string Gender { get; set; } = "Nam";
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public double Score { get; set; } = 0.0;
        public string ClassId { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string Status { get; set; } = "Đang học";

        public Student()
        {
        }

        public Student(string studentId, string fullName, DateTime dateOfBirth, 
                       string gender, string email, string phone, double score, 
                       string classId, string className, string status)
        {
            StudentId = studentId;
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Email = email;
            Phone = phone;
            Score = score;
            ClassId = classId;
            ClassName = className;
            Status = status;
        }
    }
}
