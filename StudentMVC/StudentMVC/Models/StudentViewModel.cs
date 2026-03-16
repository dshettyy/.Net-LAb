namespace StudentMVC.Models
{
    public class StudentViewModel
    {
        public required string Name { get; set; }
        public required string USN { get; set; }

        public int Subject1 { get; set; }
        public int Subject2 { get; set; }
        public int Subject3 { get; set; }
        public int Subject4 { get; set; }
        public int Subject5 { get; set; }
        public int Subject6 { get; set; }
        public int TotalMarks => Subject1 + Subject2 + Subject3 + Subject4 + Subject5 + Subject6;

        public double Average => TotalMarks / 6.0;
    }
}
