using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Miki.UrbanDictionary.Objects;

namespace Miki.UrbanDictionary;

public class UrbanDictionaryApi
{
    private const string BaseUrl = "http://api.urbandictionary.com/v0/";
    private const string UserBaseUrl = "https://www.urbandictionary.com/";

    private readonly HttpClient client;

    public UrbanDictionaryApi()
    {
        client = new HttpClient
        {
            BaseAddress = new Uri(BaseUrl),
            DefaultRequestHeaders =
            {
                { "Accept", "application/json" }
            }
        };
    }

    /// <summary>
    /// Gets the front-end URL for the user based on the term.
    /// </summary>
    /// <param name="term"></param>
    /// <returns></returns>
    public string GetUserDefinitionUrl(string term)
        => UserBaseUrl + "define.php?term=" + HttpUtility.UrlEncode(term);

    /// <summary>
    /// Get definitions based on Urban Dictionary terms.
    /// </summary>
    /// <param name="term">The term you are querying on urbandictionary</param>
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