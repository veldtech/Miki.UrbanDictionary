using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Web;

namespace Miki.UrbanDictionary.Objects;

[DataContract]
public class UrbanDictionaryEntry
{
    [JsonPropertyName("definition")]
    [DataMember(Name = "definition")]
    public string Definition { get; set; }

    [JsonPropertyName("permalink")]
    [DataMember(Name = "permalink")]
    public string Permalink { get; set; }

    [JsonPropertyName("thumbs_up")]
    [DataMember(Name = "thumbs_up")]
    public int ThumbsUp { get; set; }

    [JsonPropertyName("thumbs_down")]
    [DataMember(Name = "thumbs_down")]
    public int ThumbsDown { get; set; }

    [JsonPropertyName("author")]
    [DataMember(Name = "author")]
    public string Author { get; set; }

    [JsonPropertyName("word")]
    [DataMember(Name = "word")]
    public string Term { get; set; }

    [JsonPropertyName("defid")]
    [DataMember(Name = "defid")]
    public int DefinitionId { get; set; }

    [JsonPropertyName("current_vote")]
    [DataMember(Name = "current_vote")]
    public string CurrentVote { get; set; }

    [JsonPropertyName("example")]
    [DataMember(Name = "example")]
    public string Example { get; set; }
    
    public string Url => Constants.UserBaseUrl + "define.php?term=" + HttpUtility.UrlEncode(Term);

    public int Score => ThumbsUp - ThumbsDown;
}