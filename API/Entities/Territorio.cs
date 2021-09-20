using System.Collections.Generic;

namespace API.Entities
{
    public class Territorio
    {
        public int TerritorioId { get; set; }
        public string Nome { get; set; }
        public string Bolsa { get; set; }
        public ICollection<TerritorioProduto> Produtos { get; set; }
    }
}