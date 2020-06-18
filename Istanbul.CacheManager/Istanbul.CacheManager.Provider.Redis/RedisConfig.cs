using System;
using System.Collections.Generic;
using System.Text;

namespace Istanbul.CacheManager.Provider.Redis
{
    public class RedisConfig
    {
        public string Connection { get; set; }
        public int Database { get; set; }
    }
}
