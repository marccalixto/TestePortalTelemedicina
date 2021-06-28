using Microsoft.AspNetCore.Authorization;
using PortalTeleMedicina.Dominio.Entidades;
using PortalTeleMedicina.WebAPI.ViewModels;
using System;

namespace PortalTeleMedicina.WebAPI.Controllers
{
    [AllowAnonymous]
    public class SignupController : CrudGenericoController<int, Usuario, UsuarioSignupVM>
    {
        public SignupController(IServiceProvider serviceProvider) : base(serviceProvider)
        { }
    }
}