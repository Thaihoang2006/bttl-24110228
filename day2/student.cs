namespace BaiTap.Entity
{
    public class Student
    {
        public string StuID { get; set; }
        public string Name { get; set; }
        public double MidPoint { get; set; }
        public double FinalPoint { get; set; }
        public string Email { get; set; }

        public Student()
        {
        }

        public Student(string stuID, string name, double midPoint,
                       double finalPoint, string email)
        {
            StuID = stuID;
            Name = name;
            MidPoint = midPoint;
            FinalPoint = finalPoint;
            Email = email;
        }

        public double GetAverage()
        {
            return (MidPoint + FinalPoint) / 2;
        }
    }
}