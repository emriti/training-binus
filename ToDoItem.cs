using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingBinus
{
    public class ToDoItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name", Required=Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("description", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("isComplete", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsComplete { get; set; }
    }
}
