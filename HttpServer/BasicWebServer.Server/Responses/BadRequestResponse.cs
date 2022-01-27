using BasicWebServer.Server.HTTP.Enums;
using BasicWebServer.Server.HTTP.Responses;

namespace BasicWebServer.Server.Responses
{
    public class BadRequestResponse : Response
    {
        public BadRequestResponse() 
            : base(StatusCode.BadRequest)
        {
        }
    }
}
