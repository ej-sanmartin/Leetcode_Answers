/*
    A company is planning to interview 2n people. Given the array costs where 
    costs[i] = [aCosti, bCosti], the cost of flying the ith person to city a is 
    aCosti, and the cost of flying the ith person to city b is bCosti.

    Return the minimum cost to fly every person to a city such that exactly n 
    people arrive in each city.

    T - O(nlogn), time complexity of quicksort of input
    S - O(logn), space complexity of quicksort
*/
public class Solution {
    public int TwoCitySchedCost(int[][] costs) {
        Array.Sort(costs, (a, b) => a[0] - a[1] - (b[0] - b[1]));
        int total = 0;
        int n = costs.Length / 2;
        for(int i = 0; i < n; i++){
            total += costs[i][0] + costs[i + n][1];
        }    
        return total;
    }
}
