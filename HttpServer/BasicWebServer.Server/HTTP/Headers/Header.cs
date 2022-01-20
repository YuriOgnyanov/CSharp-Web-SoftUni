
using BasicWebServer.Server.Common;

namespace BasicWebServer.Server.HTTP.Headers
{
    public class Header
    {
        public string Name { get; init; }
        public string Value { get; set; }

        public Header(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));

            this.Name = name;
            this.Value = value;
        }
    }
}
