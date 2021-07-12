/*
    Given two string arrays word1 and word2, return true if the two arrays represent the same 
    string, and false otherwise.

    A string is represented by an array if the array elements concatenated in order forms the 
    string.
*/
public class Solution {
    /*
        T - O(n + m), must traverse through both string arrays to create word
        S - O(n + m), as we are, at worst, creating two different words
    */
    public bool ArrayStringsAreEqual(string[] word1, string[] word2) {
        string firstWord = "";
        foreach(string word in word1){
            firstWord += word;
        }
        
        string secondWord = "";
        foreach(string word in word2){
            secondWord += word;
        }
        
        return firstWord.Equals(secondWord);
    }
    
    /*
        T - O(min(n, m)), as we will break from while loop once smallest of two string arrays are
                          completed. For true statements, this would then just be linear time
        S - O(1), as we are only creating pointers and counts to keep track of traversing arrays
    */
    public bool ArrayStringsAreEqual(string[] word1, string[] word2) {
        int word1Pointer, word1Count, word2Pointer, word2Count;
        word1Pointer = word1Count = word2Pointer = word2Count = 0;
        
        while(word1Count < word1.Length && word2Count < word2.Length){
            if(word1[word1Count][word1Pointer] != word2[word2Count][word2Pointer]) return false;
                                                                      
            if(word1Pointer >= word1[word1Count].Length - 1){
                word1Pointer = 0;
                word1Count++;
            } else {
                word1Pointer++;
            }
            
            if(word2Pointer >= word2[word2Count].Length - 1){
                word2Pointer = 0;
                word2Count++;
            } else {
                word2Pointer++;
            }
        }
        
        return (word1.Length == word1Count) && (word2.Length == word2Count);
    }
}
