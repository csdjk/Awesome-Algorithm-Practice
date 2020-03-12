using System;

public class BinarySearchTree
{

    // 判断是否是 BST(二叉搜索树)
    public bool IsValidBST(TreeNode root) {
        return isValidBST(root, long.MinValue, long.MaxValue);
    }
    private bool isValidBST(TreeNode root, long minVal, long maxVal)
    {
        if(root == null) return true;

        if(root.val >= maxVal || root.val <= minVal) return false;

        return isValidBST(root.left, minVal, root.val) && isValidBST(root.right, root.val, maxVal);
    }


    // public bool IsValidBST(TreeNode root)
    // {
    //     if (root == null) return true;

    //     return IsValidBST(root.left, null, root.val) && IsValidBST(root.right, root.val, null);
    // }

    // private bool IsValidBST(TreeNode root, int? lb, int? ub)
    // {
    //     if (root == null) return true;

    //     if (lb.HasValue && root.val <= lb.Value) return false;
    //     if (ub.HasValue && root.val >= ub.Value) return false;

    //     return IsValidBST(root.left, lb, root.val) && IsValidBST(root.right, root.val, ub);
    // }
}