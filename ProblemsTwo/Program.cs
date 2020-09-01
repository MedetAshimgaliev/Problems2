using System;
using System.Collections;
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

        public ListNode RotateRight(ListNode head, int k)
        {
            ListNode newHead = null;
            while(k != 0)
            {
                while (head != null)
                {
                    if(head.next.next == null)
                    {
                        newHead = head.next;
                        head.next = null;
                        head = newHead;
                    }
                    head = head.next;
                }
                k--;
            }
            return head.next;
        }

        public static int NumIdenticalPairs(int[] nums)
        {
            int cnt = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = i; j < nums.Length; j++)
                {
                    if(nums[i] == nums[j] && i < j)
                    {
                        cnt++;
                    }
                }
            }
            return cnt;
        }

        public static int BalancedStringSplit(string s)
        {
            int count = 0;
            int balance = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'L')
                {
                    balance++;
                }
                else
                {
                    balance--;
                }
                if (balance == 0)
                {
                    count++;
                }
            }
            return count;
        }

        public static int UniqueMorseRepresentations(string[] words)
        {
            List<string> alpha = new List<string> { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };

            List<string> set = new List<string>();

            foreach(string word in words)
            {
                string wordMorse = string.Empty;

                foreach(char letter in word.ToCharArray())
                {
                    int idx = (int)letter % 32;
                    wordMorse += alpha[idx-1];
                }

                set.Add(wordMorse);

                wordMorse = string.Empty;
            }

            Dictionary<string, int> ht = new Dictionary<string, int>();

            foreach(string s in set)
            {
                if (ht.ContainsKey(s))
                {
                    ht[s] += 1;
                }
                else
                {
                    ht.Add(s, 1);
                }
            }


            return ht.Count;
        }

        public static bool IsUniqueChars2(String str)
        {
            if (str.Length > 256)
            {
                return false;
            }

            var charSet = new bool[256];

            for (var i = 0; i < str.Length; i++)
            {
                int val = str[i];

                if (charSet[val])
                {
                    return false;
                }
                charSet[val] = true;
            }

            return true;
        }

        public static bool isPermutation(string str, string str2)
        {
            if(str.Length != str2.Length)
            {
                return false;
            }
            else
            {
                Dictionary<char, int> ht = new Dictionary<char, int>();
                foreach(char letter in str)
                {
                    if (ht.ContainsKey(letter))
                    {
                        ht[letter] += 1;
                    }
                    else
                    {
                        ht.Add(letter, 1);
                    }
                }

                foreach(char letter in str2)
                {
                    if (ht.ContainsKey(letter))
                    {
                        ht[letter] -= 1;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (ht.Values.All(x => x == 0)) { return true; }
            }

            return false;
        }

        public static string Q1_3(string str)
        {
            //string res = str.Replace(' ', '%20');
            return string.Empty;
        }

        public static string Q1_4(string str)
        {
            var pure = str.Replace(" ", "").ToLower();
            var arr = pure.ToCharArray();

            Array.Sort(arr);
            return string.Join("",arr);
        }

        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode p = head;

            while (p != null && p.next != null)
            {
                if (p.val == p.next.val)
                {
                    p.next = p.next.next;
                }
                else
                {
                    p = p.next;
                }
            }

            return head;
        }

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int count = 0;
            List<int> list = new List<int>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    list.Add(count);
                    count = 0;
                }
                else
                {
                    count++;
                }
                list.Add(count);
            }

            return list.Max();
        }

        public static int FindNumbers(int[] nums)
        {
            List<int> list = new List<int>();

            int cnt = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                while (nums[i] > 0)
                {
                    nums[i] = nums[i] / 10;
                    cnt++;
                }
                if (cnt % 2 == 0)
                {
                    list.Add(cnt);
                }

                cnt = 0;
            }

            return list.Count();
        }

        public static int[] SortedSquares(int[] A)
        {
            List<int> res = new List<int>();

            for(int i = 0; i < A.Length; i++)
            {
                res.Add(A[i] * A[i]);
            }

            res.Sort();

            return res.ToArray();
        }


        public static int beautifulTriplets(int d, int[] arr)
        {
            int triplets = 0;

            for(int i = 0; i < arr.Length; i++)
            {
                if(arr.Contains(arr[i]+d) && arr.Contains(arr[i] + 2 * d))
                {
                    triplets++;
                }
            }

            return triplets;
        }

        public static int[] serviceLane(int n, int[][] cases)
        {
            List<int> list = new List<int>();
            List<int> res = new List<int>();

            int i = 0;

            foreach(var item in cases)
            {
                if (i == 0)
                {
                    foreach(var c in item)
                    {
                        list.Add(c);
                    }
                }
                else
                {
                    int start = item[0];
                    int end = item[1];
                    int min = int.MaxValue;
                    for (int j = start; j <= end; j++)
                    {
                        if (list[j] < min)
                        {
                            min = list[j];
                        }
                    }
                    res.Add(min);
                }
                i++;
            }

            return res.ToArray();
        }

        public static int chocolateFeast(int n, int c, int m)
        {
            int wrappers = n / c;
            int count = wrappers;
            while (wrappers >= m)
            {
                count += wrappers / m;
                wrappers = wrappers / m + wrappers % m;
            }
            
            return count;
        }

        public static int LengthOfLastWord(string s)
        {
            int len = 0;

            // String a is 'final'-- can 
            // not be modified So, create 
            // a copy and trim the 
            // spaces from both sides 
            string x = s.Trim();

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == ' ')
                {
                    len = 0;
                }
                else
                {
                    len++;
                }
            }

            return len;
        }

        public static bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            bool res = rec1[0] < rec2[2] && rec1[1] < rec2[3] && rec2[0] < rec1[2] && rec2[1] < rec1[3];
            return res;
        }


        public static bool LemonadeChange(int[] bills)
        {
            int fiveDollars = 0;
            int tenDollars = 0;

            foreach(int c in bills)
            {
                if(c == 5)
                {
                    fiveDollars++;
                }
                else if(c == 10)
                {
                    tenDollars++;
                    fiveDollars--;
                }
                else if(tenDollars > 0)
                {
                    tenDollars--;
                    fiveDollars--;
                }
                else
                {
                    fiveDollars -= 3;
                }
            }

            if(fiveDollars < 0)
            {
                return false;
            }

            return true;
        }

        public static bool JudgeCircle(string moves)
        {
            int up = 0;
            int down = 0;
            int left = 0;
            int right = 0;

            foreach(char c in moves.ToCharArray())
            {
                switch (c)
                {
                    case 'U':
                        up += 1;
                        break;
                    case 'D':
                        down += 1;
                        break;
                    case 'R':
                        right += 1;
                        break;
                    case 'L':
                        left += 1;
                        break;
                }
            }

            return up == down && left == right;
        }

        public static int FindLengthOfLCIS2(int[] nums)
        {
            if (nums.Length == 0 || nums == null) return 0;
            int count = 1;
            List<int> list = new List<int>();
            for(int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    count++;
                }
                else
                {
                    list.Add(count);
                    count = 0;
                }
            }
            return list.Count == 0 ? count : list.Max();
        }

        public static int FindLengthOfLCIS(int[] nums)
        {
            int result = 0;
            int anchor = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                if(i>0 && nums[i-1] >= nums[i])
                {
                    anchor = i;
                }
                result = Math.Max(result, i - anchor + 1);
            }

            return result;
        }

        public static IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> triangle = new List<IList<int>>();

            if(numRows == 0)
            {
                return triangle;
            }

            List<int> first_row = new List<int>();
            first_row.Add(1);
            triangle.Add(first_row);

            for(int i = 1; i < numRows; i++)
            {
                List<int> prev_row = (List<int>)triangle[i - 1];
                List<int> row = new List<int>();

                row.Add(1);

                for(int j = 1; j < i; j++)
                {
                    row.Add(prev_row[j - 1] + prev_row[j]);
                }

                row.Add(1);

                triangle.Add(row);

            }

            return triangle;
        }

        public static int StrStr(string haystack, string needle)
        {
            return 0;
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 3, 5, 4, 2, 3, 4, 5 };

            int[][] jaggedArray = new int[][]
            {
                new int[] { 2, 3, 1, 2, 3, 2, 3, 3 },
                new int[] { 0, 3 },
                new int[] { 4,6 },
                new int[] { 6,7 },
                new int[] { 3,5 },
                new int[] { 0,7 }
            };

            var output = serviceLane(8,jaggedArray);

            foreach(var row in Generate(5))
            {
                Console.WriteLine(String.Join(' ', row));
            }

            
        }
    }
}
