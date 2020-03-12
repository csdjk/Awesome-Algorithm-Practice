//-----------------------------【二叉树的直径 - 简单】-----------------------------
using System;

public class DiameterOfBinaryTree
{

    /**给定一棵二叉树，你需要计算它的直径长度。一棵二叉树的直径长度是任意两个结点路径长度中的最大值。这条路径可能穿过根结点。

    示例 :
    给定二叉树
             1
            / \
           2   3
          / \     
         4   5    

    返回 3, 它的长度是路径 [4,2,1,3] 或者 [5,2,1,3]。

    **/

    // 二叉树的直径不一定过根节点，因此需要去搜一遍所有子树(例如以root，root.left, root.right...为根节点的树)对应的直径，取最大值。
    // root的直径 = root左子树高度 + root右子树高度
    // root的高度 = max {root左子树高度, root右子树高度} + 1

    int max = 0;
    public int GetDiameterOfBinaryTree(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        dfs(root);
        return max;
    }

    public int dfs(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        int left = dfs(root.left); //左子树高度
        int right = dfs(root.right); //右子树高度

        max = Math.Max(max, left + right);  //root的直径

        return Math.Max(right, left) + 1;
    }
}