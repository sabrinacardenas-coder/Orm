using ExamplesEF.Data;
using ExamplesEF.Model.BancoModel;
using Microsoft.EntityFrameworkCore.Storage;

namespace ExamplesEF.Repository
{
    public class BancoRepository : IBancoRepository
    {
        private readonly DataContextBanco dbContext;
        public BancoRepository(DataContextBanco dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Boolean> TransferirDinero(int idOrigen, int idDestino,  decimal montoAtransferir)
        {
            Boolean updateOK = false;

           var confirmTransaction= dbContext.Database.BeginTransaction();

            try
            {
                // Obtener cuentas
                var cuentaOrigen = dbContext.Cuentas.Find(idOrigen);
                var cuentaDestino = dbContext.Cuentas.Find(idDestino);

                // Verificar que las cuentas existen y que hay suficiente saldo
                if (cuentaOrigen == null || cuentaDestino == null)
                {
                    throw new Exception("Una de las cuentas no existe.");
                }
                if (cuentaOrigen.Saldo < montoAtransferir)
                {
                    throw new Exception("Saldo insuficiente en la cuenta de origen.");
                }

                // Restar del saldo de la cuenta de origen
                cuentaOrigen.Saldo -= montoAtransferir;

                // Sumar al saldo de la cuenta de destino
                cuentaDestino.Saldo += montoAtransferir;

                // Registrar la transacción
                var transaccion = new Transaccion
                {
                    CuentaID = idOrigen,
                    Monto = -montoAtransferir,
                    Fecha = DateTime.Now,
                    DescripcionMotivo = "pago deuda"

                };
                
                dbContext.Transacciones.Add(transaccion);

                transaccion = new Transaccion
                {
                    CuentaID = idDestino,
                    Monto = montoAtransferir,
                    Fecha = DateTime.Now,
         
                };
                dbContext.Transacciones.Add(transaccion);

                // Guardar cambios y confirmar la transacción
                await dbContext.SaveChangesAsync();
                await confirmTransaction.CommitAsync(); // Confirmar la transacción
            }
            catch (Exception ex)
            {
                await confirmTransaction.RollbackAsync(); // Revertir los cambios en caso de error
            }

            return updateOK;
        }

    }
}
