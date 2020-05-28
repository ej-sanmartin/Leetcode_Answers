/*
  There are n people whose IDs go from 0 to n - 1 and each person belongs exactly to one group.
  Given the array groupSizes of length n telling the group size each person belongs to,
  return the groups there are and the people's IDs each group includes.

  You can return any solution in any order and the same applies for IDs.
  Also, it is guaranteed that there exists at least one solution. 
*/

public class Solution {
    public IList<IList<int>> GroupThePeople(int[] groupSizes) {
        Dictionary<int, List<int>> dictionaryAnswer = new Dictionary<int, List<int>>();
        int[] iDList = CreateIDs(groupSizes); // IDs of all people in the given groupSizes array
        
        for(int i = 0; i < groupSizes.Length; i++){
            if(dictionaryAnswer.ContainsKey(groupSizes[i])){ // if dict has groupSizes number already, add to that list
                dictionaryAnswer[groupSizes[i]].Add(iDList[i]);
            } else { // if not, create neww key value pair with unique groupSizes number
                dictionaryAnswer.Add(groupSizes[i], new List<int> { iDList[i] });
            }
        }
        
        // goes through all keys and creates array of equal sizes to be transformed into IList<int>
        return dictionaryAnswer.Keys.Select(x => Enumerable.Range(0, dictionaryAnswer[x].Count / x)
                    .Select(y => dictionaryAnswer[x].Skip(y).Take(x).ToList())).SelectMany(x => x)
                    .ToList<IList<int>>();
    }
    
    // creates int[] populated by unique index number, to act as each person's ID
    public int[] CreateIDs(int[] group){
        List<int> personIDs = new List<int>();
        
        for(int i = 0; i < group.Length; i++){
            personIDs.Add(i);
        }

         return personIDs.ToArray();
    }
}
