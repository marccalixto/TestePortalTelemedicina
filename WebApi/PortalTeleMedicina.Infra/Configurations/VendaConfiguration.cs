using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalTeleMedicina.Dominio.Entidades;

namespace PortalTeleMedicina.Infra.Configurations
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey(x => x.UsuarioId);
            builder.HasMany<ItemVenda>(x => x.Items).WithOne(x => x.Venda).HasForeignKey(x => x.VendaId);
        }
    }
}
