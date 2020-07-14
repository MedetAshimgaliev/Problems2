using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProblemsTwo
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    class Program
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            List<ListNode> visited = new List<ListNode>();

            while (headA != null)
            {
                visited.Add(headA);
                headA = headA.next;
            }

            while(headB != null)
            {
                if (visited.Contains(headB))
                {
                    return headB;
                }

                headB = headB.next;
            }

            return null;            
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode start = new ListNode(0);

            ListNode slow = start;
            ListNode fast = start;
            slow.next = head;

            //Move fast in front so that the gap between slow and fast becomes n
            for (int i = 1; i <= n + 1; i++)
            {
                fast = fast.next;
            }
            //Move fast to the end, maintaining the gap
            while (fast != null)
            {
                slow = slow.next;
                fast = fast.next;
            }
            //Skip the desired node
            slow.next = slow.next.next;
            return start.next;
        }

        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode curr = head;
            ListNode next = null;

            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
        }

        public ListNode RemoveElements(ListNode head, int val)
        {
            while(head!=null && head.val == val)
            {
                head = head.next;
            }
            ListNode curr = head;
            while (curr != null && curr.next != null)
            {
                if (curr.next.val == val)
                {
                    curr.next = curr.next.next;
                }
                else
                {
                    curr = curr.next;
                }
            }

            return head;
        }

        public ListNode OddEvenList(ListNode head)
        {
            ListNode init = head;

            ListNode res = new ListNode(0);

            ListNode resNode = res;

            int idx = 1;

            while (init != null)
            {
                if (idx % 2 == 1)
                {
                    resNode.next = new ListNode(init.val);
                    resNode = resNode.next;
                }
                init = init.next;
                idx++;
            }
            init = head;
            idx = 1;

            while (init != null)
            {
                if (idx % 2 == 0)
                {
                    resNode.next = new ListNode(init.val);
                    resNode = resNode.next;
                }
                init = init.next;
                idx++;
            }

            resNode.next = null;
            return res.next;
        }

        public bool IsPalindrome(ListNode head)
        {
            Dictionary<int, int> ht = new Dictionary<int, int>();

            int idx = 0;
            while (head != null)
            {
                ht.Add(idx, head.val);
                idx++;
                head = head.next;
            }

            bool isPalindrome = true;
            for(int i = 0; i < ht.Count/2; i++)
            {
                if(ht[i] != ht[ht.Count - i - 1])
                {
                    isPalindrome = false;
                }
            }

            return isPalindrome;
        }

        static void Main(string[] args)
        {
            //2->1->3->5->6->4->7->NULL
            //2->3->6->7->1->5->4->NULL


            //Console.WriteLine("Hello World!");
        }
    }
}
