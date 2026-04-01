using System;
using System.Collections.Generic;

public class MedianOfTwoSortedArraysSolution
{
    public int HalfArrayIndex(int[] nums)
    {
        return (nums.Length - 1) / 2;
    }

    private double Median(int[] arr)
    {
        if (arr.Length == 0) return 0.0;

        Array.Sort(arr);

        if (arr.Length % 2 == 1)
        {
            return arr[arr.Length / 2];
        }
        else
        {
            return (arr[arr.Length / 2 - 1] + arr[arr.Length / 2]) / 2.0;
        }
    }

    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        while (nums1.Length > 3 && nums2.Length > 3)
        {
            if (Median(nums1) > Median(nums2))
            {
                int[] temp = nums1;
                nums1 = nums2;
                nums2 = temp;
            }

            int toRemove = HalfArrayIndex(nums1.Length > nums2.Length ? nums2 : nums1);

            nums1 = nums1[toRemove..];
            nums2 = nums2[..^toRemove];
        }

        int[] nums = new int[nums1.Length + nums2.Length];
        Array.Copy(nums1, 0, nums, 0, nums1.Length);
        Array.Copy(nums2, 0, nums, nums1.Length, nums2.Length);

        return Median(nums);
    }
}