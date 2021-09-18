/*
    Given an integer n, return the least number of perfect square numbers that sum to n.

    A perfect square is an integer that is the square of an integer; in other words, it 
    is the product of some integer with itself. For example, 1, 4, 9, and 16 are perfect 
    squares while 3 and 11 are not.

    T - O(n^h/2), time complexity to traverse n-ary tree
    S - O(sqrt(n)^h), hashset q is main space waster here
*/
public class Solution {
    public int NumSquares(int n) {
        List<int> squaredNums = new List<int>();
        for(int i = 1; i * i <= n; i++){
            squaredNums.Add(i * i);
        }
        
        HashSet<int> q = new HashSet<int>();
        q.Add(n);
        int level = 0; 
        while(q.Count != 0){
            level++;
            HashSet<int> nextQ = new HashSet<int>();
            foreach(int remainder in q){
                foreach(int squared in squaredNums){
                    if(remainder == squared){
                        return level;
                    } else if(remainder < squared){
                        break;
                    } else {
                        nextQ.Add(remainder - squared);
                    }
                }
            }
            q = nextQ;
        }
        
        return level;
    }
}
