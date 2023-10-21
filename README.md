# Miki.UrbanDictionary

A minimal wrapper around the UrbanDictionary website.

## How to install the package

Get the package from nuget: https://www.nuget.org/packages/Miki.UrbanDictionary

```bash
dotnet add package Miki.UrbanDictionary
```

## Example

The following code gets you the definition of our favourite idol: Miki!

```csharp
using Miki.UrbanDictionary;

var urbanClient = new UrbanDictionaryApi();
var response = await urbanClient.SearchTermAsync("miki");
if(!response.Entries.Any()) {
  throw new InvalidOperationException("no definition found for term!");
}

Console.WriteLine($"The definition for miki is: {response.Entries.First().Definition}!");
```