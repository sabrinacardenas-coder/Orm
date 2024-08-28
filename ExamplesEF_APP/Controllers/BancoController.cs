using ExamplesEF.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExamplesEF.Controllers
{
    [Route("api/banco")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly ManagerBanco managerBanco;
        public BancoController(ManagerBanco managerBanco) 
        {
            this.managerBanco = managerBanco ?? throw new ArgumentNullException(nameof(managerBanco));
        }
        [HttpGet(Name = "transferirDinero")]
        public async Task<Boolean> transferirDinero([FromQuery, Required] int  CuentaOrigenID, [FromQuery, Required] int idCuentaDestino , [FromQuery, Required] decimal monto)
        {
            return await managerBanco.transferirDinero(CuentaOrigenID, idCuentaDestino, monto);
        }
    }
}
