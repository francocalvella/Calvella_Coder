using FCalvellaAPI.Models;
using FCalvellaAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FCalvellaAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<ProductoVendido> Get() => ADO_ProductoVendido.TraerProductosVendidos();
    }
}
