

using AutoMapper;
using Cadastro.Prod.Web.ViewModels;
using Dominio.Entidades;

namespace Cadastro.Prod.Web
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Produtos, ProdutoViewModel>().ReverseMap();
        }

    }



}
