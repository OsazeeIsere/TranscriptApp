namespace TranscriptApp.Models
{
    public class FinalApprovedResult
    {
        public int Id { get; set; }
        [ForeignKey("Sessions")]
        [Display(Name ="Session")]
        public int SessionId { get; set; }
        public Session? Sessions { get; set; }
        [ForeignKey("Departments")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department? Departments { get; set; }
        [ForeignKey("Faculties")]
        [Display(Name = "Faculty")]
        public int FacultyId { get; set; }
        public Faculty? Faculties { get; set; }
        [ForeignKey("Courses")]
        [Display(Name = "Programme Of Study")]
        public int CourseId { get; set; }
        public Course? Courses { get; set; }
        [Display(Name = "Duration of Programme")]
        public string ProgramDuratin { get; set; }
        
        [Display(Name ="Type of Programme")]
        public string ProgramType { get; set; }

        [Display(Name = "Final Approved Result")]
        public byte[]? FileUpload { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }

    }
}
