using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalTeleMedicina.Dominio.Entidades;
using PortalTeleMedicina.Dominio.Servicos;
using PortalTeleMedicina.WebAPI.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PortalTeleMedicina.WebAPI.Controllers
{
    [AllowAnonymous]
    public class SigninController : CrudGenericoController<int, Usuario, UsuarioSigninVM>
    {
        public SigninController(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override async Task<IActionResult> Post([FromBody] UsuarioSigninVM model)
        {
            var entities = await _Service.GetByAsync(x => x.UserName.ToUpper() == model.UserName.ToUpper() && x.Password == model.Password);

            var entity = entities.FirstOrDefault();
            if (entity == null) return NotFound(new { message = "Usuário não encontrado" });

            UsuarioSigninVM usuarioSigninVM = _Mapper.Map<UsuarioSigninVM>(entity);
            usuarioSigninVM.Password = "";

            // Gera o Token
            var token = TokenService.GenerateToken(entity);

            return Ok(new
            {
                user = usuarioSigninVM,
                token = token
            });
        }
    }
}