using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FCalvellaAPI.Models;
using FCalvellaAPI.Repository;

namespace FCalvellaAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Venta> Get() => ADO_Venta.TraerVentasPorUserId();
        
        [HttpPost]
        public void Post([FromBody]Venta venta) => ADO_Venta.AgregarVenta(venta);

        [HttpDelete]
        public void Delete([FromBody] int id) => ADO_Venta.EliminarVenta(id);
    }
}
