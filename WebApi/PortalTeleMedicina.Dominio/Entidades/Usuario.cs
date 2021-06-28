using System;

namespace PortalTeleMedicina.Dominio.Entidades
{
    public class Usuario : EntidadeBase<int>
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
    }
}