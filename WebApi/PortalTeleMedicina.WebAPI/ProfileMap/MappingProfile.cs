using AutoMapper;
using PortalTeleMedicina.Dominio.Entidades;
using PortalTeleMedicina.WebAPI.ViewModels;

namespace PortalTeleMedicina.WebAPI.ProfileMap
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Produto, ProdutoVM>().ReverseMap();
            //CreateMap<ProdutoVM, Produto>();

            CreateMap<Usuario, UsuarioSigninVM>().ReverseMap();
            //CreateMap<UsuarioSigninVM, Usuario>();

            CreateMap<Usuario, UsuarioSignupVM>().ReverseMap();
            //CreateMap<UsuarioSignupVM, Usuario>();

            CreateMap<Venda, VendaVM>().ReverseMap();
            //CreateMap<VendaVM, Venda>();

            CreateMap<ItemVenda, ItemVendaVM>().ReverseMap();
        }
    }
}
