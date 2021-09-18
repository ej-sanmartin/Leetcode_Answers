/*
    You have a lock in front of you with 4 circular wheels. Each wheel has 10 slots: 
    '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'. The wheels can rotate freely and 
    wrap around: for example we can turn '9' to be '0', or '0' to be '9'. Each move 
    consists of turning one wheel one slot.

    The lock initially starts at '0000', a string representing the state of the 4 wheels.

    You are given a list of deadends dead ends, meaning if the lock displays any of these 
    codes, the wheels of the lock will stop turning and you will be unable to open it.

    Given a target representing the value of the wheels that will unlock the lock, return 
    the minimum total number of turns required to open the lock, or -1 if it is 
    impossible.

    T - O(n^2 * A^n + D), we traverse through all nodes until we get to target in bfs
    S 0 (A^n. + D), size of queue and hashset for deadends
*/
public class Solution {
    public int OpenLock(string[] deadends, string target) {
        HashSet<string> dead = new HashSet<string>();
        foreach(string deadend in deadends){
            dead.Add(deadend);
        }
        Queue<string> q = new Queue<string>();
        q.Enqueue("0000");
        q.Enqueue("");
        HashSet<string> visited = new HashSet<string>();
        visited.Add("0000");
        int depth = 0;
        
        while(q.Count != 0){
            string current = q.Dequeue();
            if(current.Length == 0){
                depth++;
                if(q.Count != 0){
                    q.Enqueue("");
                }
            } else if(current.Equals(target)){
                return depth;
            } else if(!dead.Contains(current)){
                for(int i = 0; i < 4; i++){
                    for(int d = -1; d <= 1; d += 2){
                        int y = ((current[i] - '0') + d + 10) % 10;
                        string adjacent = current.Substring(0, i) + ("" + y) + current.Substring(i + 1);
                        if(!visited.Contains(adjacent)){
                            visited.Add(adjacent);
                            q.Enqueue(adjacent);
                        }
                    }
                }
            }
        }
        
        return -1;
    }
}
