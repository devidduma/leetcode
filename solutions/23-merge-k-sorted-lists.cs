// Definition for singly-linked list
public class ListNode 
{
    public int val;
    public ListNode next;
    
    public ListNode(int val = 0, ListNode next = null) 
    {
        this.val = val;
        this.next = next;
    }
}

public class MergeKSortedListsSolution 
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        ListNode result = null;
        ListNode resultLast = null;
        
        // Counter of empty lists
        var emptyListsCount = 0;

        while (emptyListsCount < lists.Length)
        {
            // Current minimum
            var min = int.MaxValue;
            var minIndex = 0;
            
            // Reset counter of empty lists
            emptyListsCount = 0;
        
            // Find current minimum
            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] == null)
                {
                    emptyListsCount += 1;
                    continue;
                }
                else if (lists[i].val < min)
                {
                    min = lists[i].val;
                    minIndex = i;
                }
            }
        
            // Add current minimum to result
            if (result == null)
            {
                result = lists[minIndex];
                resultLast = result;
            }
            else
            {
                resultLast.next = lists[minIndex];
                resultLast = resultLast.next;
            }
        
            // Update current element in list
            if (emptyListsCount < lists.Length)
            {
                lists[minIndex] = lists[minIndex].next;
            }
        }
        
        return result;
    }
}