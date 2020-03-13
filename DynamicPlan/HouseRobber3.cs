using System.Collections.Generic;
using System;
//-----------------------------【打家劫舍3 - 中等】-----------------------------
public class HouseRobber3
{
    /**
    
    在上次打劫完一条街道之后和一圈房屋后，小偷又发现了一个新的可行窃的地区。这个地区只有一个入口，我们称之为“根”。 除了“根”之外，每栋房子有且只有一个“父“房子与之相连。一番侦察之后，聪明的小偷意识到“这个地方的所有房屋的排列类似于一棵二叉树”。 如果两个直接相连的房子在同一天晚上被打劫，房屋将自动报警。

    计算在不触动警报的情况下，小偷一晚能够盗取的最高金额。

    示例 1:

    输入: [3,2,3,null,3,null,1]

         3
        / \
       2   3
        \   \ 
         3   1

    输出: 7 
    解释: 小偷一晚能够盗取的最高金额 = 3 + 3 + 1 = 7.

    **/
    /**
    解题思路：

        这是一个树状的动态规划问题

        1.状态：把当前节点作为根，
        2.状态转移方程：
            选择不偷： 那么只能偷儿子节点了
            res1 = root.val + dfs(root.left.left) + dfs(root.left.right) + dfs(root.right.left) + dfs(root.right.right)

            选择偷：那么只能 偷孙子节点的 + 自身的
            res2 = dfs(root.left) + dfs(root.right)
        3.优化：
            用一个字典存储当前节点的最大利益，每次遍历时先判断是否计算过
    **/

    private Dictionary<TreeNode, int> dic = new Dictionary<TreeNode, int>();
    public int Rob(TreeNode root)
    {
        return dfs(root);
    }
    public int dfs(TreeNode root)
    {

        if (root == null) return 0;
        if (dic.ContainsKey(root))
            return dic[root];
        // 不偷当前节点：只能偷子节点
        int res1 = dfs(root.left) + dfs(root.right);
        // 偷当前节点：偷孙子节点的 + 自身的
        int res2 = 0;
        if (root.left != null)
            res2 += dfs(root.left.left) + dfs(root.left.right);
        if (root.right != null)
            res2 += dfs(root.right.left) + dfs(root.right.right);
        res2 += root.val;


        dic[root] = Math.Max(res1, res2);
        return dic[root];
    }

    //-----------------------------【方法二】-----------------------------

    /**
    解题思路：

        1.状态定义：
            我们使用一个大小为2的数组来表示 int[] res = new int[2] 0代表不偷，1代表偷。

            任何一个节点能偷到的最大钱的状态可以定义为:
                当前节点选择不偷: 当前节点能偷到的最大钱数 = 左孩子能偷到的最多钱 + 右孩子能偷到的最多钱
                当前节点选择偷: 当前节点能偷到的最大钱数 = 左孩子选择自己不偷时能得到的钱 + 右孩子选择不偷时能得到的钱 + 当前节点的钱数

        2.状态转移方程：
            root[0] = Math.max(dfs(root.left)[0], dfs(root.left)[1]) + Math.max(dfs(root.right)[0], dfs(root.right)[1])
            root[1] = dfs(root.left)[0] + dfs(root.right)[0] + root.val;
    **/
    public int Rob_O(TreeNode root)
    {
        int[] res = dfs_O(root);
        return  Math.Max(res[0],res[1]);
    }

    public int[] dfs_O(TreeNode root)
    {
        if (root == null) return new int[2];
        int[] result = new int[2];

        int[] left = dfs_O(root.left);
        int[] right = dfs_O(root.right);
        // 选择不偷  = 左孩子能偷到的最多钱 + 右孩子能偷到的最多钱
        result[0] = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);
        // 选择偷 = 左孩子选择自己不偷时能得到的钱 + 右孩子选择不偷时能得到的钱 + 当前节点的钱数
        result[1] = left[0] + right[0] + root.val;

        return result;
    }
}