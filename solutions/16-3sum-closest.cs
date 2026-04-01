using System;
using System.Collections.Generic;

public class ThreeSumClosestSolution 
{
    public int ThreeSumClosest(int[] nums, int target) 
    {
        List<int> sortedNums = new List<int>(nums);
        sortedNums.Sort();
        
        int result = int.MaxValue;

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
                long total = (long) sortedNums[i] + sortedNums[left] + sortedNums[right];

                if (Math.Abs(total - target) < Math.Abs((long) result - target))
                {
                    result = (int) total;
                }
                
                // Pointers update accordingly
                if (total > target)
                {
                    right -= 1;
                }
                else if (total < target)
                {
                    left += 1;
                }
                else
                {
                    return target;
                }
            }
        }
        
        return result;
    }
}