using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Miki.UrbanDictionary.Objects;

namespace Miki.UrbanDictionary;

/// <summary>
/// Urban Dictionary API wrapper, used to get definitions from Urban Dictionary.
/// </summary>
public interface IUrbanDictionaryApi
{
    /// <summary>
    /// Helper method to get the front-end URL for the user based on the term.
    /// </summary>
    string GetUserDefinitionUrl(string term);
    
    /// <summary>
    /// Get definitions based on Urban Dictionary terms.
    /// </summary>
    /// <param name="term">The term you are querying on urbandictionary</param>
    Task<IUrbanDictionaryResponse> SearchTermAsync(string term);
}

/// <inheritdoc />
public class UrbanDictionaryApi : IUrbanDictionaryApi
{
    private readonly HttpClient client;

    public UrbanDictionaryApi()
    {
        client = new HttpClient
        {
            BaseAddress = new Uri(Constants.BaseUrl),
            DefaultRequestHeaders =
            {
                { "Accept", "application/json" }
            }
        };
    }

    /// <inheritdoc />
    public string GetUserDefinitionUrl(string term)
        => Constants.UserBaseUrl + "define.php?term=" + HttpUtility.UrlEncode(term);
    
    /// <inheritdoc />
    public async Task<IUrbanDictionaryResponse> SearchTermAsync(string term)
    {
        var post = await client.GetAsync("define?term=" + term.Replace(' ', '+'));
        if (!post.IsSuccessStatusCode)
        {
            return null;
        }

        await using var stream = await post.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<UrbanDictionaryResponse>(stream);
    }
}