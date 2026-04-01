using System;
using System.Collections.Generic;

public class LongestSubstringWithoutRepeatingCharactersSolution
{
    private List<(int, int)> repeatingCharacters(string s)
    {
        var charLastOccurrence = new Dictionary<char, int>();
        var repeatingChars = new List<(int, int)>();

        for (int i = 0; i < s.Length; i++)
        {
            if (charLastOccurrence.ContainsKey(s[i]))
            {
                repeatingChars.Add((charLastOccurrence[s[i]], i));
                charLastOccurrence[s[i]] = i;
            }
            else
            {
                charLastOccurrence.Add(s[i], i);
            }
        }
        
        return repeatingChars;
    }
    
    public int LengthOfLongestSubstring(string s) 
    {
        var repeatingChars = repeatingCharacters(s);
        var longestSubstring = (0, 0);
        
        var longestLength = 0;
        
        // If no repeating characters found
        if (repeatingChars.Count == 0)
        {
            longestLength = s.Length;
            return longestLength;
        }
        
        // If at least one occurrence of a repeating character
        longestSubstring = (0, repeatingChars[0].Item2 - 1);
        
        // Augment substrings between boundaries defined by repeating characters
        for (int i = 0; i < repeatingChars.Count; i++)
        {
            var augmentedSubstring = new List<(int, int)>();
            var startIndex = repeatingChars[i].Item1 + 1;

            int j = i;
            for (j = i; j < repeatingChars.Count && repeatingChars[j].Item1 < startIndex; j++)
            {
                augmentedSubstring.Add(repeatingChars[j]);
            }

            if (j < repeatingChars.Count)
            {
                augmentedSubstring.Add(repeatingChars[j]);
            }
            
            var endIndex = augmentedSubstring[^1].Item2 - 1;
            
            // If allowed, augment characters from end
            if (j == repeatingChars.Count && augmentedSubstring[^1].Item1 < startIndex)
            {
                endIndex = s.Length - 1;
            }
            // Otherwise, check if you should decrease start index
            else if (augmentedSubstring.Count == 1)
            {
                startIndex -= 1;
            }
            
            if (j > i)
            {
                i = j - 1;
            }

            if (longestSubstring.Item2 - longestSubstring.Item1 < endIndex - startIndex)
            {
                longestSubstring = (startIndex, endIndex);
            }
        }
        
        longestLength = longestSubstring.Item2 - longestSubstring.Item1 + 1;
        
        // Console.WriteLine(s.Substring(longestSubstring.Item1, longestSubstring.Item2 - longestSubstring.Item1 + 1));
        
        return longestLength;
    }
}