using System;
using System.Collections.Generic;

namespace PortalTeleMedicina.WebAPI.ViewModels
{
    public class VendaVM
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public double TotalValue { get; set; }
        public virtual ICollection<ItemVendaVM> Items { get; set; }
        public int UsuarioId { get; set; }
    }
}
