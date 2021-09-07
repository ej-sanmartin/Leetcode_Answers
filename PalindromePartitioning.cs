/*
    Given a string s, partition s such that every substring of the partition is a palindrome. Return all 
    possible palindrome partitioning of s.

    A palindrome string is a string that reads the same backward as forward.

    T - O(N * 2^N), N being the size of the input string. We are going through all permutations and only 
                    adding the valid permuations to our output, that output being all palindrome substrings
    S - O(N * N),   As we have an N * N memo to speed up our algorithm
*/
public class Solution {
    public IList<IList<string>> Partition(string s) {
        int l = s.Length;
        bool[,] memo = new bool[l, l];
        var output = new List<IList<string>>();
        DFS(s, 0, new List<string>(), output, memo);
        return output;
    }
    
    public void DFS(string s, int start, List<string> current, List<IList<string>> list, bool[,] memo){
        if(start >= s.Length){
            list.Add(new List<string>(current));
        }
        for(int end = start; end < s.Length; end++){
            if(s[start] == s[end] && (end - start <= 2 || memo[start + 1, end - 1])){
                memo[start, end] = true;
                current.Add(s.Substring(start, end - start + 1));
                DFS(s, end + 1, current, list, memo);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
