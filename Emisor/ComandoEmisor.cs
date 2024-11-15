using MediatR;

namespace Emisor
{
    public class ComandoEmisor : IRequest
    {
        public string Mensaje { get; }

        public ComandoEmisor(string mensaje)
        {
            Mensaje = mensaje;
        }
    }
}
