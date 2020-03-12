using System.Collections.Generic;
public class FindAllAnagramsString
{
    /**
    给定一个字符串 s 和一个非空字符串 p，找到 s 中所有是 p 的字母异位词的子串，返回这些子串的起始索引。

    字符串只包含小写英文字母，并且字符串 s 和 p 的长度都不超过 20100。

    说明：

    字母异位词指字母相同，但排列不同的字符串。
    不考虑答案输出的顺序。

    输入:
        s: "cbaebabacd" p: "abc"
    输出:
        [0, 6]

    解释:
        起始索引等于 0 的子串是 "cba", 它是 "abc" 的字母异位词。
        起始索引等于 6 的子串是 "bac", 它是 "abc" 的字母异位词。

    **/
    public IList<int> FindAnagrams(string s, string p)
    {
        int right = 0, left = 0;
        Dictionary<char, int> window = new Dictionary<char, int>();
        Dictionary<char, int> needs = new Dictionary<char, int>();

        IList<int> res = new List<int>();

        // 初始化needs
        for (int i = 0, len = p.Length; i < len; i++)
        {
            char c = p[i];
            needs[c] = needs.GetValueOrDefault(c) + 1;
        }

        // 记录 window 中已经有多少字符符合要求了
        int count = 0;

        // 开始移动right - 展开窗口
        while (right < s.Length)
        {

            char c1 = s[right];
            if (needs.ContainsKey(c1))
            {
                if (window.ContainsKey(c1))
                    window[c1]++;
                else
                    window.Add(c1, 1);
                // 如果c1字符出现的次数符合要求了
                if (window[c1] == needs[c1])
                {
                    count++;
                }
            }
            right++;
            // 如果符合要求，移动 left 缩小窗口
            while (count == needs.Count)
            {
                // 如果 window 的大小合适
                // 就把起始索引 left 加入结果
                if (right - left == p.Length)
                {
                    res.Add(left);
                }
                char c2 = s[left];
                if (needs.ContainsKey(c2))
                {
                    window[c2]--;
                    if (window[c2] < needs[c2])
                        count--;
                }
                left++;
            }
        }

        return res;
    }


}