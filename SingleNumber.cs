/*
  Given a non-empty array of integers, every element appears twice except for one. Find that single one.
*/

public class Solution {
    public int SingleNumber(int[] nums) {
        int answer = 0;
        Dictionary<int, int> trackedNumber = new Dictionary<int, int>();
        
        foreach(int num in nums){
            if(trackedNumber.ContainsKey(num)){
                trackedNumber[num]++;
                continue;
            } else {
              trackedNumber.Add(num, 1);  
            }
        }
        
        answer = trackedNumber.FirstOrDefault(x => x.Value == 1).Key;
        return answer;
    }
}
