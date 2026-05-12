using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GithubAPIAutomation.Support
{
    public class Repo
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        public bool Private { get; set; }
    }
}
