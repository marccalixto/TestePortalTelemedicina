using System;

namespace PortalTeleMedicina.WebAPI.DTO
{
    public class PesquisarVendasPorDTO
    {
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public double ValorInicial { get; set; }
        public double ValorFinal { get; set; }
        public int UsuarioId { get; set; }
    }
}
