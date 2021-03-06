using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    public class Acordo
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
        public Produto Produto { get; set; }
    }
}