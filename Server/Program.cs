using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using uwu.Library;
using uwu.Server;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services
            .AddSingleton(c =>  new TcpListener(IPAddress.Any, NetworkConfiguration.DEFAULT_PORT))
            .AddHostedService<ChatbotService>();
    })
    .Build();

host.Run();
