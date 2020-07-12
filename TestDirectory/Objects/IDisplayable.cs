using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDirectory.Objects
{
    public interface IDisplayable
    {
        [JsonProperty("text")]
        public string Text { get;  }

        [JsonProperty("type")]
        public string Type { get; }

        [JsonProperty("children")]
        public IEnumerable<IDisplayable> Children { get;  }
    }
}
