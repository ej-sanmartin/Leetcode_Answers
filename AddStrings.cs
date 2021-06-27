/*
    Given two non-negative integers, num1 and num2 represented as string, return the sum of num1 and num2 as a 
    string.

    You must solve the problem without using any built-in library for handling large integers (such as BigInteger). 
    You must also not convert the inputs to integers directly.

    T - O(max(n, m)), where we have to traverse through the length of lonest string to add the smaller string to it
    S - O(max(n, m)), where the newly created string that is the sum of the two strings as ints + 1 if there is a 
                      remainder
*/
public class Solution {
    public string AddStrings(string num1, string num2) {
        if(num1.Length < num2.Length) return AddStrings(num2, num1);
        
        string result = "";
        string newNum2 = PreprocessedString(num2, num1.Length - num2.Length);
        
        int current = 0;
        int remainder = 0;
        
        for(int i = num1.Length - 1; i >= 0; i--){
            current = int.Parse(num1[i].ToString()) + int.Parse(newNum2[i].ToString());
            result += ((current + remainder) % 10);
            remainder = (current + remainder) / 10;
        }
        
        if(remainder > 0){
            result += int.Parse(remainder.ToString());
        }
        
        char[] answer = result.ToCharArray();
        Array.Reverse(answer);
        return new string(answer);
    }
    
    private string PreprocessedString(string s, int zeroes){
        List<char> newString = new List<char>();
        
        for(int i = 0; i < zeroes; i++){
            newString.Add('0');
        }
        
        for(int i = 0; i < s.Length; i++){
            newString.Add(s[i]);
        }
        
        return string.Join("", newString);
    }
}
