using System.Collections.Generic;

public class MajorityElement
{
    public int GetMajorityElement(int[] nums)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        int countTag = nums.Length / 2;
        int item;
        for (int i = 0, len = nums.Length; i < len; i++)
        {
            item = nums[i];
            if (dic.ContainsKey(item))
                dic[item] += 1;
            else
                dic[item] = 1;
                
            if (dic[item] > countTag)
            {
                return item;
            }
        }
        return 0;
    }
}