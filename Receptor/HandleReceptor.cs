using Emisor;
using MediatR;

namespace Receptor
{
    public class HandleReceptor : IRequestHandler<ComandoEmisor>
    {
        public async Task Handle(ComandoEmisor request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Este es el receptor: {request.Mensaje}");                       
        }
    }
}
