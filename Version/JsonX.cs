using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiT.Version
{
    internal class JsonX
    {
        public class Os
        {
            /// <summary>
            /// 
            /// </summary>
            public string name { get; set; }
        }

        public class RulesItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string action { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Os os { get; set; }
        }

        public class JvmItem
        {
            /// <summary>
            /// 
            /// </summary>
            public List<RulesItem> rules { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<string> value { get; set; }
        }

        public class Arguments
        {
            /// <summary>
            /// 
            /// </summary>
            public List<string> game { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<JvmItem> jvm { get; set; }
        }

        public class AssetIndex
        {
            /// <summary>
            /// 
            /// </summary>
            public string id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string sha1 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int size { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int totalSize { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string url { get; set; }
        }


        public class Client_mappings
        {
            /// <summary>
            /// 
            /// </summary>
            public string sha1 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int size { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string url { get; set; }
        }

        public class Server
        {
            /// <summary>
            /// 
            /// </summary>
            public string sha1 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int size { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string url { get; set; }
        }

        public class Server_mappings
        {
            /// <summary>
            /// 
            /// </summary>
            public string sha1 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int size { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string url { get; set; }
        }

        public class Downloads
        {
            /// <summary>
            /// 
            /// </summary>
            public Artifact artifact { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Client client { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Client_mappings client_mappings { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Server server { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Server_mappings server_mappings { get; set; }
        }

        public class JavaVersion
        {
            /// <summary>
            /// 
            /// </summary>
            public string component { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int majorVersion { get; set; }
        }

        public class Artifact
        {
            /// <summary>
            /// 
            /// </summary>
            public string path { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string sha1 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int size { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string url { get; set; }
        }

        public class LibrariesItem
        {
            /// <summary>
            /// 
            /// </summary>
            public Downloads downloads { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<RulesItem> rules { get; set; }
        }

        public class File
        {
            /// <summary>
            /// 
            /// </summary>
            public string id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string sha1 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int size { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string url { get; set; }
        }

        public class Client
        {
            /// <summary>
            /// 
            /// </summary>
            public string argument { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public File file { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string sha1 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int size { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string url { get; set; }
        }

        public class Logging
        {
            /// <summary>
            /// 
            /// </summary>
            public Client client { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public AssetIndex assetIndex { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string assets { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int complianceLevel { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Downloads downloads { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public JavaVersion javaVersion { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<LibrariesItem> libraries { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Logging logging { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string mainClass { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int minimumLauncherVersion { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string releaseTime { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string type { get; set; }
        }

    }
}
