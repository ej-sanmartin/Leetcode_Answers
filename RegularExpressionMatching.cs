/*
    Given an input string s and a pattern p, implement regular expression matching with support for 
    '.' and '*' where:

    '.' Matches any single character.
    '*' Matches zero or more of the preceding element.

    The matching should cover the entire input string (not partial).  
    
    T - O(nm), memo bounds and optimizes our time complexity to nm as we solve nm sub solutions to get 
               the globally optimal solution when we arrive at our final solution at cell n (n being 
               word size) and m (being pattern size)
    S - O(nm), memo is size of array that holds n (being word size) times m (m being pattern size)
*/
public class Solution {
    public bool IsMatch(string s, string p) {
        bool?[,] memo = new bool?[s.Length + 1, p.Length + 1];
        return Search(s, p, 0, 0, memo);
    }
    
    public bool Search(string s, string p, int indexOne, int indexTwo, bool?[,] memo){ 
        if(memo[indexOne, indexTwo] != null){
            return (bool)memo[indexOne, indexTwo];
        }
        
        bool answer = false;
        if(indexTwo >= p.Length){
            answer = indexOne >= s.Length;   
        } else {
            bool match = (indexOne < s.Length && (s[indexOne] == p[indexTwo] || p[indexTwo] == '.'));
            if(indexTwo + 1 < p.Length && p[indexTwo + 1] == '*'){
                bool skipWildCard = Search(s, p, indexOne, indexTwo + 2, memo);
                bool wildCardMatch = (match && Search(s, p, indexOne + 1, indexTwo, memo));
                answer = skipWildCard || wildCardMatch;
            } else {
                if(match){
                    answer = Search(s, p, indexOne + 1, indexTwo + 1, memo);
                } else { 
                    answer = false;
                }
            }
        }                        
        memo[indexOne, indexTwo] = answer;                           
        return (bool)answer;
    }
}
