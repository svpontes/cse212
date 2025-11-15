using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;

public interface ISetsAndMaps
{
    static abstract string[] EarthquakeDailySummary();
    static abstract string[] FindPairs(string[] words);
    static abstract bool IsAnagram(string word1, string word2);
    static abstract Dictionary<string, int> SummarizeDegrees(string filename);
}

public class SetsAndMaps : ISetsAndMaps
{
    // ... FindPairs ...
    public static string[] FindPairs(string[] words)
    {
        var setWord = new HashSet<string>(words);
        var listOfResult = new List<string>();

        foreach (var word in words)
        {
            var charArray = word.ToCharArray();
            Array.Reverse(charArray);
            var reversed = new string(charArray);

            // Usa String.Compare(word, reversed) < 0 para evitar duplicatas e exclusão de 'aa'
            if (word != reversed && setWord.Contains(reversed) && String.Compare(word, reversed) < 0)
            {
                listOfResult.Add($"{word} & {reversed}");
            }
        }
        return listOfResult.ToArray();
    }

    // ... SummarizeDegrees ...........
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        const int DEGREE_INDEX = 3;

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            if (fields.Length > DEGREE_INDEX)
            {
                var degree = fields[DEGREE_INDEX].Trim();

                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees.Add(degree, 1);
                }
            }
        }
        return degrees;
    }

    // ... IsAnagram  ...
    public static bool IsAnagram(string word1, string word2)
    {
        var cleanedWord1 = word1.Replace(" ", "").ToLower();
        var cleanedWord2 = word2.Replace(" ", "").ToLower();

        if (cleanedWord1.Length != cleanedWord2.Length)
        {
            return false;
        }

        var charCounts = new Dictionary<char, int>();

        foreach (var c in cleanedWord1)
        {
            if (charCounts.ContainsKey(c))
                charCounts[c]++;
            else
                charCounts.Add(c, 1);
        }

        foreach (var c in cleanedWord2)
        {
            if (!charCounts.ContainsKey(c) || charCounts[c] == 0)
            {
                return false;
            }
            charCounts[c]--;
        }
        return true;
    }


    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// ...
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        // Note: Assuming FeatureCollection, Feature, and Properties classes are defined elsewhere.
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

        // Handling synchronous send and stream read as in the original code
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        // Requires FeatureCollection class definition
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var summaryList = new List<string>();

        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                var properties = feature.Properties;
                if (properties == null) continue;

                // Removed '?.' from properties.Mag?.ToString() assuming Mag is 'double' and cannot be null
                // in the Properties class definition (which is correct for the USGS API).
                var magText = properties.Mag.ToString();

                var summary = $"{properties.Place} - Mag {magText}";
                summaryList.Add(summary);
            }
        }

        // CORREÇÃO: Ponto e vírgula ausente.
        return summaryList.ToArray();
    }
}