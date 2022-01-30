using BasicWebServer.Server.HTTP.Enums;
using BasicWebServer.Server.HTTP.Responses;

namespace BasicWebServer.Server.Routing.Contract
{
    public interface IRoutingTable
    {
        IRoutingTable Map(string path, Method method, Response response);
        IRoutingTable MapGet(string url, Response response);
        IRoutingTable MapPost(string url, Response response);
    }
}
