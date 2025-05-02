using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lEETcODE1
{
    public class LinkedListCycle
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }

        public bool HasCycle(ListNode head)
        {
            ListNode slowPtr = head;
            ListNode fastPtr = head;
            while (slowPtr != null && fastPtr != null && fastPtr.next != null) { 
                
                slowPtr = slowPtr.next;
                fastPtr = fastPtr.next.next;
                if (fastPtr == slowPtr)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
