/*
    T - O(n), where n is the length of s that we must traverse through
    S - O(n), where we are creating a char array that is of length n, n being the size
              of the inputted string. The dictionary created will also hold n number of strings
              which is the worst case if every char in the string is unique. This would be, more
              accuractely O(n + n) then which is equivalent to O(2n). In complexity analysis we drop
              constants however, so space complexity would be O(n)
*/
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        char[] arr = s.ToCharArray();
        Dictionary<char, int> frequencyTable = new Dictionary<char, int>();
        int count = 0;
        int largestCount = 0;
        int startIndex = 0;
        
        foreach(char c in arr){
            if(!frequencyTable.ContainsKey(c)){
                frequencyTable.Add(c, 1);
            } else {
                frequencyTable[c]++;
            }
            
            count++;
            
            while(frequencyTable[c] > 1){
                frequencyTable[arr[startIndex]]--;
                if(frequencyTable[arr[startIndex]] == 0){
                    frequencyTable.Remove(arr[startIndex]);
                }
                startIndex++;
                count--;
            }
            
            largestCount = Math.Max(count, largestCount);
        }
        
        return largestCount;
    }
}
