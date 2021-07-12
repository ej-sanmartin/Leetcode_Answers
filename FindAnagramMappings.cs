/*
    You are given two integer arrays nums1 and nums2 where nums2 is an anagram of 
    nums1. Both arrays may contain duplicates.

    Return an index mapping array mapping from nums1 to nums2 where mapping[i] = j 
    means the ith element in nums1 appears in nums2 at index j. If there are multiple 
    answers, return any of them.

    An array a is an anagram of an array b means b is made by randomizing the order 
    of the elements in a.

    T - O(n), as we must loop though what is essentially the same array but slightly 
              modified, twice (O(2n)). We drop constants and get linear time
    S - O(n), where n is the size of the mappings between num1 and num 2
*/
public class Solution {
    public int[] AnagramMappings(int[] nums1, int[] nums2) {
        Dictionary<int, Stack<int>> mappings = new Dictionary<int, Stack<int>>();
        for(int i = 0; i < nums2.Length; i++){
            if(!mappings.ContainsKey(nums2[i])){
                mappings.Add(nums2[i], new Stack<int>());   
            }
            mappings[nums2[i]].Push(i);
        }
        
        int[] result = new int[nums1.Length];
        for(int i = 0; i < nums1.Length; i++){
            result[i] = mappings[nums1[i]].Pop();
            if(mappings[nums1[i]].Count == 0) mappings.Remove(nums1[i]); // cleanup
        }
        
        return result;
    }
}
