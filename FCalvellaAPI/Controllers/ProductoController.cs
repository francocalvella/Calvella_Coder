using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FCalvellaAPI.Models;
using FCalvellaAPI.Repository;

namespace FCalvellaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public IEnumerable<Producto> Get() => ADO_Producto.TraerProductos();
    }
}
