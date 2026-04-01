public class GreatestCommonDivisorOfStringsSolution
{
    public string GcdOfStrings(string str1, string str2)
    {
        // Pick minimum length string
        int minLength = Math.Min(str1.Length, str2.Length);

        for (int index = minLength; index > 0; index--)
        {
            bool divisor = true;

            if (str1.Length % index == 0 && str2.Length % index == 0)
            {
                string candidate = str1.Substring(0, index);

                for (int j = 0; j < str1.Length; j += index)
                {
                    if (str1.Substring(j, index) != candidate)
                    {
                        divisor = false;
                        break;
                    }
                }

                if (divisor)
                {
                    for (int j = 0; j < str2.Length; j += index)
                    {
                        if (str2.Substring(j, index) != candidate)
                        {
                            divisor = false;
                            break;
                        }
                    }
                }

                if (divisor)
                {
                    return candidate;
                }
            }
        }

        return "";
    }
}