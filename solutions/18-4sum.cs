using System;
using System.Collections.Generic;

public class FourSumSolution 
{
    public IList<IList<int>> FourSum(int[] nums, int target) 
    {
        List<int> sortedNums = new List<int>(nums);
        sortedNums.Sort();
        
        List<IList<int>> result = new List<IList<int>>();

        for (int i = 0; i < sortedNums.Count - 3; i++)
        {
            // Skip duplicates
            if (i > 0 && sortedNums[i] == sortedNums[i - 1])
            {
                continue;
            }

            for (int j = i + 1; j < sortedNums.Count - 2; j++)
            {
                // Skip duplicates
                if (j > i + 1 && sortedNums[j] == sortedNums[j - 1])
                {
                    continue;
                }
                
                // Two pointers
                int left = j + 1;
                int right = sortedNums.Count - 1;

                while (left < right)
                {
                    long total = (long) sortedNums[i] + sortedNums[j] + sortedNums[left] + sortedNums[right];
                    
                    if (total == target)
                    {
                        result.Add(new List<int> { sortedNums[i], sortedNums[j], sortedNums[left], sortedNums[right] });
                        
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
                        
                        // Pointers update for sum = target
                        left += 1;
                        right -= 1;
                    }
                    // Pointers update accordingly
                    else if (total < target)
                    {
                        left += 1;
                    }
                    else
                    {
                        right -= 1;
                    }
                }
                
            }
        }
        
        return result;
    }
}