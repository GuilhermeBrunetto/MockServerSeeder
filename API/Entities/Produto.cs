using System.Collections.Generic;

namespace API.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public ICollection<TerritorioProduto> Territorios { get; set; }
        public ICollection<Acordo> Acordos { get; set; }
    }
}