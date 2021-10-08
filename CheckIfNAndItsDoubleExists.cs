/*
    Given an array arr of integers, check if there exists two integers N and M such that N is the 
    double of M ( i.e. N = 2 * M).

    More formally check if there exists two indices i and j such that :

    T - O(n), we go through element in array once
    S - O(n), hashset will contain all elements in input array
*/
public class Solution {
    public bool CheckIfExist(int[] arr) {
        if (arr == null || arr.Length == 0) {
            return false;
        }
        
        HashSet<int> seen = new HashSet<int>();
        
        foreach (int num in arr) {
            if (num % 2 == 0 && seen.Contains(num / 2)) {
                return true;
            }
            if (seen.Contains(num * 2)) {
                return true;
            }
            seen.Add(num);
        }
        
        return false;
    }
}
