using Newtonsoft.Json;
using Xbmc.Core.Commands;

namespace Xbmc.Core
{
    [JsonObject]
    public sealed class Connection
    {
        [JsonProperty]
        public string Address { get; private set; }
        [JsonProperty]
        public string Port { get; private set; }
        [JsonProperty]
        public string Login { get; private set; }
        [JsonProperty]
        public string Password { get; private set; }

        public Addons Addons { get; private set; }
        public Application Application { get; private set; }
        public AudioLibrary AudioLibrary { get; private set; }
        public Files Files { get; private set; }
        public Gui Gui { get; private set; }
        public Input Input { get; private set; }
        public JsonRpc JsonRpc { get; private set; }
        public Player Player { get; private set; }
        public Playlist Playlist { get; private set; }
        public Pvr Pvr { get; private set; }
        public Commands.System System { get; private set; }
        public VideoLibrary VideoLibrary { get; private set; }
        public Commands.Xbmc Xbmc { get; private set; }

        internal string BaseUrl
        {
            get { return string.Concat("http://", Address, ":", Port, "/jsonrpc"); }
        }

        public Connection()
        {
            Addons = new Addons(this);
            Application = new Application(this);
            AudioLibrary = new AudioLibrary(this);
            Files = new Files(this);
            Gui = new Gui(this);
            Input = new Input(this);
            JsonRpc = new JsonRpc(this);
            Player = new Player(this);
            Playlist = new Playlist(this);
            Pvr = new Pvr(this);
            System = new Commands.System(this);
            VideoLibrary = new VideoLibrary(this);
            Xbmc = new Commands.Xbmc(this);
        }

        public Connection(string address, string port, string login, string password)
            : this()
        {
            Address = address;
            Port = port;
            Login = login;
            Password = password;
        }

        public string GetImageUrl(string path)
        {
            return string.Concat("http://", Address, ":", Port, "/", path);
        }

        public static Connection Default()
        {
            return new Connection("", "80", "xbmc", "");
        }
    }
}