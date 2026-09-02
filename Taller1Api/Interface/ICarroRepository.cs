using Taller1Api.Models;
using Taller1Api.Models.DTO;

namespace Taller1Api.Interface
{
    public interface ICarroRepository
    {
        public IEnumerable<Carro> GetCarros();

        public string CreateCarro(CarroDto carro);

        public string DeleteCarro(int IdCarro);
        IEnumerable<Marca> GetMarcas();
        string CreateMarca(Marca item);
    }
}
