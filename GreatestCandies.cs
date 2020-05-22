/*
  Given the array candies and the integer extraCandies, where candies[i]
  represents the number of candies that the ith kid has.
  
  For each kid check if there is a way to distribute extraCandies among
  the kids such that he or she can have the greatest number of candies among them.
  Notice that multiple kids can have the greatest number of candies.
  
  Also note, in the answer, it seems that leetcode is already using the Linq library.
  In the case that the below class is not working when running in another environment,
  remove comment symbols from line 15.
  
*/

// using System.Linq

public class Solution {
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        IList<bool> answer = new List<bool>();
        int highestValue = candies.Max();
        foreach(int kid in candies){
            if(highestValue <= kid + extraCandies){
                answer.Add(true);
            }
            else {
                answer.Add(false);
            }
        }
        return answer;
    }
}
