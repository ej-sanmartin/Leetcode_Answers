/*
  You are given the array paths, where paths[i] = [cityAi, cityBi] means there exists a direct
  path going from cityAi to cityBi. Return the destination city, that is, the city without any
  path outgoing to another city.

  It is guaranteed that the graph of paths forms a line without any loop, therefore, there will
  be exactly one destination city.
*/

public class Solution {
    public string DestCity(IList<IList<string>> paths) {
        string answer = "";
        HashSet<string> pathTractor = new HashSet<string>();
        
        int pathsCount = paths.Cast<object>().Count(); // create count variable to stop iterations in loops
        
        // add all locations from "from" part of each list
        for(int i = 0; i < pathsCount; i++){
            pathTractor.Add(paths[i][0]);
        }
        
        // if the "to" in each list isn't in the HashSet, it's the final destination
        for(int i = 0; i < pathsCount; i++){
            if(!pathTractor.Remove(paths[i][1])){
                answer = paths[i][1];
            }
        }
    
        return answer;
    }
}
