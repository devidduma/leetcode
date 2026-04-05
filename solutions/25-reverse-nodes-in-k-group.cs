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
        
        // Index of node in list
        var index = -1;
        
        // Segment of reversed nodes in K-Group
        ListNode segment = null;
        ListNode segmentLast = null;
        
        // Rest nodes
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
                // Add segment to result
                if (result == null)
                {
                    result = segment;
                    resultLast = segmentLast;
                }
                else
                {
                    resultLast.next = segment;
                    resultLast = segmentLast;
                }
                
                // Reset segment
                segment = null;
            }
        }
        
        // Add rest nodes in the end
        if (index - restNodesIndex + 1 < k)
        {
            if (resultLast == null)
            {
                result = restNodes;
            }
            else
            {
                resultLast.next = restNodes;
            }
        }
        
        return result;
    }
}