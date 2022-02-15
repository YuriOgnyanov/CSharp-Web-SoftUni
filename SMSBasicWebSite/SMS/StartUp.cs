namespace SMS
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using SMS.Data.Common;
    using SMS.Services;
    using SMS.Services.Contracts;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

            server.ServiceCollection
                .Add<IRepository,Repository>()
                .Add<IProductService,ProductService>()
                .Add<ICardService, CardService>()
                .Add<IUserService, UserService>();

            await server.Start();
        }
    }
}