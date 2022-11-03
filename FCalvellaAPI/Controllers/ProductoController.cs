using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FCalvellaAPI.Models;
using FCalvellaAPI.Repository;

namespace FCalvellaAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public IEnumerable<Producto> Get() => ADO_Producto.TraerProductos();

        [HttpPost]
        public void Post([FromBody] Producto product)
        {
            ADO_Producto.AgregarProducto(product);   
        }

        [HttpPut]
        public void Put([FromBody] Producto product)
        {
            ADO_Producto.EditarProducto(product);
        }
        [HttpDelete]
        public void Delete([FromBody] int id)
        {
            ADO_Producto.BorrarProducto(id);
        }
    }
}
