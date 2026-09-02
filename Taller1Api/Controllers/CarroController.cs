using Microsoft.AspNetCore.Mvc;
using Taller1Api.Interface;
using Taller1Api.Models;
using Taller1Api.Models.DTO;


namespace Taller1Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarroController : ControllerBase
    {
        private readonly ICarroRepository _carroRepository;

        public CarroController(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        [HttpGet("GetCarros")]
        public IEnumerable<Carro> Get()
        {
            return _carroRepository.GetCarros();
        }

        [HttpPost("CrearCarro")]
        public string Post(CarroDto item)
        {
            var respuesta = _carroRepository.CreateCarro(item);
            return respuesta;
        }
    }
}
