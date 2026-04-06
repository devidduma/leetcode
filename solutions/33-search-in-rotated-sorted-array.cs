public class SearchInRotatedSortedArraySolution 
{
    public int Search(int[] nums, int target) 
    {
        // Left index
        var leftIndex = 0;
        
        // Right index
        var rightIndex = nums.Length - 1;
        
        // First trivial checks
        if (nums[0] == target)
        {
            return 0;
        }
        else if (nums[nums.Length - 1] == target)
        {
            return nums.Length - 1;
        }

        // Binary Search
        while (leftIndex < rightIndex - 1)
        {
            var middleIndex = (leftIndex + rightIndex) / 2;
            
            // Console.WriteLine($"{leftIndex}, {middleIndex}, {rightIndex}");
            
            // Target found
            if (target == nums[middleIndex])
            {
                return middleIndex;
            }
            
            // Binary Search for rotated sorted array
            if (nums[leftIndex] > nums[rightIndex])
            {
                // nums[middleIndex] > nums[leftIndex]
                if (nums[middleIndex] > nums[leftIndex])
                {
                    if (target > nums[middleIndex])
                    {
                        // Shift right
                        leftIndex = middleIndex;
                    }
                    else
                    {
                        if (target > nums[leftIndex])
                        {
                            // Shift left
                            rightIndex = middleIndex;
                        }
                        else
                        {
                            // Shift right
                            leftIndex = middleIndex;
                        }
                    }
                }
                // nums[middleIndex] < nums[leftIndex]
                else
                {
                    if (target < nums[middleIndex])
                    {
                        // Shift left
                        rightIndex = middleIndex;
                    }
                    else
                    {
                        if (target > nums[leftIndex])
                        {
                            // Shift left
                            rightIndex = middleIndex;
                        }
                        else
                        {
                            // Shift right
                            leftIndex = middleIndex;
                        }
                    }
                }
            }
            // Binary Search for normal sorted array
            else
            {
                if (target > nums[middleIndex])
                {
                    // Shift right
                    leftIndex = middleIndex;
                }
                else
                {
                    // Shift left
                    rightIndex = middleIndex;
                }
            }
        }
        
        // Last checks
        if (nums[rightIndex] == target)
        {
            return rightIndex;
        }
        else if (nums[leftIndex] == target)
        {
            return leftIndex;
        }
        
        return -1;
    }
}