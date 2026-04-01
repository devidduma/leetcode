public class MergeStringsAlternatelySolution
{
    public string MergeAlternately(string word1, string word2)
    {
        string result = "";

        int diff = word1.Length - word2.Length;
        int minLoop = Math.Min(word1.Length, word2.Length);

        for (int index = 0; index < minLoop; index++)
        {
            result += word1[index];
            result += word2[index];
        }

        if (diff > 0)
        {
            result += word1.Substring(word1.Length - diff);
        }
        else if (diff < 0)
        {
            result += word2.Substring(word2.Length + diff);
        }

        return result;
    }
}