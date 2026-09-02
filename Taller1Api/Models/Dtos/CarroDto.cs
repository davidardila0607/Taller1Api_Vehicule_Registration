using System.Linq.Expressions;

namespace Taller1Api.Models.DTO
{
    public class CarroDto
    {
        public string Marca { get; set; }

        public string Color { get; set; }

        public string Placa { get; set; }

        public double Precio { get; set; }

        public double CalcularDescuento(Marca marca)
        {
            switch (marca.Nombre)
            {
                case "Toyota":
                    return Precio - (Precio * 0.15);
                case "Renault":
                    return Precio - (Precio * 0.25);
                case "Chevrolet":
                    return Precio - (Precio * 0.20);
                default:
                    return Precio; 
            }
        }

       
    }
    }
