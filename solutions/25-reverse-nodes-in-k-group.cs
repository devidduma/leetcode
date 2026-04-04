public class ReverseNodesInKGroupSolution 
{
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        ListNode result = null;
        ListNode resultLast = null;
        
        // 1-Group
        if (k == 1)
        {
            return head;
        }
        
        // Priority Queue arrangement of ListNodes
        var priorityQueue = new PriorityQueue<(ListNode, ListNode), int>();

        var index = -1;
        ListNode segment = null;
        ListNode segmentLast = null;
        ListNode restNodes = null;
        var restNodesIndex = index;
        
        for (var currNode = head; currNode != null; currNode = currNode.next)
        {
            index += 1;
            
            // New node of segment
            var newNode = new ListNode(currNode.val, segment);
            segment = newNode;
            
            // First element of segment
            if (index % k == 0)
            {
                segmentLast = newNode;
                restNodes = currNode;
                restNodesIndex = index;
            }
            // Last element of segment
            else if (index % k == k - 1)
            {
                // Add segment to Priority Queue
                priorityQueue.Enqueue((segment, segmentLast), index);
                segment = null;
            }
        }
        
        // Construct result from Priority Queue
        while (priorityQueue.Count > 0)
        {
            var (minSegment, minSegmentLast) = priorityQueue.Dequeue();
            
            // Add current minimum to result
            if (result == null)
            {
                result = minSegment;
                resultLast = minSegmentLast;
            }
            else
            {
                resultLast.next = minSegment;
                resultLast = minSegmentLast;
            }
        }
        
        // Rest nodes in the end
        if (index - restNodesIndex + 1 < k)
        {
            resultLast.next = restNodes;
        }
        
        return result;
    }
}