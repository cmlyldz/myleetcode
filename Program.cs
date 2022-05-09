using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Xml;

namespace LeetCode
{
    class Program
    {
        #region definitions

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

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        public class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;
        }

        #endregion


        public static void Main(string[] args)
        {
            char[][] numofis = new char[][] { new char[]{ '1', '1', '1' }, new char[] { '0', '1', '0' }, new char[] { '1', '1', '1' } };

            var numofislands = NumIslands(numofis);

            int[][] res = new int[3][];
            StringBuilder sb = new StringBuilder();

            sb.Append("a");

            var mxUn = MaximumUnits(
                new int[][] { new int[] { 5, 10 }, new int[] { 2, 5 }, new int[] { 4, 7 }, new int[] { 3, 9 } }, 10);

            var tictactoe = Tictactoe(new int[][]
            {
                new int[] { 0, 0 },
                new int[] { 2, 0 }, new int[] { 1, 1 }, new int[] { 2, 1 }, new int[] { 2, 2 }
            });

            var fuc = FirstUniqChar("leetcode");

            var cmbSum = CombinationSum(new int[] { 2, 3, 5 }, 9);

            /* KthLargest(3, new int[] { 4, 5, 8, 2 });
 
 
             var t3sum = ThreeSum(new int[] { -1, -1, 0, 0 , 1, 1 });
 
             var subset = Subsets(new int[] { 1, 2, 3 });
 
             LongestConsecutive(new[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 });
 
             var pes = ProductExceptSelf(new[] { 1, 2, 3, 4 });
 
 
             var med = new List<int>() { 7, 3, 5, 2 };
 
             IsAnagram("ab", "a");
             //var medRes = runningMedian(denmeasdjgh);
 
             MinDeletions("aaabbcc");
             */
            //     3
            //  9     20
            //6      15  7
            TreeNode root = new TreeNode(3);
            TreeNode n2 = new TreeNode(9);
            TreeNode n3 = new TreeNode(20);
            TreeNode n4 = new TreeNode(15);
            TreeNode n5 = new TreeNode(7);
            TreeNode n6 = new TreeNode(6);



            root.right = n3;
            root.left = n2;

            n3.left = n4;
            n3.right = n5;

            n2.left = n6;

            var rsv = RightSideView(root);

            var denemeamazon = LevelOrder(root);

            //var denemebfs2 = BFS(node);

            denemeamazon.Reverse();
            int[] nums = { 2, 5 };
            Array.Sort(nums);
            //med.Sort();
            int target = 5;
            var result2 = BinarySearch(nums, target);

            var aas2 = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            Rotate(aas2, 3);

            var str = "3*2-1";

            int aas = Calculate2(str);

            var x2 = MySqrt(-1);

            var arr2 = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };
            var arr3 = new int[] { 2, 0, 2, 1, 1, 0 };

            QSort(arr3);

            var a = MaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });

            Demo.DemonstrationOpenClose();


            //var n = LongestPalindrome("aaaaa");

            //var x = amazon1("good");

            //Consumer();


            //var x = AtoiFunc("20000000000000000000");
            //x = AtoiFunc(" +12   4");

            ////Linq();
            ////Linq2();

            //ListNode node1 = new ListNode(2, new ListNode(4, new ListNode(3, null)));
            //ListNode node2 = new ListNode(5, new ListNode(6, new ListNode(4, null)));

            //ListNode res = AddTwoNumbers(node1, node2);

            int[] resultOfOptimized = TwoSumOptimized(new int[] { 1, 1, 2, 1, 1, 2 }, 4);
        }



        #region string

        private static int AtoiFunc(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;

            int sign = 0;

            string num = "";

            foreach (var c in s)
            {
                if (string.IsNullOrEmpty(num))
                {
                    if (c.Equals(' '))
                    {
                        if (sign != 0) break;
                        continue;
                    }
                    else if (c.Equals('+'))
                    {
                        if (sign != 0) break;
                        sign = 1;
                        continue;
                    }
                    else if (c.Equals('-'))
                    {
                        if (sign != 0) break;
                        sign = -1;
                        continue;
                    }
                }

                if (char.IsNumber(c))
                {
                    num += c;
                }
                else
                {
                    break;
                }
            }

            sign = sign == 0 ? 1 : sign;

            if (double.TryParse(num, out double result))
            {
                result *= sign;

                if (result > Int32.MaxValue) return Int32.MaxValue;
                else if (result < Int32.MinValue) return Int32.MinValue;

                return Convert.ToInt32(result);
            }

            return 0;
        }

        // guncellemeyi unutma telde var
        private static long amazon1(string password)
        {
            if (string.IsNullOrEmpty(password) && password.Length > 100000)
                return 0;

            HashSet<string> chars = new HashSet<string>();

            long result = 0;

            int length = 1;

            int counter = 0;

            string tmp = "";

            while (length < password.Length + 1)
            {
                tmp = password.Substring(counter, length);

                if (tmp.Length == 1)
                {
                    result++;
                }
                else
                {
                    long discCnt = 1;
                    string prev = tmp.Substring(0, 1);
                    chars.Add(prev);
                    for (int i = 1; i < tmp.Length; i++)
                    {
                        prev = tmp.Substring(i, 1);

                        if (!chars.Contains(tmp.Substring(i, 1)))
                        {
                            discCnt++;
                            chars.Add(prev);
                        }
                    }

                    result += discCnt;

                    chars = new HashSet<string>();
                }

                counter++;

                if (counter == (password.Length - length + 1))
                {
                    length++;
                    counter = 0;
                }
            }

            return result;
        }

        private static int LongestPalindromeLength(string s)
        {
            if (String.IsNullOrWhiteSpace(s)) return 0;

            if (s.Length == 1) return 1;

            Dictionary<string, Int32> charDictionary = new Dictionary<string, int>();

            foreach (var ch in s)
            {
                if (charDictionary.ContainsKey(ch.ToString()))
                {
                    charDictionary[ch.ToString()] += 1;
                }
                else
                {
                    charDictionary[ch.ToString()] = 1;
                }
            }

            int result = 0;

            Int16 singleChar = 0;

            foreach (var kvp in charDictionary)
            {
                if (kvp.Value % 2 == 0)
                {
                    result += kvp.Value;
                    continue;
                }

                result += kvp.Value - 1;

                singleChar = 1;
            }

            return result + singleChar;
        }

        private static string LongestPalindrome(string s)
        {
            if (String.IsNullOrWhiteSpace(s)) return "";

            if (s.Length == 1) return s;

            int stringLength = s.Length;
            int maxPalindromeStringLength = 0;
            int maxPalindromeStringStartIndex = 0;

            for (int i = 0; i < stringLength; i++)
            {
                int currentCharIndex = i;

                for (int lastCharIndex = stringLength - 1; lastCharIndex > currentCharIndex; lastCharIndex--)
                {
                    if (lastCharIndex - currentCharIndex + 1 < maxPalindromeStringLength)
                    {
                        break;
                    }

                    bool isPalindrome = true;

                    if (s[currentCharIndex] != s[lastCharIndex])
                    {
                        continue;
                    }
                    else
                    {
                        int matchedCharIndexFromEnd = lastCharIndex - 1;

                        for (int nextCharIndex = currentCharIndex + 1;
                             nextCharIndex < matchedCharIndexFromEnd;
                             nextCharIndex++)
                        {
                            if (s[nextCharIndex] != s[matchedCharIndexFromEnd])
                            {
                                isPalindrome = false;
                                break;
                            }

                            matchedCharIndexFromEnd--;
                        }
                    }

                    if (isPalindrome)
                    {
                        if (lastCharIndex + 1 - currentCharIndex > maxPalindromeStringLength)
                        {
                            maxPalindromeStringStartIndex = currentCharIndex;
                            maxPalindromeStringLength = lastCharIndex + 1 - currentCharIndex;
                        }

                        break;
                    }
                }
            }

            if (maxPalindromeStringLength > 0)
            {
                return s.Substring(maxPalindromeStringStartIndex, maxPalindromeStringLength);
            }

            return s.Substring(0, 1);
            ;
        }

        public static int Calculate(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;
            //s = s.Replace(" ", ""); makes it very slow
            Stack<int> stack = new Stack<int>();
            char op = '+';
            string num = "";

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ' && i + 1 != s.Length)
                    continue;

                int tmpNum = 0;
                if (char.IsDigit(s[i]))
                {
                    num += s[i];

                    if (i + 1 != s.Length)
                    {
                        continue;
                    }
                }

                switch (op)
                {
                    case '+':
                        if (int.TryParse(num, out tmpNum))
                            stack.Push(tmpNum);
                        break;
                    case '-':
                        if (int.TryParse(num, out tmpNum))
                            stack.Push(tmpNum * -1);
                        break;
                    case '*':
                        if (int.TryParse(num, out tmpNum))
                            stack.Push(stack.Pop() * tmpNum);
                        break;
                    case '/':
                        if (int.TryParse(num, out tmpNum))
                            stack.Push(stack.Pop() / tmpNum);
                        break;
                }

                op = s[i];
                num = "";
            }

            return stack.Sum();
        }

        public static int Calculate2(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;

            int res = 0;
            int prev = 0;
            char op = '+';
            string num = "";

            for (int i = 0; i < s.Length; i++)
            {
                int curr;
                if (s[i] == ' ' && i + 1 != s.Length)
                    continue;

                if (char.IsDigit(s[i]))
                {
                    num += s[i];

                    if (i + 1 != s.Length)
                        continue;
                }

                curr = int.Parse(num);

                switch (op)
                {
                    case '+':
                        res += prev;
                        prev = curr;
                        break;
                    case '-':
                        res += prev;
                        prev = -curr;
                        break;
                    case '*':
                        prev *= curr;
                        break;
                    case '/':
                        prev /= curr;
                        break;
                }

                op = s[i];
                num = "";
            }

            res += prev;
            return res;
        }

        public string DecodeString(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return "";

            List<string> strList = s.Select(c => c.ToString()).ToList();

            string res = "";
            string curr = "";
            string insider = "";
            int count = 0;
            bool start = false;
            bool end = false;
            bool isPrevInt = false;

            for (int i = 0; i < strList.Count; i++)
            {
                var c = strList[i];
                int tmpCnt = 0;
                if (int.TryParse(c, out tmpCnt))
                {
                    if (isPrevInt)
                    {
                        count = int.Parse(count.ToString() + c);
                        continue;
                    }

                    if (count != 0)
                    {
                        int countUpdate = s.Substring(i).IndexOf(']');
                        while (s.Substring(i, countUpdate).Count(ch => ch.Equals('[')) !=
                               s.Substring(i, countUpdate).Count(ch => ch.Equals(']')))
                            countUpdate++;

                        curr += DecodeString(s.Substring(i, countUpdate));
                        i += countUpdate - 1;
                        continue;
                    }

                    count = tmpCnt;
                    isPrevInt = true;
                    continue;
                }
                else
                    isPrevInt = false;

                if (c.Equals("["))
                {
                    start = true;
                    continue;
                }
                else if (c.Equals("]"))
                {
                    end = true;
                }

                if (start && end)
                {
                    //curr += insider;
                    res += new StringBuilder().Insert(0, curr, count).ToString();
                    curr = "";
                    insider = "";
                    count = 0;
                    start = false;
                    end = false;
                }
                else if (start && !end)
                {
                    curr += c;
                }
                else
                {
                    res += c;
                }
            }

            return res;
        }

        #endregion

        #region array

        private static int[] TwoSumOptimized(int[] nums, int target)
        {
            var numsDictionary = new Dictionary<int, int>();

            int complement;
            for (var i = 0; i < nums.Length; i++)
            {
                complement = target - nums[i];
                var index = 0;
                if (numsDictionary.TryGetValue(complement, out index))
                {
                    return new int[] { index, i };
                }

                if (numsDictionary.ContainsKey(nums[i]) == false)
                {
                    numsDictionary.Add(nums[i], i);
                }
            }

            return null;
        }

        public static int[] TwoSumSortedArrayInput(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length < 2) return new int[0];


            int l = 0;
            int r = numbers.Length - 1;
            int res;
            while (l < r)
            {
                res = numbers[l] + numbers[r];
                if (res > target)
                    --r;
                else if (res < target)
                    ++l;
                else
                    return new int[] { ++l, ++r };
            }

            return new int[0];
        }

        public static int MaxSubArray(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            Int32 newSum = nums[0], maxSum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                newSum = Math.Max(nums[i], nums[i] + newSum);
                maxSum = Math.Max(maxSum, newSum);
            }

            return maxSum;
        }

        public static void QSort(int[] arr)
        {
            QSort(arr, 0, arr.Length - 1);
        }

        public static void QSort(int[] arr, int low, int high)
        {
            if (low >= high || arr == null || arr.Length <= 1)
                return;

            int pivot = Partition(arr, low, high);
            QSort(arr, low, pivot - 1);
            QSort(arr, pivot + 1, high);
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[low];

            int i = low;
            int j = low + 1;

            while (j <= high)
            {
                if (arr[j] < pivot)
                    Swap(arr, ++i, j++);
                else
                    j++;
            }

            Swap(arr, i, low);

            return i;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            if (i == j)
                return;

            (arr[i], arr[j]) = (arr[j], arr[i]);
        }

        public static void Rotate(int[] nums, int k)
        {
            int[] result = new int[nums.Length];

            int i = 0;

            while (i < nums.Length)
            {
                if (k <= i)
                {
                    result[i++] = nums[++k];
                    continue;
                }

                if (k + 1 < nums.Length)
                {
                    result[i++] = nums[++k];
                    continue;
                }
                else if (k == nums.Length)
                {
                    k = 0;
                }
            }

            Array.Copy(result, nums, nums.Length);

        }

        #endregion

        #region AMAZON

        public static int BinarySearch(int[] nums, int target)
        {
            if (nums == null) return -1;

            int right = nums.Length - 1;
            int left = 0;
            int pvt;

            while (right >= left)
            {
                pvt = left + (right - left) / 2;
                if (nums[pvt] == target) return pvt;
                else if (nums[pvt] < target) left = pvt + 1;
                else right = pvt - 1;
            }

            return -1;
        }

        public static List<int> contacts(List<List<string>> queries)
        {
            if (queries == null) return null;
            var result = new List<int>();
            var currentList = new List<string>();
            foreach (var v in queries)
            {
                string op = v[0];
                if (op.Equals("add"))
                    currentList.Add(v[1]);

                else if (op.Equals("find"))
                {
                    var exist = currentList.FindAll(s => s.StartsWith(v[1]));
                    if (exist != null)
                        result.Add(exist.Count);
                    else
                        result.Add(0);
                }
            }

            return result;


        }

        public static List<double> runningMedian(List<int> a)
        {
            List<double> medianList = new List<double>();
            List<int> sorted = new List<int>();
            medianList.Add(a[0]);
            sorted.Add(a[0]);
            for (int i = 1; i < a.Count; i++)
            {
                var index = sorted.FindIndex(j => j > a[i]);

                if (index == -1)
                    sorted.Add(a[i]);
                else
                    sorted.Insert(index, a[i]);

                if (sorted.Count % 2 == 0)
                {
                    double val = (sorted[i / 2 + 1] + sorted[i / 2]) / 2.0;
                    medianList.Add(val);
                }
                else
                {
                    medianList.Add(sorted[i / 2]);
                }

            }

            return medianList;
        }

        public static bool Exist(char[][] board, string word)
        {

            // Create a 'visitied' node matrix to keep track of the
            // items we've already seen
            var rowsVisited = new bool[board.Length][];
            for (int rowIndex = 0; rowIndex < board.Length; ++rowIndex)
            {
                rowsVisited[rowIndex] = new bool[board[rowIndex].Length];
            }

            // Start at the node node and explore as far as possible along each branch
            for (int rowIndex = 0; rowIndex < board.Length; ++rowIndex)
            {
                for (int colIndex = 0; colIndex < board[rowIndex].Length; ++colIndex)
                {
                    if (DFS(board, rowIndex, colIndex, 0, word, rowsVisited))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool DFS(char[][] board, int row, int col, int searchIndex, string word, bool[][] rowsVisited)
        {
            // Make sure the search paramaters are in bounds
            if (searchIndex >= word.Length)
            {
                return true;
            }

            if (row < 0 || row >= board.Length || col < 0 || col >= board[row].Length)
            {
                return false;
            }

            if (rowsVisited[row][col])
            {
                return false;
            }

            if (board[row][col] != word[searchIndex])
            {
                return false;
            }

            // Mark that this row has been visited
            rowsVisited[row][col] = true;

            var searchResult =
                // Search left
                DFS(board, row, col - 1, searchIndex + 1, word, rowsVisited) ||

                // Search right
                DFS(board, row, col + 1, searchIndex + 1, word, rowsVisited) ||

                // Search top
                DFS(board, row - 1, col, searchIndex + 1, word, rowsVisited) ||

                // Search bottom
                DFS(board, row + 1, col, searchIndex + 1, word, rowsVisited);

            // Unmark that this row has been visited
            rowsVisited[row][col] = false;

            return searchResult;
        }


        public static int FirstUniqChar(string s)
        {
            var counts = new Dictionary<char, int>();

            foreach (var c in s)
            {
                if (counts.ContainsKey(c))
                    counts[c]++;
                else
                    counts.Add(c, 1);
            }

            if (counts.ContainsValue(1))
            {
                foreach (var kvp in counts)
                {
                    if (kvp.Value == 1)
                        return s.IndexOf(kvp.Key);
                }
            }

            return -1;
        }


        #endregion

        #region linkedList

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);
            ListNode head = result;
            int carry = 0;

            while (l1 != null || l2 != null)
            {
                int sum = carry;

                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                if (sum >= 10)
                {
                    carry = sum / 10;
                    sum = sum % 10;
                }
                else
                {
                    carry = 0;
                }

                result.next = new ListNode(sum);
                result = result.next;
            }

            if (carry > 0)
            {
                result.next = new ListNode(carry);
            }

            return head = head.next;
        }

        private static int amazon2(SinglyLinkedListNode head)
        {
            if (head == null)
                return 0;

            int result = head.data;

            var listNodes = new List<int>();

            SinglyLinkedListNode curr = head.next;

            while (curr.next != null)
            {
                listNodes.Add(curr.data);
                curr = curr.next;
            }

            result += curr.data;

            int count = listNodes.Count;

            for (int i = 0; i < count / 2; i++)
            {
                if (listNodes[i] + listNodes[count - i - 1] > result)
                    result = listNodes[i] + listNodes[count - i - 1];
            }


            return result;
        }

        #endregion

        #region tree
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();

            if (root == null) return result;

            recLevelOrder(result, root, 0);

            return result;
        }

        public static void recLevelOrder(List<IList<int>> result, TreeNode node, int height)
        {
            if (node == null) return;

            if (height >= result.Count())
            {
                result.Add(new List<int>());
            }

            result[height].Add(node.val);
            recLevelOrder(result, node.left, height + 1);
            recLevelOrder(result, node.right, height + 1);
        }

        public static int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }

        public static List<int> BFSQueue(TreeNode root)
        {
            if (root == null) return new List<int>();

            var result = new List<int>();
            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                TreeNode node = q.Dequeue();

                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);

                result.Add(node.val);
            }

            return result;
        }


        public static IList<int> RightSideView(TreeNode root)
        {
            if (root == null) return new List<int>();
            List<int> result = new List<int>();
            int level = 0;
            recRSV(root, level + 1, result);

            return result;
        }

        public static void recRSV(TreeNode tn, int level, List<int> result)
        {
            if (tn != null)
            {
                if (result.Count < level)
                    result.Add(tn.val);
                recRSV(tn.right, level + 1, result);
                recRSV(tn.left, level + 1, result);
            }

        }

        public static int DiameterOfBinaryTree(TreeNode root)
        {
            int sum = 0;

            RecHeight(root);
            return sum;

            int RecHeight(TreeNode node)
            {
                if (node == null) return 0;
                int l = RecHeight(node.left);
                int r = RecHeight(node.right);
                sum = Math.Max(sum, l + r);
                return Math.Max(l, r) + 1;
            }
        }

        public static bool HasPathSum(TreeNode node, int sum)
        {
            if (node == null) return false;

            int subSum = sum - node.val;

            return (HasPathSum(node.left, subSum) || HasPathSum(node.right, subSum));
        }

        public bool IsValidBST(TreeNode node) => IsValidBSTHelper(node);

        private bool IsValidBSTHelper(TreeNode node, int? min = null, int? max = null)
        {
            if (node == null)
            {
                return true;
            }

            if ((min.HasValue && node.val <= min) || (max.HasValue && node.val >= max))
            {
                return false;
            }


            return IsValidBSTHelper(node.left, min, node.val) && IsValidBSTHelper(node.right, node.val, max);
        }

        public static int ClosestValue(TreeNode root, double target)
        {

            var result = new List<double>() { root.val, Math.Abs(root.val - target) };
            //double[] result = new double[] {root.val, Math.Abs(root.val - target)};
            ClosestValueHelper(root, target, result);

            return (int)result[0];
        }

        private static void ClosestValueHelper(TreeNode node, double target, List<double> res)
        {

            if (Math.Abs(node.val - target) < res[1])
            {
                res[0] = node.val;
                res[1] = Math.Abs(node.val - target);
            }


            if (node.left != null && target < node.val + .6)
                ClosestValueHelper(node.left, target, res);
            if (node.right != null && target > node.val - .6)
                ClosestValueHelper(node.right, target, res);

        }

        public static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            if (root == null) return new List<IList<int>>();

            var res = new List<IList<int>>();

            ZLOHelper(root, res, 0);

            return res;
        }

        private static void ZLOHelper(TreeNode node, List<IList<int>> res, int level)
        {
            if (res.Count <= level)
                res.Add(new List<int>());

            if (level % 2 == 0)
                res[level].Add(node.val);
            else
                //res[level].Add(node.val);
                res[level].Insert(0, node.val);

            if (node.left != null) ZLOHelper(node.left, res, level + 1);
            if (node.right != null) ZLOHelper(node.right, res, level + 1);
        }

        #endregion

        #region others

        public static int MySqrt(int x)
        {
            if (x <= 0)
                return 0;
            long r = x;
            while (r * r > x)
                r = ((r + x / r) / 2) | 0;
            return (int)r;
        }

        public static void Linq()
        {
            int[] numbers = { 2, 4, 6, 1, 234, 1234, 98, 1, 66, 34 };

            var getnumbers = from number in numbers
                where number < 77
                orderby number //descending
                select number;

            System.Console.WriteLine(string.Join(", ", getnumbers));
        }

        public static void Linq2()
        {
            string[] catNames = { "loki", "oscar", "Lucky", "bella", "Toby", "tobias" };

            List<string> getCatName = (from cat in catNames
                where (cat.Contains('a')) && (cat.Length < 5)
                select cat).ToList();

            System.Console.WriteLine(string.Join(", ", catNames));
        }

        public static int MinDeletions(string s)
        {
            int res = 0;
            Dictionary<char, int> dict = s.GroupBy(o => o).ToDictionary(o => o.Key, o => o.Count());
            HashSet<int> hs = new HashSet<int>();
            foreach (var item in dict)
            {
                int cur = item.Value;
                while (!hs.Add(cur) && cur > 0)
                {
                    res++;
                    cur--;
                }
            }

            return res;
        }

        public static bool ContainsDuplicate(int[] nums)
        {
            return nums.Distinct().Count() != nums.Length;
        }

        public static bool IsAnagram(string s, string t)
        {
            var mapCount = new int[26];

            for (int i = 0; i < s.Length; i++) // count all chars of the first string
                mapCount[s[i] - 'a']++;

            for (int i = 0; i < t.Length; i++)
            {
                mapCount[t[i] - 'a']--; // subtract all chars of the second string
                if (mapCount[t[i] - 'a'] < 0) return false; // if subtracts more than existing then is not an anagram

            }

            // check if omits to subtract any char
            for (int i = 0; i < mapCount.Length; i++)
                if (mapCount[i] != 0)
                    return false;

            return true;
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<IList<string>> ans = new List<IList<string>>();
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            foreach (string s in strs)
            {
                string sortedTemp = String.Concat(s.OrderBy(x => x));

                if (!dict.ContainsKey(sortedTemp))
                {
                    dict.Add(sortedTemp, new List<string>());
                }

                dict[sortedTemp].Add(s);
            }

            foreach (var item in dict)
            {
                ans.Add(item.Value);
            }

            return ans;

        }

        public int[] TopKFrequent(int[] nums, int k)
        {
            var dic = new Dictionary<int, int>();
            var res = new int[k];
            foreach (var i in nums)
            {
                if (!dic.ContainsKey(i))
                {
                    dic.Add(i, 0);
                }

                dic[i]++;
            }

            int index = 0;
            foreach (var it in dic.OrderByDescending(key => key.Value))
            {
                res[index++] = it.Key;
                if (index == k) break;
            }

            return res;
        }

        public static int[] ProductExceptSelf(int[] nums)
        {
            var res = new int[nums.Length];

            res[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                res[i] = res[i - 1] * nums[i - 1];
            }

            int r = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                res[i] *= r;
                r *= nums[i];
            }

            return res;
        }

        public static int LongestConsecutive(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            Array.Sort(nums);
            int max = 0;
            int seq = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1] + 1)
                {
                    ++seq;
                    continue;
                }
                else if (nums[i] == nums[i - 1])
                {
                    continue;
                }

                max = seq > max ? seq : max;
                seq = 1;
            }

            max = seq > max ? seq : max;
            return max;
        }

        public static IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            for (int k = 0; k < nums.Length + 1; k++)
            {
                BacktrackSubsets(0, new List<int>(), nums, k, ref result);
            }

            return result;
        }

        public static void BacktrackSubsets(int first, List<int> curr, int[] nums, int k, ref List<IList<int>> result)
        {
            if (curr.Count == k)
            {
                result.Add(new List<int>(curr));
                return;
            }

            for (int i = first; i < nums.Length; i++)
            {
                curr.Add(nums[i]);

                BacktrackSubsets(i + 1, curr, nums, k, ref result);

                curr.RemoveAt(curr.Count - 1);
            }
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();

            if (nums.Length <= 2) return result;

            Array.Sort(nums);

            /*Here we declare 3 indexes. This is how it works. 
            -4 -2 -3 -1 0 0 0 2 3 10 21
             s  l                     r 
             
             s - start index, l - left index, r - right index */
            int start = 0, left, right;

            int target;

            /*The start goes from 0 to length-2 becuse look here
             -4 -2 -3 -1 0 0 0 2 3 10 21
                                 s  l  r      */
            while (start < nums.Length - 2)
            {
                target = nums[start] * -1;
                left = start + 1;
                right = nums.Length - 1;

                /*Now, the start index is fixed and we move the left and right indexes to find those two number
                which summed up will be the oposite of nums[s]  */
                while (left < right)
                {
                    /*The array is sorted, so if we move to the left the right index, the sum will decrese */
                    if (nums[left] + nums[right] > target)
                    {
                        --right;
                    }

                    /*Here is the oposite, it the sum of nums[l] and nums[r] is less that what we are looking for,
                    then we move the left index, which means that the sum will increase due to the sorted array.
                    the left index will jump to a bigger value */
                    else if (nums[left] + nums[right] < target)
                    {
                        ++left;
                    }
                    else
                    {
                        List<int> OneSolution = new List<int>() { nums[start], nums[left], nums[right] };
                        result.Add(OneSolution);

                        /*Now, in order to generate different solutions, we have to jump over
                        repetitive values in the array.  */
                        while (left < right && nums[left] == OneSolution[1])
                            ++left;
                        while (left < right && nums[right] == OneSolution[2])
                            --right;
                    }

                }

                /*Now we do the same thing to the start index. */
                int currentStartNumber = nums[start];
                while (start < nums.Length - 2 && nums[start] == currentStartNumber)
                    ++start;
            }

            return result;
        }


        private static PriorityQueue<int, int> pq;
        private static int maxCount = 0;

        public static void KthLargest(int k, int[] nums)
        {
            pq = new PriorityQueue<int, int>();
            maxCount = k;
            for (int i = 0; i < nums.Length; i++)
            {
                Add(nums[i]);
            }
        }

        public static int Add(int val)
        {
            if (pq.Count < maxCount)
            {
                pq.Enqueue(val, val);
            }
            else
            {
                if (pq.Peek() < val)
                {
                    pq.Dequeue();
                    pq.Enqueue(val, val);
                }
            }

            return pq.Peek();
        }

        public static int LastStoneWeight(int[] stones)
        {

            if (stones == null) return 0;
            if (stones.Length == 1) return stones[0];

            var pq = new PriorityQueue<int, int>();


            foreach (var i in stones)
            {
                pq.Enqueue(i, -i);
            }

            while (pq.Count > 0)
            {
                int diff = pq.Dequeue() - pq.Dequeue();

                var dic = new Dictionary<int, int>();


                pq.Enqueue(diff, -diff);

                if (pq.Count == 1)
                    return pq.Dequeue();
            }

            return 0;
        }

        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            var result = new List<IList<int>>();
            var combination = new List<int>();
            Dfs(0, 0);

            return result;

            void Dfs(int startIdx, int sum)
            {
                for (int i = startIdx; i < candidates.Length; i++)
                {
                    sum += candidates[i];
                    combination.Add(candidates[i]);
                    if (sum < target)
                    {
                        Dfs(i, sum);
                    }
                    else if (sum == target)
                    {
                        result.Add(new List<int>(combination));
                    }
                    else
                    {
                        combination.Remove(candidates[i]);
                        break; // to skip candidates that are also greater
                    }

                    combination.Remove(candidates[i]);
                    sum -= candidates[i];
                }
            }
        }

        public static string Tictactoe(int[][] moves)
        {
            char[,] board = new char[3, 3];
            string winner = "Pending";

            //Evaluate the moves
            for (int i = 0; i < moves.Length; i++)
            {
                char mark = i % 2 == 0 ? 'X' : 'O';
                board[moves[i][0], moves[i][1]] = mark;
            }

            //Check Diagonal
            if (board[0, 0] != '\0' && (board[0, 0].Equals(board[1, 1]) && board[1, 1].Equals(board[2, 2])) ||
                (board[0, 2].Equals(board[1, 1]) && board[1, 1].Equals(board[2, 0])))
            {
                winner = GetWinner(board[1, 1]);
            }

            //Evaluate the board
            for (int i = 0; i < 3; i++)
            {
                //Check across
                if (board[i, 0] != '\0' && board[i, 0].Equals(board[i, 1]) && board[i, 1].Equals(board[i, 2]))
                {
                    winner = GetWinner(board[i, 0]);
                }

                //Check down
                if (board[0, i] != '\0' && board[0, i].Equals(board[1, i]) && board[1, i].Equals(board[2, i]))
                {
                    winner = GetWinner(board[0, i]);
                }
            }

            return winner.Equals("Pending") && moves.Length == 9 ? "Draw" : winner;
        }

        private static string GetWinner(char val)
        {
            string winner = string.Empty;

            switch (val)
            {
                case 'X':
                    winner = "A";
                    break;
                case 'O':
                    winner = "B";
                    break;
                default:
                    winner = "Pending";
                    break;
            }

            return winner;
        }

        public static int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            var pq = new PriorityQueue<int[], int>();
            foreach (var arr in boxTypes)
            {
                pq.Enqueue(arr, -arr[1]);
            }

            int res = 0;
            int rest = truckSize;
            while (pq.Count != 0 && rest != 0)
            {
                int count = pq.Peek()[0];
                int unit = pq.Dequeue()[1];

                while (count > rest) --count;

                res += count * unit;
                rest -= count;
            }

            return res;
        }

        public static string IntToRoman(int num)
        {
            var nums = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 3, 2, 1 };
            var str = new string[]
                { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "III", "II", "I" };

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < nums.Length; ++i)
            {
                while (nums[i] <= num && num > 0)
                {
                    num -= nums[i];
                    result.Append(str[i]);
                }
            }

            return result.ToString();
        }

        public static int[][] MergeIntervals(int[][] intervals)
        {
            if (intervals.Length == 1) return intervals;
            Array.Sort(intervals, (a, b) => { return a[0] - b[0]; });
            List<int[]> res = new List<int[]>();

            foreach (var arr in intervals)
            {
                if (res.Count == 0)
                {
                    res.Add(arr);
                }
                else if ((res[^1][1] >= arr[0] && res[^1][0] <= arr[1]) || // [0 3] [1 3] or [1 3] [0 3]
                         (res[^1][0] <= arr[1] && res[^1][1] >= arr[0]))
                {
                    int start = Math.Min(res[^1][0], arr[0]);
                    int end = Math.Max(res[^1][1], arr[1]);
                    res[^1] = new int[] { start, end };
                }
                else
                {
                    res.Add(arr);
                }

            }

            return res.ToArray();
        }

        public static bool WordBreak(string s, IList<string> wordDict)
        {
            var wordset = new HashSet<string>(wordDict);

            var res = new bool[s.Length + 1];
            res[0] = true;

            for (int i = 1; i < s.Length; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    bool den = wordset.Contains(s.Substring(j, i - j));

                    if (res[j] && den)
                    {
                        res[i] = true;
                        break;
                    }
                }
            }

            return res[s.Length];
        }
        
        public static int NumIslands(char[][] grid)
        {
            int count = 0;

            for (int i = 0; i < grid.Length; i++)
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    count++;
                    NumIslandsHelper(grid, i, j);
                }
            }

            return count;
        }

        public static void NumIslandsHelper(char[][] grid, int i, int j)
        {
            if (i >= grid.Length || i < 0 ||
                j >= grid[i].Length || j < 0)
            {
                return;
            }

            if (grid[i][j] == '1')
            {
                grid[i][j] = '0';
                NumIslandsHelper(grid, i + 1, j);
                NumIslandsHelper(grid, i - 1, j);
                NumIslandsHelper(grid, i, j + 1);
                NumIslandsHelper(grid, i, j - 1);
            }
        }

        #endregion
    }
}
