using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class GraoDto
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        
    }
}