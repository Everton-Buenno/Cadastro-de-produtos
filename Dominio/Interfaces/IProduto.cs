using Dominio.Entidades;


namespace Dominio.Interfaces
{
    public interface IProduto
    {

        Task<List<Produtos>> ObterTodos();
        Task<Produtos> BuscarPorId(int Id);
        Task Adicionar(Produtos produto);
        Task Atualizar(Produtos produto);
        Task Deletar(Produtos produtos);
    }
}
