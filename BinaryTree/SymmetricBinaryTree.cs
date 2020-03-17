
using System.Collections.Generic;
//-----------------------------【对称二叉树】-----------------------------
public class SymmetricBinaryTree
{
    /**
    给定一个二叉树，检查它是否是镜像对称的。

    例如，二叉树 [1,2,2,3,4,4,3] 是对称的。

        1
       / \
      2   2
     / \ / \
    3  4 4  3

    但是下面这个 [1,2,2,null,3,null,3] 则不是镜像对称的:

        1
       / \
      2   2
       \   \
       3    3

    **/

    /**
    
        解题：

        如果一个树的左子树与右子树镜像对称，那么这个树是对称的。
        因此，该问题可以转化为：两个树在什么情况下互为镜像？

        如果同时满足下面的条件，两个树互为镜像：

            1.它们的两个根结点具有相同的值。
            2.每个树的右子树都与另一个树的左子树镜像对称。
    
    **/
    public bool IsSymmetric(TreeNode root)
    {
        return IsMirror(root, root);
    }

    public bool IsMirror(TreeNode root1, TreeNode root2)
    {
        if (root1 == null && root2 == null) return true;
        if (root1 == null || root2 == null) return false;

        return (root1.val == root2.val)
        && IsMirror(root1.left, root2.right)
        && IsMirror(root1.right, root2.left);
    }

    // 迭代
    public bool isSymmetric_O(TreeNode root)
    {
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        q.Enqueue(root);
        while (q.Count != 0)
        {
            TreeNode t1 = q.Dequeue();
            TreeNode t2 = q.Dequeue();
            if (t1 == null && t2 == null) continue;
            if (t1 == null || t2 == null) return false;
            if (t1.val != t2.val) return false;
            q.Enqueue(t1.left);
            q.Enqueue(t2.right);
            q.Enqueue(t1.right);
            q.Enqueue(t2.left);
        }
        return true;
    }
}