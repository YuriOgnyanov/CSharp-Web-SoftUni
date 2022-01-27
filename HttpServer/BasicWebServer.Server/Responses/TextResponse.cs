using BasicWebServer.Server.HTTP.Content;
using BasicWebServer.Server.HTTP.Requests;
using BasicWebServer.Server.HTTP.Responses;

namespace BasicWebServer.Server.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text, Action<Request, Response> preRenderAction = null) 
            : base(text, ContentType.PlaintText, preRenderAction)
        {
        }
    }
}
