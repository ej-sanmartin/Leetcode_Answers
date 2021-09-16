/*
    There are n cities connected by some number of flights. You are given an array flights where flights[i] = 
    [fromi, toi, pricei] indicates that there is a flight from city fromi to city toi with cost pricei.

    You are also given three integers src, dst, and k, return the cheapest price from src to dst with at most k 
    stops. If there is no such route, return -1.

    T - O(ke), for k + 1 iterations, we go through all the edges on the graph
    S - O(v), we create 2 * v multidimensional array to store previous and current distance
*/
public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        long[,] distances = new long[2, n]; // 2 rows, 1st prev iteration, 2nd current. Also, long so no overflow
        for(int row = 0; row < 2; row++){
            for(int col = 0; col < n; col++){
                distances[row, col] = Int32.MaxValue;
            }
        }
        distances[0, src] = 0;
        distances[1, src] = 0;
        
        for(int i = 0; i < k + 1; i++){
            foreach(int[] flight in flights){
                int start = flight[0];
                int end = flight[1];
                int price = flight[2];
                long currentDistance = distances[1 - i&1, start];
                long previousDistance = distances[i&1, end];
                if(currentDistance + price < previousDistance){
                    distances[i&1, end] = currentDistance + price;
                }
            }
        }
        
        return distances[k&1, dst] < Int32.MaxValue ? (int)distances[k&1, dst] : -1;
    }
}
