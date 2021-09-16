/*
  You are given an array points representing integer coordinates of some points on a 2D-plane, where points[i] = [xi, yi].

  The cost of connecting two points [xi, yi] and [xj, yj] is the manhattan distance between them: |xi - xj| + |yi - yj|, where |val| denotes
  the absolute value of val.

  Return the minimum cost to make all points connected. All points are connected if there is exactly one simple path between any two points.

  T - O(ElogV), prims algorithm time complexity
  S - O(V), space to hold vertices
*/
class Solution {
    class Edge {
        int start;
        int end;
        int cost;
        public Edge(int start, int end, int cost){
            this.start = start;
            this.end = end;
            this.cost = cost;
        }
    }
    
    public int minCostConnectPoints(int[][] points) {
        if(points == null || points.length == 0) return 0;
        int vertices = points.length;
        PriorityQueue<Edge> pq = new PriorityQueue<>((x, y) -> x.cost - y.cost);
        HashSet<Integer> visited = new HashSet<>();
        int result = 0;
        
        for(int i = 1; i < vertices; i++){
            int[] pointOne = points[0];
            int[] pointTwo = points[i];
            int cost = Math.abs(pointOne[0] - pointTwo[0]) + Math.abs(pointOne[1] - pointTwo[1]);
            pq.offer(new Edge(0, i, cost));
        }
        visited.add(0);
        
        while(!pq.isEmpty() && visited.size() <= vertices - 1){
            Edge current = pq.poll();
            int start = current.start;
            int end = current.end;
            int cost = current.cost;
            if(!visited.contains(end)){
                result += cost;
                visited.add(end);
                for(int i = 0; i < vertices; i++){
                    if(!visited.contains(i)){
                        int distance = Math.abs(points[end][0] - points[i][0]) + Math.abs(points[end][1] - points[i][1]);
                        pq.offer(new Edge(end, i, distance));   
                    }
                }
            }
        }
        return result;
    }
}
