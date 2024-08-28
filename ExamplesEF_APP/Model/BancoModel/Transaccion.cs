namespace ExamplesEF.Model.BancoModel
{
    public class Transaccion
    {
        public int ID { get; set; }
        public int CuentaID { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string DescripcionMotivo { get; set; }
    }
}
