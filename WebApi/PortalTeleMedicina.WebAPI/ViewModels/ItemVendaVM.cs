namespace PortalTeleMedicina.WebAPI.ViewModels
{
    public class ItemVendaVM
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public ProdutoVM Produto { get; set; }
    }
}
