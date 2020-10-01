using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;


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

        public static string LargestTimeFromDigits(int[] A)
        {
            StringBuilder st = new StringBuilder();
            HashSet<int> used = new HashSet<int>();
            int maxTime = -1;
            string result = string.Empty;

            BuildString(st, used, A, 0, 0, ref maxTime, ref result);
            return result;
        }

        private static void BuildString(StringBuilder st, HashSet<int> used, int[] A, int hours, int minutes, ref int maxTime, ref string result)
        {
            if (used.Count == A.Length)
            {
                if (st.Length == 4 && hours * 60 + minutes > maxTime)
                {
                    maxTime = hours * 60 + minutes;
                    st.Insert(2, ":");
                    result = st.ToString();
                    st.Remove(2, 1);
                }
                return;
            }

            for (int i = 0; i < A.Length; i++)
            {
                if (used.Contains(i)) { continue; }

                if (st.Length < 2 && hours * 10 + A[i] < 24)
                {
                    st.Append(A[i]);
                    used.Add(i);
                    BuildString(st, used, A, hours * 10 + A[i], minutes, ref maxTime, ref result);
                    used.Remove(i);
                    st.Length--;
                }
                else if (st.Length >= 2 && minutes * 10 + A[i] < 60)
                {
                    st.Append(A[i]);
                    used.Add(i);
                    BuildString(st, used, A, hours, minutes * 10 + A[i], ref maxTime, ref result);
                    used.Remove(i);
                    st.Length--;
                }
            }
        }

        public static int StrStr(string haystack, string needle)
        {
            if (needle == "" || needle == "") return 0;
            var arrOrigin = haystack.ToCharArray();

            var target = needle.ToCharArray()[0];

            return Array.IndexOf(arrOrigin, target);
        }

        public static string[] FindWords(string[] words)
        {
            List<string> keyboard = new List<string>(){
                 "qwertyuiopQWERTYUIOP",
                 "asdfghjklASDFGHJKL",
                 "zxcvbnmZXCVBNM"
            };

            return words.Where(w => keyboard.Any(k => w.All(k.Contains))).ToArray();
        }

        public static int FindSpecialInteger(int[] arr)
        {
            int res = 0;
            Dictionary<int, int> ht = new Dictionary<int, int>();

            foreach(int c in arr)
            {
                if (ht.ContainsKey(c))
                {
                    ht[c] += 1;
                }
                else
                {
                    ht.Add(c, 1);
                }
            }
            int max = ht.Values.Max();
            return ht.Where(x=>x.Value == max).Select(x=>x.Key).First();
        }

        public static IList<int> SpiralOrder(int[][] matrix)
        {
            IList<int> spiral = new List<int>();

            for(int i = 0; i < matrix.Length; i++)
            {
                for(int j = 0; j < matrix[i].Length; j++)
                {
                    spiral.Add(matrix[i][j]);
                }
            }

            return spiral;
        }

        public static bool IsToeplitzMatrix(int[][] matrix)
        {
            List<bool> list = new List<bool>();

            for(int i = 1; i < matrix.Length; i++)
            {
                for(int j = 1; j < matrix[i].Length; j++)
                {
                    if(matrix[i][j] == matrix[i - 1][j - 1])
                    {
                        list.Add(true);
                    }
                    else
                    {
                        list.Add(false);
                    }
                }
            }
            
            return list.All(x=>x == true);
        }

        public static List<string> getUsernames(int threshold)
        {
            List<string> result = new List<string>();
            HttpClient Http = new HttpClient();
            var jsonString = Http.GetStringAsync("https://jsonmock.hackerrank.com/api/article_users?page=1").Result;
            var jsonString2 = Http.GetStringAsync("https://jsonmock.hackerrank.com/api/article_users?page=2").Result;
            var response = JsonConvert.DeserializeObject<OtvetJson>(jsonString);
            var response2 = JsonConvert.DeserializeObject<OtvetJson>(jsonString2);

            foreach(var data in response2.data)
            {
                response.data.Add(data);
            }

            foreach (var Item in response.data)
            {
                var usernames = response.data
                    .Where(x => x.submission_count > threshold)
                    .Select(x => x.username)
                    .ToList();

                result = usernames;
            }

            return result;
        }

        public static bool CanJump(int[] nums)
        {
            if (nums.Length == 0 || nums == null) return false;

            int lastGoodIndexPosition = nums.Length - 1;

            for(int i = nums.Length - 1; i >= 0; i--)
            {
                if(i+nums[i] >= lastGoodIndexPosition)
                {
                    lastGoodIndexPosition = i;
                }
            }

            return lastGoodIndexPosition == 0;
        }

        public static bool IncreasingTriplet(int[] nums)
        {
            if (nums.Length < 3) return false;

            bool result = false;
            int min = int.MaxValue;
            int mid = int.MaxValue;

            for(int i = 0; i < nums.Length; i++)
            {
                if(nums[i] <= min)
                {
                    min = nums[i];
                }
                else if(nums[i] <= mid)
                {
                    mid = nums[i];
                }
                else
                {
                    result = true;
                    break;
                }
            }

            return result;
        }


        public static int[] PrefizSum(int[] a)
        {
            int[] PrefixSum = new int[a.Length];

            for(int i = 0; i < a.Length; i++)
            {
                PrefixSum[i] = a[i];
                if (i > 0)
                {
                    PrefixSum[i] += PrefixSum[i - 1];
                }
            }

            return PrefixSum;
        }


        public static int DiagonalSum(int[][] mat)
        {
            List<int> elements = new List<int>();

            int first = 0;
            int last = mat[0].Length-1;

            for (int i = 0; i < mat.Length; i++)
            {
                if(first == last)
                {
                    elements.Add(mat[first][last]);
                    first++; last--;
                }
                else
                {
                    elements.Add(mat[i][first]);
                    elements.Add(mat[i][last]);
                    first++; last--;
                }

            }


            return elements.Sum();
        }

        public static int[] SortByBits(int[] arr)
        {
            Array.Sort(arr, (n1, n2) =>
            {
                var onesCount1 = countOnes(n1);
                var onesCount2 = countOnes(n2);
                var onesCmp = onesCount1.CompareTo(onesCount2);
                if (onesCmp != 0)
                {
                    return onesCmp;
                }

                return n1.CompareTo(n2);
            });

            return arr;
        }

        private static int countOnes(int n)
        {
            int res = 0;

            for (int i=0;i<32;i++)
            {
                if((n & (1 << i)) != 0)
                {
                    res++;
                }
            }

            return res;
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            if(nums == null || nums.Length < 2)
            {
                return null;
            }

            Dictionary<int, int> ht = new Dictionary<int, int>();

            for(int i = 0; i < nums.Length; i++)
            {
                int need = target - nums[i];
                if (ht.ContainsKey(need))
                {
                    int[] result = { i, ht[need] };
                    return result;
                }
                ht.Add(nums[i], i); 
            }

            return null;
        }


        //Learn dynamic programming concepts!!!
        public static int ClimbStairs(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;

            var arr = new int[n + 1];

            arr[1] = 1;
            arr[2] = 2;

            for(int i = 3; i < n+1; i++)
            {
                arr[n] = arr[n - 1] + arr[n - 2];
            }

            return arr[n];
            
        }

        static void Main(string[] args)
        {

            int[] arr = new int[] { 2, 7, 11, 15 };

            int[][] matrix = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 }
            };


            //Console.WriteLine(ClimbStairs(4));

            foreach(int c in TwoSum(arr, 9))
            {
                Console.WriteLine(c);
            }

        }
    }

    public class data
    {
        public int number { get; set; }
        public int ones { get; set; }
    }

    public class OtvetJson
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<UserRecord> data { get; set; }
    }

    public class UserRecord
    {
        public int Id { get; set; }

        public string username { get; set; }

        public string about { get; set; }

        public int submitted { get; set; }

        public string updated_at { get; set; }

        public int submission_count { get; set; }

        public int comment_count { get; set; }
    }
}
