using Newtonsoft.Json;
using System;

namespace Luis.Manage
{
    public class LuisResult
    {
        public string Query { get; set; }
        public Topscoringintent TopScoringIntent { get; set; }
        public Entity[] Entities { get; set; }
    }

    public class Topscoringintent
    {
        public string Intent { get; set; }
        public float Score { get; set; }
    }

    public class Entity
    {
        [JsonProperty(PropertyName = "entity")]
        public string EntityName { get; set; }
        public string Type { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public Resolution Resolution { get; set; }
        public float Score { get; set; }
    }

    public class Resolution
    {
        public string[] Values { get; set; }
        public string Value { get; set; }
    }
}
