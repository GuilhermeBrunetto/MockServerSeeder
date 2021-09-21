using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Entities;

namespace API.DTOs
{
    public class ProdutoDto
    {
        public int ProdutoId { get; set; }
        [Required]
        public string Nome { get; set; }
        public ICollection<TerritorioProduto> Territorios { get; set; }
        public ICollection<Acordo> Acordos { get; set; }
        
    }
}