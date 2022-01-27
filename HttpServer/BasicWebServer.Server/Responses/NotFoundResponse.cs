using BasicWebServer.Server.HTTP.Enums;
using BasicWebServer.Server.HTTP.Responses;

namespace BasicWebServer.Server.Responses
{
    public class NotFoundResponse : Response
    {
        public NotFoundResponse() 
            : base(StatusCode.NotFound)
        {
        }
    }
}
