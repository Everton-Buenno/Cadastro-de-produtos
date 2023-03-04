using Dominio.Entidades;
using Dominio.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;


namespace Infra.Repositorio
{
    public class ProdutoRepositorio : IProduto
    {

        private readonly Contexto _context;

        public ProdutoRepositorio(Contexto context)
        {
            _context = context;
        }

        public async Task Adicionar(Produtos produto)
        {
            await _context.AddAsync(produto);
            await _context.SaveChangesAsync();

        }

        public async Task Atualizar(Produtos produto)
        {
            _context.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<Produtos> BuscarPorId(int Id)
        {
            return await _context.Set<Produtos>().FirstOrDefaultAsync(p => p.ProdutoId == Id);
        }

        public async Task Deletar(Produtos produtos)
        {
            _context.Remove(produtos);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Produtos>> ObterTodos()
        {
            return await _context.Set<Produtos>().AsNoTracking().ToListAsync();
        }
    }
}
