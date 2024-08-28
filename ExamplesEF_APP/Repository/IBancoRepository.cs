namespace ExamplesEF.Repository
{
    public interface IBancoRepository
    {
        Task<Boolean> TransferirDinero(int idOrigen, int idDestino, decimal montoAtransferir);
    }
}
