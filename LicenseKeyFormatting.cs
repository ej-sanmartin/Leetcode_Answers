/*
  T - O(n^2) traversing through mutatedString and inserting to sb dashes which is O(n) to shift up all elements to make room
  S - O(n) creating a new string of size n - dashes + inserting a random amount of dashes equal to s.Length / k
*/

public class Solution {
    public string LicenseKeyFormatting(string s, int k) {
        int count = k;
        string mutatedString = s.Replace("-", "").ToUpper();
        StringBuilder sb = new StringBuilder(mutatedString);
        
        for(int i = sb.Length - 1; i >= 1; i--){
            count--;
            
            if(count == 0){
                sb.Insert(i, '-');
                count = k;
            }
        }
        
        return sb.ToString();
    }
}
