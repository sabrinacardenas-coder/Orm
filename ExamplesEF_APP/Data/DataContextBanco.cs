using ExamplesEF.Model;
using ExamplesEF.Model.BancoModel;
using Microsoft.EntityFrameworkCore;

namespace ExamplesEF.Data
{
    public class DataContextBanco : DbContext
    {
        public DataContextBanco(DbContextOptions<DataContextBanco> options) : base(options)
        {

        }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }


    }
}
