using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System;

//-----------------------------【全排列】-----------------------------
class Permutations
{
    public IList<IList<int>> res = new List<IList<int>>();

    public int len = 0;
    /* 主函数，输入一组不重复的数字，返回它们的全排列 */
    public IList<IList<int>> permute(int[] nums)
    {
        len = nums.Length;
        // 记录「路径」
        IList<int> track = new List<int>();
        backtrack(nums, track);
        return res;
    }

    // 路径：记录在 track 中
    // 选择列表：nums 中不存在于 track 的那些元素
    // 结束条件：nums 中的元素全都在 track 中出现
    public void backtrack(int[] nums, IList<int> track)
    {
        // 触发结束条件
        if (track.Count == len)
        {
            // res.Add(new IList<int>(track));
              res.Add(new List<int>(track));
            return;
        }

        for (int i = 0; i < len; i++)
        {
            // 排除不合法的选择
            if (track.Contains(nums[i]))
                continue;
            // 做选择
            track.Add(nums[i]);
            // 进入下一层决策树
            backtrack(nums, track);
            // 取消选择
            track.Remove(track[track.Count-1]);
        }
    }
}
