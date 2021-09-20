using System;

namespace API.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string dataPedido { get; set; }
        public string Produtor { get; set; }
        public string Fazenda { get; set; }
        public int Sacas { get; set; }
    }
}