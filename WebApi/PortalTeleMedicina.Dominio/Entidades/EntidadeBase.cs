namespace PortalTeleMedicina.Dominio.Entidades
{
    public abstract class EntidadeBase<T> where T : struct
    {
        public T Id { get; set; }
    }
}
