/*
    There are n rooms labeled from 0 to n - 1 and all the rooms are locked except for room 0. Your goal 
    is to visit all the rooms. However, you cannot enter a locked room without having its key.

    When you visit a room, you may find a set of distinct keys in it. Each key has a number on it, 
    denoting which room it unlocks, and you can take all of them with you to unlock the other rooms.

    Given an array rooms where rooms[i] is the set of keys that you can obtain if you visited room i, 
    return true if you can visit all the rooms, or false otherwise.

    T - O(V + E), time complexity of DFS
    S - O(H), since recursive, space will depend upon deepest path we travel, which could be entire graph
*/
public class Solution {
    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        HashSet<int> visited = new HashSet<int>();
        VisitRoom(rooms, 0, visited);
        return visited.Count == rooms.Count;
    }
    
    public void VisitRoom(IList<IList<int>> rooms, int current, HashSet<int> visited){
        if(visited.Contains(current)) return;
        visited.Add(current);
        foreach(int room in rooms[current]){
            if(!visited.Contains(room)){
                VisitRoom(rooms, room, visited);
            }
        }
    }
}
