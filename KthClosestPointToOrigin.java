/*
    Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane and an integer k, 
    return the k closest points to the origin (0, 0).

    The distance between two points on the X-Y plane is the Euclidean distance (i.e., √(x1 - x2)2 + (y1 - 
    y2)2).

    You may return the answer in any order. The answer is guaranteed to be unique (except for the order that 
    it is in).
    
    T - O(Nlogk), we go through n length of points int[n][] to create hashmap of points and their euclidean 
                  distances. Then for maintaining pq order of these points by their distances takes logk time
    S - O(n + k), we create a hashmap to contain  
*/
class Solution {
    public int[][] kClosest(int[][] points, int k) {
        if(points.length == k) return points;
        
        Map<Integer, Double> distances = new HashMap<>();
        int pt = 0;
        for(int[] point : points){
            double distance = Math.sqrt(point[0] * point[0] + point[1] * point[1]);
            distances.put(pt++, distance);
        }
        
        Queue<Integer> pq = new PriorityQueue<>((a, b) -> Double.compare(distances.get(a), distances.get(b)));
        
        for(int point : distances.keySet()){
            pq.add(point);
        }
        
        int[][] output = new int[k][2];
        for(int i = 0; i < k; i++){
            int key = pq.poll();
            output[i] = points[key];
        }
        
        return output;
    }
}
