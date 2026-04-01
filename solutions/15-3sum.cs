using System;
using System.Collections.Generic;

public class ThreeSumSolution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        List<int> sortedNums = new List<int>(nums);
        sortedNums.Sort();

        List<IList<int>> result = new List<IList<int>>();

        for (int i = 0; i < sortedNums.Count - 2; i++)
        {
            // Skip duplicates
            if (i > 0 && sortedNums[i] == sortedNums[i - 1])
            {
                continue;
            }

            // Two pointers
            int left = i + 1;
            int right = sortedNums.Count - 1;

            while (left < right)
            {
                int total = sortedNums[i] + sortedNums[left] + sortedNums[right];

                if (total == 0)
                {
                    result.Add(new List<int> { sortedNums[i], sortedNums[left], sortedNums[right] });

                    // Skip duplicates for left pointer
                    while (left < right && sortedNums[left] == sortedNums[left + 1])
                    {
                        left += 1;
                    }
                    
                    // Skip duplicates for right pointer
                    while (left < right && sortedNums[right] == sortedNums[right - 1])
                    {
                        right -= 1;
                    }
                    
                    // Pointers update for sum 0
                    left += 1;
                    right -= 1;
                }
                // Pointers update accordingly
                else if (total < 0)
                {
                    left += 1;
                }
                else
                {
                    right -= 1;
                }
            }
        }

        return result;
    }
}