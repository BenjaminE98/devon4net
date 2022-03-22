using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.Infrastructure.Common.Options.MongoDb
{
    public class MongoDbOptions
    {
        public string Host { get; set; }

        public string Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Database { get; set; }

        public int ConnectionTimeout { get; set; }

        public int ServerSelectionTimeout { get; set; }
    }
}
