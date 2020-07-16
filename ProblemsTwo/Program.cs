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

        public ListNode mergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode(0);
            ListNode res = head;

            while(l1!=null && l2 != null)
            {
                if (l1.val > l2.val)
                {
                    res.next = l2;
                    l2 = l2.next;
                }
                else
                {
                    res.next = l1;
                    l1 = l1.next;
                }

                res = res.next;
            }

            if (l1 != null)
            {
                res.next = l1;
                l1 = l1.next;
            }

            if(l2 != null)
            {
                res.next = l2;
                l2 = l2.next;
            }

            return head.next;
        }

        public static List<long> Djai(List<int> l1)
        {
            List<long> res = new List<long>();

            l1.Reverse();

            long num = Int64.Parse(String.Join("", l1));

            while (num != 0)
            {
                res.Add(num % 10);
                num = num / 10;
            }


            return res;

        }

        public ListNode AddTwoNumbersExtra(ListNode l1, ListNode l2)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            while (l1 != null)
            {
                list1.Add(l1.val);
                l1 = l1.next;
            }
            while (l2 != null)
            {
                list2.Add(l2.val);
                l2 = l2.next;
            }

            list1.Reverse();
            list2.Reverse();
            long sum = Int64.Parse(String.Join("", list1)) + Int64.Parse(String.Join("", list2));
            if (sum == 0)
            {
                return new ListNode(0);
            }

            ListNode head = new ListNode(0);
            ListNode res = head;

            while (sum != 0)
            {
                res.next = new ListNode((int)sum % 10);
                sum = sum / 10;
                res = res.next;
            }

            

            return head.next;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode(0);
            ListNode res = head;

            int carry = 0;

            while(l1!=null || l2 != null)
            {
                int l1_val = (l1.val != null) ? l1.val : 0;
                int l2_val = (l2.val != null) ? l2.val : 0;


                int current_sum = l1_val + l2_val + carry;
                int last_digit = current_sum / 10;
                carry = current_sum / 10;
                ListNode new_node = new ListNode(last_digit);
                res.next = new_node;

                if (l1 != null)
                {
                    l1 = l1.next;
                }
                if(l2 != null)
                {
                    l2 = l2.next;
                }
                res = res.next;
            }

            if (carry > 0)
            {
                ListNode new_node = new ListNode(carry);
                res.next = new_node;
                res = res.next;
            }

            return head.next;
        }

        

        static void Main(string[] args)
        {
            //2->1->3->5->6->4->7->NULL
            //2->3->6->7->1->5->4->NULL

            //List<int> l1 = new List<int> { 1, 9, 9, 9, 9, 9, 9, 9, 9, 9 };

            //foreach (int c in Djai(l1))
            //{
            //    Console.WriteLine(c);
            //}

            //Console.WriteLine("Hello World!");



            //int[] arr = new int[] {7};

            //foreach(int c in PlusOne(arr))
            //{
            //    Console.WriteLine(c);
            //}
        }
    }
}
