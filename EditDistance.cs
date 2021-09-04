/*
    Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.

    You have the following three operations permitted on a word:

    Insert a character
    Delete a character
    Replace a character

    T - O(nm), with memo or dp table, time optimized to nm where n is size of first string and m is size of second 
               string. We store all the sub solutions so that when we need to compute overlapping sub problems, we 
               can retrieve these solutions in constant time
    S - O(nm), memo or dp table holds nm sub solutions that are all the unique sub solutions that can be solved
*/
public class Solution {
    // top down solution
    public int MinDistance(string word1, string word2) {
        if((word1.Length == 0 || word1 == null) && (word2.Length == 0 || word2 == null)){
            return 0;
        }
        
        if(word1 == null || word1.Length == 0){
            return word2.Length;
        }
        
        if(word2 == null || word2.Length == 0){
            return word1.Length;
        }
        
        int?[,] memo = new int?[word1.Length + 1, word2.Length + 1];
        return Edits(word1, word2, 0, 0, memo);
    }
    
    public int Edits(string s1, string s2, int indexOne, int indexTwo, int?[,] memo){
        if(indexOne >= s1.Length){
            return s2.Length - indexTwo;
        }
        
        if(indexTwo >= s2.Length){
            return s1.Length - indexOne;
        }
        
        if(memo[indexOne, indexTwo] == null){
            if(s1[indexOne] == s2[indexTwo]){
                memo[indexOne, indexTwo] = Edits(s1, s2, indexOne + 1, indexTwo + 1, memo);
            } else {
                int countOne = 1 + Edits(s1, s2, indexOne + 1, indexTwo + 1, memo);
                int countTwo = 1 + Edits(s1, s2, indexOne, indexTwo + 1, memo);
                int countThree = 1 + Edits(s1, s2, indexOne + 1, indexTwo, memo);
                return Math.Min(Math.Min(countOne, countTwo), countThree);
            }   
        }
        
        return (int)memo[indexOne, indexTwo];
    }

    // Bottom up solution    
    public int MinDistance(string word1, string word2){
        if((word1.Length == 0 || word1 == null) && (word2.Length == 0 || word2 == null)){
            return 0;
        }
        
        if(word1 == null || word1.Length == 0){
            return word2.Length;
        }
        
        if(word2 == null || word2.Length == 0){
            return word1.Length;
        }
        
        int[,] table = new int[word1.Length + 1, word2.Length + 1];
        
        for(int i = 0; i <= word2.Length; i++){
            table[0, i] = i;
        }
            
        for(int i = 0; i <= word1.Length; i++){
            table[i, 0] = i;
        }
        
        for(int i = 1; i <= word1.Length; i++){
            for(int j = 1; j <= word2.Length; j++){
                if(word1[i - 1] == word2[j - 1]){
                    table[i, j] = table[i - 1, j - 1];
                } else {
                    table[i, j] = 1 + Math.Min(Math.Min(table[i - 1, j - 1], table[i - 1, j]), table[i, j - 1]);
                }
            }
        }
        
        return table[word1.Length, word2.Length];
    }
}
