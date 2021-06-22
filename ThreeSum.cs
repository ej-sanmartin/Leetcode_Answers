public class Solution {
    /*
        Brute Force: T - O(m*n^3), three nested for loops for nums, and m for iterating through
                                     result list to make sure all lists added to result are unique
                     S - O(1)
    */                     
    public IList<IList<int>> ThreeSum(int[] nums) {
        var result = new List<IList<int>>();
        
        for(int i = 0; i < nums.Length; i++){
            for(int j = i + 1; j < nums.Length; j++){
                for(int k = j + 1; k < nums.Length; k++){
                    if((nums[i] + nums[j] + nums[k]) == 0){
                        var newEntry = new List<int>{ nums[i], nums[j], nums[k] };
                        newEntry.Sort();
                        if (!result.Any(item => item.SequenceEqual(newEntry))) result.Add(newEntry);
                    }
                }
            }
        }
        
        return result;
    }

    /*
        Basic algorithm: sort array and loop through every item of the array.Length - 2.
        On each iteration, do two sum, two pointer algorithm (this could be put into its own function)
        The left and right pointer should equal to whatever is in nums[i], such that 0 - nums[i]
        Be sure to skip duplicates by incrementing low and decrementing high when low + 1 = low
        and high - 1 = high. This avoids duplicates because the sorted array makes duplicate numbers
        adjacent to each other.
        
        T - O(n^2), much better than brute force. Full time complexity would be O(nlogn + n^2) when
                    counting in sorting the array at the start but the lower multiplier is dropped
                    during analysis. Reason for quadratic time complexity because we are iterating
                    through the int array, such as n - 2. Then, on each iteration, do a two sum,
                    one pass, two pointer algorithm to find a pair that equals to 0. This is also
                    a linear operation. Linear in a linear operation creates O(n^2) time.
        S - O(1), not counting the IList<IList<int>> that we make to store the output,
                  we are only making int variables to keep track of low, high and sum for our
                  inner two sum algorithm
    */
    public IList<IList<int>> ThreeSum(int[] nums) {
        if(nums.Length < 3) return new List<IList<int>>();
        Array.Sort(nums);
        var result = new List<IList<int>>();
        int low, high, sum;
        
        for(int i = 0; i < nums.Length - 2; i++){
            if(i == 0 || (i > 0 && nums[i] != nums[i - 1])){
                low = i + 1;
                high = nums.Length - 1;
                sum = 0 - nums[i];
                
                // two sum, two pointer algorithm avoiding duplicates
                while(low < high){
                    if(nums[low] + nums[high] == sum){
                        result.Add(new List<int>{ nums[i], nums[low], nums[high] });
                        while(low < high && nums[low] == nums[low + 1]) low++;
                        while(low < high && nums[high] == nums[high - 1]) high--;
                        low++;
                        high--;
                    } else if(nums[low] + nums[high] > sum){
                        high--;
                    } else {
                        low++;
                    }
                }
            }
        }
        
        return result;
    }
}
