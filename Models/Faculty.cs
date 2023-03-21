using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TranscriptApp.Models
{
    [Table("Faculties")]
    public class Faculty 
    {
        public int Id { get; set; }
        [Display(Name = "Faculties")]
        public string? Name { get; set; }

        
       
    }
}
