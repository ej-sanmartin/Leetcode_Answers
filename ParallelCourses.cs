/*   
    You are given an integer n, which indicates that there are n courses labeled from 1 
    to n. You are also given an array relations where relations[i] = [prevCoursei, 
    nextCoursei], representing a prerequisite relationship between course prevCoursei 
    and course nextCoursei: course prevCoursei has to be taken before course 
    nextCoursei.

    In one semester, you can take any number of courses as long as you have taken all 
    the prerequisites in the previous semester for the courses you are taking.

    Return the minimum number of semesters needed to take all courses. If there is no 
    way to take all the courses, return -1.

    T - O(V + E), time complexity for BFS
    S - O(V + E), space needed to create adjacency list
*/
public class Solution {
    public int MinimumSemesters(int n, int[][] relations) {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        int[] inDegrees = new int[n + 1];
        
        for(int i = 1; i <= n ; i++){
            graph.Add(i, new List<int>());
        }
        
        foreach(int[] relation in relations){
            int previousCourse = relation[0];
            int nextCourse = relation[1];
            graph[previousCourse].Add(nextCourse);
            inDegrees[nextCourse]++;
        }
        
        List<int> q = new List<int>();
        int courseCount = 0;
        int semesters = 0;
        for(int course = 1; course < n + 1; course++){
            if(inDegrees[course] == 0){
                q.Add(course);
            }
        }
        
        while(q.Count != 0){
            semesters++;
            List<int> nextQ = new List<int>();
            foreach(int currentCourse in q){
                courseCount++;
                foreach(int nextCourse in graph[currentCourse]){
                    inDegrees[nextCourse]--;
                    if(inDegrees[nextCourse] == 0){
                        nextQ.Add(nextCourse);
                    }
                }
            }
            q = nextQ;
        }
        
        return courseCount == n ? semesters : -1;
    }
}
