using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Caching.Settings
{
    public class MongoDBSettings
    {
        public string ConnectingString { get; set; }
        public string DatabaseName { get; set; }
        public bool IsSSL { get; set; }
    }
}
