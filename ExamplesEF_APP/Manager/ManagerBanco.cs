using ExamplesEF.Repository;

namespace ExamplesEF.Manager
{
    public class ManagerBanco
    {
        private IBancoRepository bancoRepository;

        public ManagerBanco(IBancoRepository bancoRepository)
        {
            this.bancoRepository = bancoRepository ?? throw new ArgumentNullException(nameof(bancoRepository));
        }
        public async Task<Boolean> transferirDinero(int idorigen, int idDestino,  decimal monto)
        {
            var result = await bancoRepository.TransferirDinero(idorigen, idDestino, monto);
            return result;
        }
    }
}
