using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
 public static string[] FindPairs(string[] words)
{
    // Use a HashSet for fast lookups
    HashSet<string> wordSet = new HashSet<string>(words);
    
    // Store the results
    List<string> result = new List<string>();
    
    foreach (string word in words)
    {
        // Skip words like "aa" (same characters)
        if (word[0] == word[1])
            continue;

        // Reverse the word
        string reversed = new string(new char[] { word[1], word[0] });

        // Check if the reversed word exists in the set
        if (wordSet.Contains(reversed))
        {
            // Add the pair to result
            result.Add($"{word} & {reversed}");

            // Remove both words to avoid duplicates
            wordSet.Remove(word);
            wordSet.Remove(reversed);
        }
    }

    return result.ToArray();
}


    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
   public static Dictionary<string, int> SummarizeDegrees(string filename)
{
    var degrees = new Dictionary<string, int>();

    // Read each line in the file
    foreach (var line in File.ReadLines(filename))
    {
        var fields = line.Split(",");

        // Ensure the line has at least 4 columns to avoid IndexOutOfRangeException
        if (fields.Length >= 4)
        {
            string degree = fields[3].Trim(); // Get 4th column and trim spaces

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }
    }

    return degrees;
}

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
 public static bool IsAnagram(string word1, string word2)
{
        // To start i will have remove paces and change all letters to be the same case

    word1 = word1.Replace(" ", "").ToLower();
    word2 = word2.Replace(" ", "").ToLower();

 // Then i will check to see if the length are different or same, if the are different they are not anagram
        if (word1.Length != word2.Length)
            return false;


    //I'll use a dictionary to count how many times each letter appears in word1, and then subtract those counts with letters in word2.
        

    Dictionary<char, int> letterCount = new Dictionary<char, int>();

    foreach (char c in word1)
    {
        if (letterCount.ContainsKey(c))
            letterCount[c]++;
        else
            letterCount[c] = 1;
    }
    
    // Subtract letters from word2
    foreach (char c in word2)
        {
            if (!letterCount.ContainsKey(c))
                return false;

            letterCount[c]--;

            if (letterCount[c] < 0)
                return false;
        }

    return true;
}

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}