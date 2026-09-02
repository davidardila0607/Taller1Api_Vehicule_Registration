using Taller1Api.Interface;
using Microsoft.Extensions.DependencyInjection;
using Taller1Api.Models;
using Taller1Api.Models.DTO;

namespace Taller1Api.Repository
{
    public class CarroRepositorio : ICarroRepository
    {
        private readonly IServiceProvider _provider;
        public static List<Carro> carros = new List<Carro>();

        public CarroRepositorio(IServiceProvider provider)
        {
            _provider = provider;
        }

        public string CreateCarro(CarroDto carro)
        {
            if (string.IsNullOrEmpty(carro.Marca) && string.IsNullOrEmpty(carro.Color) && string.IsNullOrEmpty(carro.Placa))
            {
                throw new Exception("Los parametros de entrada son inválidos");
            }

            var marcaRepository = _provider.GetRequiredService<IMarcaRepository>();
            var marca = marcaRepository.GetMarcas(carro.Marca);


            if (marca == null) 
            {
                throw new Exception("La marca del carro no existe");
            }



            if (carro.Precio <= 0)
            {
                throw new Exception("El precio del carro debe ser mayor a cero");
            }

            Carro newCarro = new Carro 
            {
                Id = carros.Count + 1,
                MarcaId = marca.Id,
                Marca = carro.Marca,
                Color = carro.Color,
                Placa = carro.Placa,
                Precio = carro.CalcularDescuento(marca)
            };
            carros.Add(newCarro);
            return "Carro creado exitosamente";
        }

        public string DeleteCarro(int IdCarro)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Carro> GetCarros()
        {
            return carros;
        }

        public IEnumerable<Marca> GetMarcas()
        {
            throw new NotImplementedException();
        }

        public string CreateMarca(Marca item)
        {
            throw new NotImplementedException();
        }
    }
}
