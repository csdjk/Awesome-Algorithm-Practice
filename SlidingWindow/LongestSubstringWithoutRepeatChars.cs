using System;
using System.Collections.Generic;
//-----------------------------【无重复字符的最长子串】-----------------------------
public class LongestSubstringWithoutRepeatChars
{
    /**
    给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。

    示例 1:

    输入: "abcabcbb"
    输出: 3 
    解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
    **/
    public int LengthOfLongestSubstring(string s)
    {
        Dictionary<char, int> window = new Dictionary<char, int>();


        int right = 0;
        int left = 0;
        int res = 0;
        while (right < s.Length)
        {
            char c = s[right];
            right++;
            if (window.ContainsKey(c))
                window[c]++;
            else
                window.Add(c, 1);

            // 如果出现重复字符，移动left
            while (window[c] > 1)
            {
                window[s[left]]--;
                left++;
            }
            res = Math.Max(res, right - left);
        }
        return res;
    }


}