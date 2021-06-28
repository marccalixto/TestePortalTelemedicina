using System;
using System.Collections.Generic;

namespace PortalTeleMedicina.Dominio.Entidades
{
    public class Produto : EntidadeBase<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
