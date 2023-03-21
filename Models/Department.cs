
namespace TranscriptApp.Models
{
    [Table("Departments")]

    public class Department
    {
        public int Id { get; set; }
        [Display (Name ="Department")]
        public string? Name { get; set; }
       
        [ForeignKey("Faculties")]
        [Display(Name = "Faculty")]
        public int FacultyId { get; set; }
        public virtual Faculty? Faculties { get; set; }
    }
}