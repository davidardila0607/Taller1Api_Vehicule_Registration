using Microsoft.AspNetCore.Mvc;
using Taller1Api.Interface;
using Taller1Api.Models;
using Taller1Api.Models.DTO;


namespace Taller1Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaController(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        [HttpGet("GetMarcas")]
        public Marca Get()
        {
            return _marcaRepository.GetMarcas();
        }

        [HttpPost("CreateMarca")]
        public string Post(Marca item)
        {
            var respuesta = _marcaRepository.CreateMarca(item);
            return respuesta;
        }
    }
}
