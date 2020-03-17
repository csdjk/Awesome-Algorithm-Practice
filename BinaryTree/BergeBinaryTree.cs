//-----------------------------【合并二叉树 - 简单】-----------------------------
public class BergeBinaryTree
{
    public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
    {
        if (t1 == null)
            return t2;
        if (t2 == null)
            return t1;
        t1.val += t2.val;
        t1.left = MergeTrees(t1.left, t2.left);
        t1.right = MergeTrees(t1.right, t2.right);
        return t1;
    }
}