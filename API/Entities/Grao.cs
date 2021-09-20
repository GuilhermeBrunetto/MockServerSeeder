using System.Collections.Generic;

namespace API.Entities
{
    public class Grao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        // public int ProdutoId { get; set; }
        public ICollection<Acordo> Acordos { get; set; }
    }
}