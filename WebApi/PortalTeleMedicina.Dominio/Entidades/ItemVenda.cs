namespace PortalTeleMedicina.Dominio.Entidades
{
    public class ItemVenda : EntidadeBase<int>
    {
        public double Price { get; set; }
        public double Quantity { get; set; }
        public virtual Produto Produto { get; set; }
        public int VendaId { get; set; }
        public virtual Venda Venda { get; set; }
    }
}