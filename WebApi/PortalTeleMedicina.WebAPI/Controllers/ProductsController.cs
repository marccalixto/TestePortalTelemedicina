using Microsoft.AspNetCore.Authorization;
using PortalTeleMedicina.Dominio.Entidades;
using PortalTeleMedicina.WebAPI.ViewModels;
using System;

namespace PortalTeleMedicina.WebAPI.Controllers
{
    [Authorize]
    public class ProductsController : CrudGenericoController<int, Produto, ProdutoVM>
    {
        public ProductsController(IServiceProvider serviceProvider) : base(serviceProvider)
        { }
    }
}
