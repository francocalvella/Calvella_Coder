using System.Data;
using FCalvellaAPI.Models;
using FCalvellaAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace FCalvellaAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Usuario> Get() => ADO_Usuario.TraerUsuarios();

        [HttpPost]
        [Route("/[controller]/login")]
        public Usuario Login([FromBody] Usuario user) => ADO_Usuario.Login(user);
        [HttpPost]
        public void Post([FromBody] Usuario user) => ADO_Usuario.CrearUsuario(user);
        [HttpDelete]
        public void Delete([FromBody] int id) => ADO_Usuario.BorrarUser(id); 
    }
}
