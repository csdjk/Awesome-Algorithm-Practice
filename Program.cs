using System;
using System.Collections.Generic;
using System.Text;
using AlgorithmPractice.DynamicPlan;

namespace AlgorithmPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //-----------------------------【全排列】-----------------------------
            // Permutations permut = new Permutations();
            // IList<IList<int>> res = permut.permute(new int[]{1,2,3});

            //-----------------------------【二分查找】-----------------------------
            // BinarySearch binarySearch = new BinarySearch();
            // int res1 = binarySearch.binary_search(new int[]{1,2,3,5,5,5,7,8,9,10},5);
            // int res2 = binarySearch.right_bound(new int[]{1,2,3,5,5,5,7,8,9,10},5);
            // int res3 = binarySearch.left_bound(new int[]{1,2,3,5,5,5,7,8,9,10},5);


            //-----------------------------【最小覆盖字符串】-----------------------------
            // MinWindowSubstring win = new MinWindowSubstring();
            // string res = win.MinWindow("DBBACANX", "ABC");
            // Console.WriteLine("Hello World!");


            //-----------------------------【无重复字符的最长子串】-----------------------------
            // LongestSubstringWithoutRepeatChars lswrc = new LongestSubstringWithoutRepeatChars();
            // int res1 = lswrc.LengthOfLongestSubstring("abcabcbb");
            // Console.WriteLine("Hello World!");


            //-----------------------------【无重复字符的最长子串】-----------------------------
            // FindAllAnagramsString faas = new FindAllAnagramsString();
            // IList<int> res1 = faas.FindAnagrams("abab", "ab");


            //-----------------------------【优先级队列】-----------------------------
            // PriorityQueue priorityQueue = new PriorityQueue();
            // priorityQueue.enQueue(3);
            // priorityQueue.enQueue(5);
            // priorityQueue.enQueue(10);
            // priorityQueue.enQueue(2);
            // priorityQueue.enQueue(7);
            // Console.WriteLine("出队元素：" + priorityQueue.deQueue());
            // Console.WriteLine("出队元素：" + priorityQueue.deQueue());


            //-----------------------------【判断二叉搜索树】-----------------------------
            // TreeNode rootNode = new TreeNode() { val = 2 };
            // TreeNode leftNode = new TreeNode() { val = 1 };
            // TreeNode rightNoed = new TreeNode() { val = 3 };
            // rootNode.left = leftNode;
            // rootNode.right = rightNoed;
            // BinarySearchTree binarySearchTree = new BinarySearchTree();
            // bool isBST = binarySearchTree.IsValidBST(rootNode);


            //-----------------------------【动态规划类 - start】-----------------------------


            //-----------------------------【最长递增子序列的个数】-----------------------------
            // NumberOfLTS findNumberOfLTS = new NumberOfLTS();
            // int res = findNumberOfLTS.FindNumberOfLIS(new int[] { 1, 3, 6, 7, 9, 4, 10, 5, 6 });

            //-----------------------------【最长公共子序列】-----------------------------
            // LongestCommonSubsequence lcs = new LongestCommonSubsequence();
            // int res = lcs.GetLongestCommonSubsequence("abcde","ace");


            //-----------------------------【最长回文子串】-----------------------------
            // LogestPalindromicSubstring lps = new LogestPalindromicSubstring();
            // string res = lps.LongestPalindrome("ac");

            //-----------------------------【最长回文子序列】-----------------------------
            LogestPalindromicSubseq lps = new LogestPalindromicSubseq();
            int res = lps.LongestPalindromeSubseq("cbbd");

            //-----------------------------【扔鸡蛋】-----------------------------
            // EggDrop eggDrop = new EggDrop();
            // int res = eggDrop.superEggDrop(2,6);



            //-----------------------------【动态规划类 - end】-----------------------------


            Console.WriteLine("Hello World!");
        }
    }
}
