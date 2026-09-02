using Taller1Api.Interface;
using Microsoft.Extensions.DependencyInjection;
using Taller1Api.Models;

namespace Taller1Api.Repository
{
    public class MarcaRepository : IMarcaRepository
    {

        private readonly IServiceProvider _provider;
        public static List<Marca> marcas = new List<Marca>();

        public MarcaRepository(IServiceProvider provider)
        {
            _provider = provider;
        }

        public string CreateMarca(Marca marca)
        {
            if (string.IsNullOrEmpty(marca.Nombre) && string.IsNullOrEmpty(marca.Descripcion))
            {
                throw new Exception("Los parámetros de entrada son inválidos");
            }

           
           
            Marca newMarca = new Marca 
            {
                Id = marcas.Count + 1,
                Nombre = marca.Nombre,
                Descripcion = marca.Descripcion
            };
            marcas.Add(newMarca);
            return "Marca creada exitosamente";


        }

        public string DeleteMarca(int IdMarca)
        {
            // Resolver ICarroRepository de forma perezosa para evitar dependencia circular
            var carroRepository = _provider.GetRequiredService<ICarroRepository>();
            var carros = carroRepository.GetCarros().Where(m => m.MarcaId == IdMarca);
            if (!carros.Any())
            {
                throw new Exception("No se puede eliminar la marca porque tiene carros asociados");
            }
            return "Marca eliminada exitosamente";
        }

        public Marca GetMarcas(string nombre) => marcas.FirstOrDefault(m => m.Nombre == nombre);

        public Marca GetMarcas()
        {
            throw new NotImplementedException();
        }
    }
}
