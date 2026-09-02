using Taller1Api.Models;

namespace Taller1Api.Interface
{
    public interface IMarcaRepository
    {

        public Marca GetMarcas(string nombre);
        public string CreateMarca(Marca marca);
        public string DeleteMarca(int IdMarca);
        Marca GetMarcas();
    }
}
