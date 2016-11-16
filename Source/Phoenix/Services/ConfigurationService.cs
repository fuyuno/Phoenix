﻿using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Newtonsoft.Json;

using Phoenix.Models;
using Phoenix.Services.Interfaces;

namespace Phoenix.Services
{
    internal class ConfigurationService : IConfigurationService
    {
        private readonly Dictionary<string, PropertyInfo> _cacheTable;

        public Configuration Configuration { get; private set; }

        public ConfigurationService()
        {
            _cacheTable = new Dictionary<string, PropertyInfo>();
        }

        public void Save()
        {
            if (!Directory.Exists(PhoenixConstants.AppDirectory))
                Directory.CreateDirectory(PhoenixConstants.AppDirectory);

            if (Configuration == null)
                Configuration = new Configuration();

            using (var sw = new StreamWriter(PhoenixConstants.ConfigurationFile))
                sw.WriteLine(JsonConvert.SerializeObject(Configuration));
        }

        public void Load()
        {
            if (!File.Exists(PhoenixConstants.ConfigurationFile))
            {
                Configuration = new Configuration();
                return;
            }

            using (var sr = new StreamReader(PhoenixConstants.ConfigurationFile))
                Configuration = JsonConvert.DeserializeObject<Configuration>(sr.ReadToEnd());
        }
    }
}