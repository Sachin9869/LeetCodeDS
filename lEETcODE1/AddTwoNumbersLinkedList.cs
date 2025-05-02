using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lEETcODE1
{
    public class AddTwoNumbersLinkedList
    {
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

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);
            ListNode ptr = result;

            
            int carry = 0;

            while (l1 != null || l2 != null) 
            {
                int sum = 0 + carry;
                if (l1 != null)
                {
                    sum = sum + l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    sum = sum + l2.val;
                    l2 = l2.next;
                }

                sum = sum % 10;
                carry = carry / 10;
                ptr.next = new ListNode(sum);
                ptr = ptr.next;
            }

            if (carry == 1)
            {
                ptr.next = new ListNode(1);
            }

            return result.next;
        }
    }
}
