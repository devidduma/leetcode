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
        
        // Priority Queue arrangement of ListNodes
        var priorityQueue = new PriorityQueue<ListNode, int>();

        for (int i = 0; i < lists.Length; i++)
        {
            if (lists[i] != null)
            {
                priorityQueue.Enqueue(lists[i], lists[i].val);
            }
        }
        
        // Construct result from Priority Queue
        while (priorityQueue.Count > 0)
        {
            var minListNode = priorityQueue.Dequeue();
            
            // Add current minimum to result
            if (result == null)
            {
                result = minListNode;
                resultLast = result;
            }
            else
            {
                resultLast.next = minListNode;
                resultLast = resultLast.next;
            }
            
            // Add next list node to Priority Queue
            if (minListNode.next != null)
            {
                priorityQueue.Enqueue(minListNode.next, minListNode.next.val);
            }
        }
        
        return result;
    }
}