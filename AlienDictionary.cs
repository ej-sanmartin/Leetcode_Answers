/*
    Note: n is number of strings in input list, c is length of all chars in all words, and U is
          number of unqiue letters in alien alphabet
    T - O(c), looping through all chars in all the words is our most expensive operation in algo
    S - O(1), since english alphabet only has 26 chars in it thus our dictionaries are bounded
              by 26. However, to create dictionaries when the number of unique char in alphabet
              are not known would be of size O(U + min(U^2, N)). 
*/
public class Solution {
    public string AlienOrder(string[] words) {
        Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();
        Dictionary<char, int> inDegrees = new Dictionary<char, int>();
        foreach(string word in words){
            foreach(char c in word.ToCharArray()){
                inDegrees[c] = 0;
                graph[c] = new List<char>();
            }
        }
        
        for(int i = 0; i < words.Length - 1; i++){
            string firstWord = words[i];
            string secondWord = words[i + 1];
            if(firstWord.Length > secondWord.Length && firstWord.StartsWith(secondWord)){
                return "";
            }
            for(int j = 0; j < Math.Min(firstWord.Length, secondWord.Length); j++){
                if(firstWord[j] != secondWord[j]){
                    graph[firstWord[j]].Add(secondWord[j]);
                    inDegrees[secondWord[j]]++;
                    break;
                }
            }
        }
        
        string alienAlphabet = "";
        Queue<char> q = new Queue<char>();
        foreach(char c in inDegrees.Keys){
            if(inDegrees[c] == 0){
                q.Enqueue(c);
            }
        }
        
        while(q.Count != 0){
            char c = q.Dequeue();
            alienAlphabet += c.ToString();
            foreach(char next in graph[c]){
                inDegrees[next]--;
                if(inDegrees[next] == 0){
                    q.Enqueue(next);
                }
            }
        }
        
        if(alienAlphabet.Length < inDegrees.Count) return "";
        return alienAlphabet;
    }
}
