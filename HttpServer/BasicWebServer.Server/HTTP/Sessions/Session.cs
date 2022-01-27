
using BasicWebServer.Server.Common;

namespace BasicWebServer.Server.HTTP.Sessions
{
    public class Session
    {
        public const string SessionCookieName = "MyWebServerSID";
        public const string SessionCurrentDateKey = "CurrentDate";
        public const string SessionUserKey = "AuthenticatedUserId";
        public string Id { get; set; }
        private Dictionary<string, string> data;

        public Session(string id)
        {
            Guard.AgainstNull(id, nameof(id));

            data = new Dictionary<string, string>();

            Id = id;
        }

        public string this[string key] 
        {
            get => this.data[key];
            set => this.data[key] = value;
        }

        public bool Contains(string key)
            => this.data.ContainsKey(key);

        public void Clear()
            => this.data.Clear();
    }
}
