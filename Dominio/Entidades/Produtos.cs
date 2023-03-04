using Dominio.Enums;


namespace Dominio.Entidades
{
    public class Produtos
    {

        public int ProdutoId { get; set; }


        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public Disponibilidade Disponibilidade { get; set; }
    }
}
