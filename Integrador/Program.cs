using Emisor;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => 
        { 
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Receptor.HandleReceptor).GetTypeInfo().Assembly));            
        })
    .Build();


bool salir = false;
var _mediator = host.Services.GetRequiredService<IMediator>();

while (!salir)
{
    Console.WriteLine("Ingrese un mensaje");
    string mensaje = Console.ReadLine();
    if(mensaje.Equals("salir"))
        Environment.Exit(0);

    //Envia un mensaje desde el comando emisor y lo debe recibir el receptor
    await _mediator.Send(new ComandoEmisor(mensaje));
}


