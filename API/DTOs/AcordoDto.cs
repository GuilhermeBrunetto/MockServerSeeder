using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class AcordoDto
    {
        public int Id { get; set; }
        [Required]
        public string Contrato { get; set; }
        [Required]
        public string Moeda { get; set; }
        [Required]
        public string Variacao { get; set; }
        [Required]
        public int ProdutoId { get; set; }
    }
}