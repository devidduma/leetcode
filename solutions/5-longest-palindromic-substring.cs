using System;

public class LongestPalindromicSubstringSolution
{
    public (bool, bool) IsPalindrome(string s)
    {
        bool sameChar = true;

        for (int i = 1; i < s.Length; i++)
        {
            if (s[i - 1] != s[s.Length - i])
            {
                return (false, false);
            }
            if (sameChar && s[i] != s[i - 1])
            {
                sameChar = false;
            }
        }

        return (true, sameChar);
    }

    public string LongestPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
            return s;

        // Previous occurrence of same character in string
        int[] prevOccur = new int[s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            prevOccur[i] = 0;
            for (int j = i - 1; j >= 0; j--)
            {
                if (s[i] == s[j])
                {
                    prevOccur[i] = j;
                    break;
                }
            }
        }

        // Longest substring
        int lsStartMain = 0;
        int lsEndMain = 0;

        // Longest substring candidates
        for (int index = s.Length - 1; index > 0; index--)
        {
            // If not palindrome, search for another
            int start = prevOccur[index];
            int length = index + 1 - start;
            (bool isPal, bool isSameChar) = IsPalindrome(s.Substring(start, length));

            if (!isPal)
                continue;

            // Palindrome
            int lsStart = prevOccur[index];
            int lsEnd = index;

            // Extend palindrome
            int e = 0;
            while (index + e < s.Length && prevOccur[index] - e >= 0)
            {
                if (s[index + e] != s[prevOccur[index] - e])
                    break;
                lsStart = prevOccur[index] - e;
                lsEnd = index + e;
                e += 1;
            }

            if (isSameChar)
            {
                e = 0;
                while (index + e < s.Length)
                {
                    if (s[index + e] != s[index])
                        break;
                    lsEnd = index + e;
                    e += 1;
                }
                e = 0;
                while (prevOccur[index] - e >= 0)
                {
                    if (s[prevOccur[index] - e] != s[index])
                        break;
                    lsStart = prevOccur[index] - e;
                    e += 1;
                }
            }

            // Save if longest palindrome
            if (lsEnd - lsStart > lsEndMain - lsStartMain)
            {
                lsStartMain = lsStart;
                lsEndMain = lsEnd;
            }
        }

        return s.Substring(lsStartMain, lsEndMain - lsStartMain + 1);
    }
}