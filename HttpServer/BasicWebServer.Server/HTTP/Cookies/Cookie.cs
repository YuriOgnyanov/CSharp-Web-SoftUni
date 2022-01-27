using BasicWebServer.Server.Common;

namespace BasicWebServer.Server.HTTP.Cookies
{
    public class Cookie
    {
        public string Name { get; init; }
        public string Value { get; init; }

        public Cookie(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));

            Name = name;
            Value = value;
        }

        public override string ToString()
            => $"{this.Name}={this.Value}";
    }
}
