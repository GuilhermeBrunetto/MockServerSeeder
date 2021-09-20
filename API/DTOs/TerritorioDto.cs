using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Entities;

namespace API.DTOs
{
    public class TerritorioDto
    {
        public int TerritorioId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Bolsa { get; set; }
        public ICollection<TerritorioProduto> Produtos { get; set; }
    
    }
}