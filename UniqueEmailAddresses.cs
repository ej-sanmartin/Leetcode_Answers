/* 
    T - O(n * m -> n^2 * m), we have to iterate through every email in emails list 
                             which is represented by n
    Substring within the outer foreach can degrade time further to n^2.
    and m represents iterating through every char per each email until we reach '@'
    S - O(w) where w is every unique email in a set
*/

public class Solution {
    public int NumUniqueEmails(string[] emails) {
        HashSet<string> uniqueEmails = new HashSet<string>();
        
        foreach(string email in emails){ // O(n)
            StringBuilder sb = new StringBuilder();
            
            foreach(char c in email.ToCharArray()){ // O(m)
                if(c == '.') continue;
                if(c == '+') break;
                if(c == '@') break;
                sb.Append(c);
            }

            string current = (sb.ToString() + email.Substring(email.IndexOf('@'))).ToLower(); // O(n)
            uniqueEmails.Add(current);
        }
        
        return uniqueEmails.Count; // O(1);
    }
}
