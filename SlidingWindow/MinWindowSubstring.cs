using System;
using System.Collections.Generic;
//-----------------------------【最小覆盖子串】-----------------------------
public class MinWindowSubstring
{
    /**
    给你一个字符串 S、一个字符串 T，请在字符串 S 里面找出：包含 T 所有字母的最小子串。

    示例：
    输入: S = "ADOBECODEBANC", T = "ABC"
    输出: "BANC"

    说明：
        如果 S 中不存这样的子串，则返回空字符串 ""。
        如果 S 中存在这样的子串，我们保证它是唯一的答案。
    **/
    public string MinWindow(string s, string t)
    {
        int left = 0, right = 0;
        string res = s;
        Dictionary<char, int> window = new Dictionary<char, int>();
        Dictionary<char, int> needs = new Dictionary<char, int>();

        // 初始化needs
        for (int i = 0, len = t.Length; i < len; i++)
        {
            if (needs.ContainsKey(t[i]))
                needs[t[i]]++;
            else
                needs.Add(t[i], 1);
        }

        // 初始化window
        for (int i = 0, len = s.Length; i < len; i++)
        {
            if (!window.ContainsKey(s[i]))
                window.Add(s[i], 0);
        }

        int startIndex = 0;
        int MaxLen = s.Length + 1;
        int minLen = MaxLen;
        // 记录 window 中已经有多少字符符合要求了
        int match = 0;

        // 开始移动right - 展开窗口
        while (right < s.Length)
        {

            char c1 = s[right];
            if (needs.ContainsKey(c1))
            {
                window[c1]++;
                if (window[c1] == needs[c1])
                    // 字符 c1 的出现次数符合要求了
                    match++;
            }

            right++;
            // 如果符合要求，移动 left 缩小窗口
            while (match == needs.Count)
            {
                // 如果这个窗口的子串更短，则更新 res, 记录最小长度和起始索引
                if (right - left < minLen)
                {
                    minLen = right - left;
                    startIndex = left;
                }

                char c2 = s[left];
                if (needs.ContainsKey(c2))
                {
                    window[c2]--;
                    // 如果缩小到不符合要求了，就停止移动left，开始继续移动right
                    if (window[c2] < needs[c2])
                        match--;
                }

                left++;
            }
        }
        return minLen == MaxLen ? "" : s.Substring(startIndex,minLen);
    }



}