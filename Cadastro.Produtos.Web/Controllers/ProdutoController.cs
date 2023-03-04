using Aplicação.Aplicação;
using Aplicação.Interfaces;
using AutoMapper;
using Cadastro.Prod.Web.ViewModels;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.Prod.Web.Controllers
{
    public class ProdutoController : Controller
    {



        private readonly IAplicacaoProdutos _aplicacaoProdutos;
        private readonly IMapper _mapper;

        public ProdutoController(IAplicacaoProdutos aplicacaoProdutos, IMapper mapper)
        {
            _aplicacaoProdutos = aplicacaoProdutos;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {

           

            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _aplicacaoProdutos.ObterTodos()));
        }





        [Route("novo-produto")]
        public IActionResult Adicionar()
        {
            var produtoViewModel = new ProdutoViewModel();
            return View(produtoViewModel);
        }




        [Route("novo-produto")]
        [HttpPost]
        public async Task<IActionResult> Adicionar(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(produtoViewModel);
            }
            await _aplicacaoProdutos.Adicionar(_mapper.Map<Produtos>(produtoViewModel));
            return RedirectToAction(nameof(Index));

        }

        [Route("editar-produto/{id}")]
        public async Task<IActionResult> Editar(int Id)
        {

            var produto = _mapper.Map<ProdutoViewModel>(await _aplicacaoProdutos.BuscarPorId(Id));

            if (produto == null) { return NotFound(); }
            return View(produto);
        }


        [Route("editar-produto/{id}")]
        [HttpPost]
        public async Task<IActionResult> Editar(int Id, ProdutoViewModel produtoViewModel)
        {
            if (Id != produtoViewModel.ProdutoId) { return NotFound(); }
            await _aplicacaoProdutos.Atualizar(_mapper.Map<Produtos>(produtoViewModel));
            return RedirectToAction(nameof(Index));
        }


        [Route("excluir-produto/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _aplicacaoProdutos.BuscarPorId(id));

            if (produto == null) { return NotFound(); }
            return View(produto);
        }




        [HttpPost, ActionName("Delete")]
        [Route("excluir-produto/{id}")]
        public async Task<IActionResult> DeleteConfirmação(int id)
        {
            var produto = await _aplicacaoProdutos.BuscarPorId(id);
            if (produto == null) { return NotFound(); }
            await _aplicacaoProdutos.Deletar(produto);
            
            return RedirectToAction(nameof(Index));
        }

    }
}
