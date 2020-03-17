using System;
//-----------------------------【最大二叉树】-----------------------------
public class MaxBrinaryTree
{
    /**
    给定一个不含重复元素的整数数组。一个以此数组构建的最大二叉树定义如下：

    二叉树的根是数组中的最大元素。
    左子树是通过数组中最大值左边部分构造出的最大二叉树。
    右子树是通过数组中最大值右边部分构造出的最大二叉树。
    通过给定的数组构建最大二叉树，并且输出这个树的根节点。

 

    示例 ：

    输入：[3,2,1,6,0,5]
    输出：返回下面这棵树的根节点：

      6
    /   \
   3     5
    \    / 
     2  0   
       \
        1

    
    **/
    public TreeNode ConstructMaximumBinaryTree(int[] nums)
    {
        // 边界
        if (nums.Length == 1)
            return new TreeNode(nums[0]);
        if (nums.Length == 0)
            return null;


        TreeNode newNode;

        int maxIndex = 0;
        for (int i = 0, len = nums.Length; i < len; i++)
        {
            if (nums[i] > nums[maxIndex])
            {
                maxIndex = i;
            }
        }
        // 分割数组
        int lenRight = nums.Length - maxIndex - 1;
        int[] arrLeft = new int[maxIndex];
        int[] arrRight = new int[lenRight];

        Array.Copy(nums, 0, arrLeft, 0, maxIndex);
        Array.Copy(nums, maxIndex + 1, arrRight, 0, lenRight);

        newNode = new TreeNode(nums[maxIndex]);
        newNode.left = ConstructMaximumBinaryTree(arrLeft);
        newNode.right = ConstructMaximumBinaryTree(arrRight);
        return newNode;
    }

    //-----------------------------【优化】-----------------------------
    public TreeNode ConstructMaximumBinaryTree_O(int[] nums)
    {
        return helper(nums, 0, nums.Length);
    }

    public TreeNode helper(int[] nums, int start, int end)
    {
        // 边界
        if (start >= end)
            return null;

        int maxIndex = start;
        for (int i = start + 1; i < end; i++)
        {
            if (nums[i] > nums[maxIndex])
            {
                maxIndex = i;
            }
        }

        TreeNode newNode = new TreeNode(nums[maxIndex]);
        newNode.left = helper(nums, start, maxIndex);
        newNode.right = helper(nums, maxIndex + 1, end);
        return newNode;
    }

}