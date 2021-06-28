using System;
using System.Collections.Generic;

namespace PortalTeleMedicina.Dominio.Entidades
{
    public class Venda : EntidadeBase<int>
    {
        public DateTime CreationDate { get; set; }
        public double TotalValue { get; set; }
        public virtual ICollection<ItemVenda> Items { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
