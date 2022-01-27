using BasicWebServer.Server.HTTP.Content;
using BasicWebServer.Server.HTTP.Requests;
using BasicWebServer.Server.HTTP.Responses;

namespace BasicWebServer.Server.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string text, Action<Request, Response> preRenderAction = null) 
            : base(text, ContentType.Html, preRenderAction)
        {
        }
    }
}
