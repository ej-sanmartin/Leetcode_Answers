/*
    Given a string s, reverse the order of characters in each word within a sentence 
    while still preserving whitespace and initial word order.

    EXAMPLE
    Input: s = "Let's take LeetCode contest"
    Output: "s'teL ekat edoCteeL tsetnoc"

    T - O(n), we must go through every character in string to construct the reversed words
              in sentence string.
    S - O(n), we must use stringbuilder class to construct our string, which takes O(n) space
*/
public class Solution {
    public string ReverseWords(string s) {
        StringBuilder sb = new StringBuilder();
        int left, right, placeholder;
        left = right = 0;

        while(right <= s.Length){
            if(right == s.Length || s[right] == ' '){
                placeholder = right;
                right--;
                while(right >= left){
                    sb.Append(s[right--]);
                }
                if(placeholder != s.Length) sb.Append(' ');
                right = placeholder + 1;
                left = placeholder + 1;
            }
            right++;
        }
    
        return sb.ToString();
    }
}
