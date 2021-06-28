using System;

namespace PortalTeleMedicina.WebAPI.ViewModels
{
    public class UsuarioSigninVM
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
