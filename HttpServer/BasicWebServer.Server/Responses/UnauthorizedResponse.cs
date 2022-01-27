using BasicWebServer.Server.HTTP.Enums;
using BasicWebServer.Server.HTTP.Responses;

namespace BasicWebServer.Server.Responses
{
    public class UnauthorizedResponse : Response
    {
        public UnauthorizedResponse() 
            : base(StatusCode.Unauthorized)
        {
        }
    }
}
