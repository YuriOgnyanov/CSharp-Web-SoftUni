using BasicWebServer.Server.HTTP.Enums;
using BasicWebServer.Server.HTTP.Headers;
using BasicWebServer.Server.HTTP.Responses;

namespace BasicWebServer.Server.Responses
{
    public class RedirectResponse : Response
    {
        public RedirectResponse(string location)
            : base(StatusCode.Found)
        {
            this.Headers.Add(Header.Location, location);
        }
    }
}
