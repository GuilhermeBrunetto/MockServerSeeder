namespace API.Entities
{
    public class TerritorioProduto
    {
        public int TerritorioId { get; set; }
        public Territorio Territorio { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}