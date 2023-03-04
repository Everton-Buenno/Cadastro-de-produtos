using Aplicação.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicação.Aplicação
{
    public class AplicacaoProdutos : IAplicacaoProdutos
    {

        private readonly IProduto _produto;

        public AplicacaoProdutos(IProduto produto)
        {
            _produto = produto;
        }

        public async Task Adicionar(Produtos produto)
        {
            await _produto.Adicionar(produto);
        }

        public async Task Atualizar(Produtos produto)
        {
            await _produto.Atualizar(produto);
        }

        public async Task<Produtos> BuscarPorId(int Id)
        {
            return await _produto.BuscarPorId(Id);
        }

        public async Task Deletar(Produtos produtos)
        {
            await _produto.Deletar(produtos);
        }

        public async Task<List<Produtos>> ObterTodos()
        {
            return await _produto.ObterTodos();
        }
    }
}
