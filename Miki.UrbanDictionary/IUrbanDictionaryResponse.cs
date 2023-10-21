using System.Collections.Generic;
using Miki.UrbanDictionary.Objects;

namespace Miki.UrbanDictionary;

public interface IUrbanDictionaryResponse
{
    IReadOnlyList<string> Tags { get; }
    string ResultType { get; }
    IReadOnlyList<UrbanDictionaryEntry> List { get; }
    IReadOnlyList<string> Sounds { get; }
}