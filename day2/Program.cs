using BaiTap.Entity;

var subject = new SubjectStudent();

Console.WriteLine("DANH SACH SINH VIEN");

foreach (var student in subject.GetStudents())
{
    Console.WriteLine(
        $"{student.StuID} - {student.Name} - Mid: {student.MidPoint} - Final: {student.FinalPoint} - Email: {student.Email}"
    );
}