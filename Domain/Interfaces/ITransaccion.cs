namespace Domain.Interfaces
{
    public interface ITransaccion
    {
        void Begin();
        void Commit();
        void Rollback();
        void Guardar();
    }
}
