/*
    Given two integer arrays nums1 and nums2, return an array of their intersection.
    Each element in the result must appear as many times as it shows in both arrays
    and you may return the result in any order.
    
    Taught me the neat trick of reversing order of inputed arrays as seen in line 19
    
    T - O(n + m),       must traverse through both arrays fully at worst case. Traverse through
                        n elements in nums1 to populate frequencyTable, and traverse through at 
                        worst all elements in nums2 to find intersect
    S - O(min(n, m)),   as size of frequency table will be the size of the unique elements
                        the smallest length array. Without line 19, S - O(n) as we only will
                        populate frequency table with elements in first array, nums1
*/
public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        // can optimize space by switching arrays in method call as
        // frequencyTable's size is dependent on size of unique elements in an array.
        if(nums1.Length > nums2.Length) return Intersect(nums2, nums1);
        
        List<int> intersection = new List<int>();
        Dictionary<int, int> frequencyTable = new Dictionary<int, int>();
        
        for(int i = 0; i < nums1.Length; i++){
            if(frequencyTable.ContainsKey(nums1[i])){
                frequencyTable[nums1[i]]++;
            } else {
                frequencyTable.Add(nums1[i], 1);
            }
        }
        
        // can speed up by also exiting for loop when frequencyTable is empty
        for(int i = 0; i < nums2.Length && frequencyTable.Count != 0; i++){
            if(frequencyTable.ContainsKey(nums2[i])){
                intersection.Add(nums2[i]);
                frequencyTable[nums2[i]]--;
                if(frequencyTable[nums2[i]] == 0){
                    frequencyTable.Remove(nums2[i]);
                }
            }
        }
        
        return intersection.ToArray();
    }
}
