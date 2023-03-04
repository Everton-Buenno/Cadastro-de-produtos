using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicação.Interfaces
{
    public interface IAplicacaoProdutos
    {
        Task<List<Produtos>> ObterTodos();
        Task<Produtos> BuscarPorId(int Id);
        Task Adicionar(Produtos produto);
        Task Atualizar(Produtos produto);
        Task Deletar(Produtos produtos);

    }
}
