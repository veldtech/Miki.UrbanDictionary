using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Miki.UrbanDictionary.Objects;
    
[DataContract]
internal class UrbanDictionaryResponse : IUrbanDictionaryResponse
{
    [JsonPropertyName("tags")]
    [DataMember(Name = "tags")]
    public IReadOnlyList<string> Tags { get; set; }

    [JsonPropertyName("result_type")]
    [DataMember(Name = "result_type")]
    public string ResultType { get; set; }

    [JsonPropertyName("list")]
    [DataMember(Name = "list")]
    public IReadOnlyList<UrbanDictionaryEntry> Entries { get; set; }

    [JsonPropertyName("sounds")]
    [DataMember(Name = "sounds")]
    public IReadOnlyList<string> Sounds { get; set; }
}
