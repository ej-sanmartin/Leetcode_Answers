/*
    You are given a sorted unique integer array nums.

    Return the smallest sorted list of ranges that cover all the numbers in the 
    array exactly. That is, each element of nums is covered by exactly one of the 
    ranges, and there is no integer x such that x is in one of the ranges but not in 
    nums.

    Each range [a,b] in the list should be output as:

    "a->b" if a != b
    "a" if a == b

    T - O(n), as we are looping through the length of nums
    S - O(n), excluding the space created to make the output list of strings,
              we are only ever building up n number of strings for summary range 
              paths and then adding them to said list
*/
public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        if(nums.Length == 0) return new List<string>();
        if(nums.Length == 1) return new List<string>{ nums[0].ToString() };
        
        List<string> ranges = new List<string>();
        string range = nums[0].ToString();
        int subSize = 1;
        
        for(int i = 1; i < nums.Length; i++){
            if(nums[i] - 1 != nums[i - 1]){
                if(subSize > 1){
                    range += $"->{nums[i - 1]}";
                    ranges.Add(range);
                    range = String.Empty;
                    range += nums[i].ToString();
                } else {
                    ranges.Add(range);
                    range = String.Empty;
                    range += nums[i].ToString();
                }
                subSize = 1;
            } else {
                subSize++;
            }
            
            // handles when we get to the end
            if(i == nums.Length - 1){
                if(nums[i] - 1 == nums[i - 1]){
                    range += $"->{nums[i]}";
                    ranges.Add(range); 
                } else {
                    ranges.Add(nums[i].ToString());   
                }
            }
        }
        
        return ranges;
    }
}
