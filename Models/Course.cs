
namespace TranscriptApp.Models
{
    [Table("Courses")]

    public class Course
    {
        public int Id { get; set; }
       
        public string? Name { get; set; }
        public string? Code { get; set; }
         [ForeignKey("Departments")]
        public int DepartmentId { get; set; }
        public Department? Departments { get; set; }
        public DateTime? CreatedAt { get; set; }


    }
}
