using System;

namespace PortalTeleMedicina.WebAPI.ViewModels
{
    public class ProdutoVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
