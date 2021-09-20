using System.Collections.Generic;

namespace API.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public ICollection<Grao> Graos { get; set; }
        public ICollection<TerritorioProduto> Territorios { get; set; }
    }
}