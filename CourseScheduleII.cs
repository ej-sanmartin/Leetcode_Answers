/*
    There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. 
    You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you 
    must take course bi first if you want to take course ai.

    For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
    
    Return the ordering of courses you should take to finish all courses. If there are many valid 
    answers, return any of them. If it is impossible to finish all courses, return an empty array.

    T - O(V + E), traversing through all elements in adjacency list
    S - O(V + E), space needed to create adjacency list
*/
public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        int[] inDegrees = new int[numCourses];
        int[] topologicalOrder = new int[numCourses];
        
        foreach(int[] edge in prerequisites){
            int end = edge[0];
            int start = edge[1];
            
            if(!graph.ContainsKey(start)){
                graph.Add(start, new List<int>());
            }
            
            graph[start].Add(end);
            inDegrees[end]++;
        }
        
        Queue<int> q = new Queue<int>();
        for(int i = 0; i < numCourses; i++){
            if(inDegrees[i] == 0){
                q.Enqueue(i);
            }
        }
        
        int courseCount = 0;
        while(q.Count != 0){
            int course = q.Dequeue();
            topologicalOrder[courseCount++] = course;
            if(graph.ContainsKey(course)){
                foreach(int nextCourse in graph[course]){
                    inDegrees[nextCourse]--;
                    if(inDegrees[nextCourse] == 0){
                        q.Enqueue(nextCourse);
                    }
                }
            }
        }
        
        if(courseCount != numCourses){
            return new int[0];
        }
        
        return topologicalOrder;
    }
}
