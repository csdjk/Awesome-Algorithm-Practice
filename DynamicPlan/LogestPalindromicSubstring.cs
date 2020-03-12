
//-----------------------------【最长回文子串 - 中等】-----------------------------
public class LogestPalindromicSubstring
{
    /**
    给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。

    示例 1：

    输入: "babad"
    输出: "bab"
    注意: "aba" 也是一个有效答案。
    
    **/


    /**
    题解思路：   
    
    动态规划法

    假设 str = "abcdcba"
    
    二维数组 dp[i,j]   =>  i,j 分别代表子串起始和结尾索引 ，dp[i][j] : 代表从i到j的字符是否为回文子串（true）

    很明显我们可以发现， 判断一个子串 dp[i][j] 是否为回文，我们只需要知道 dp[i+1][j-1] 是否为回文即可，

    此时有两种情况：
    
        1.如果两边字符相等 即：str[i] == str[j]  
            那么我们只需要知道 dp[i+1][j-1] 是否为回文，如果是，那么dp[i][j]肯定也是回文，否则不是

        2.如果两边字符不相等 即：str[i] != str[j]   
            那么肯定不是回文
        
    由此可以推断出 状态转移方程
    
    如果 s[i] == s[j]  那么 dp[i,j] = dp[i+1][j-1] 
    否则 dp[i,j] = false


    **/
    public string LongestPalindrome(string s)
    {
        if (s.Length < 2)
        {
            return s;
        }

        bool[,] dp = new bool[s.Length, s.Length];
        int maxLen = 1;
        int startIndex = 0;
        int currentLen = 0;
       
        // 右边索引
        for (int right = 1, len = s.Length; right < len; right++)
        {
            // 左边索引
            for (int left = 0; left < right; left++)
            {
                // 左右两边字符相等
                if (s[left] == s[right])
                {
                    // 如果距离小于3 那么肯定是回文
                    if (right - left < 3)
                    {
                        dp[left, right] = true;
                    }
                    else 
                    {
                        dp[left, right] = dp[left + 1, right - 1];
                    }
                }
                // 如果是回文 记录下起始位置和长度
                if (dp[left, right])
                {
                    currentLen = right - left + 1;
                    if (currentLen > maxLen)
                    {
                        maxLen = currentLen;
                        startIndex = left;
                    }
                }
            }
        }
        return s.Substring(startIndex, maxLen);
    }
}