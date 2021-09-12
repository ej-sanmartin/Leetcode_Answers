/*
    You are given an m x n binary matrix mat of 1's (representing soldiers) and 0's 
    (representing civilians). The soldiers are positioned in front of the civilians. That is, 
    all the 1's will appear to the left of all the 0's in each row.

    A row i is weaker than a row j if one of the following is true:

    The number of soldiers in row i is less than the number of soldiers in row j.
    Both rows have the same number of soldiers and i < j.

    Return the indices of the k weakest rows in the matrix ordered from weakest to strongest.

    T - O(mlogn + mlogk == mlognk), time complexity of binary search on each row and pq that 
                                    holds up to k elements and has up to m loops to add to it
    S - O(k), pq will only hold as much k + 1 elements in it
*/
class Solution {
    public int[] kWeakestRows(int[][] mat, int k) {
        if(mat.length == 0 || k == 0 || k > mat.length) return new int[]{ -1, -1};
        PriorityQueue<int[]> pq = new PriorityQueue<>((a, b) -> {
            if(a[1] == b[1]) return b[0] - a[0];
            return b[1] - a[1];
        });
        
        int group = 0;
        for(int[] row : mat){
            int soldierCount = findSoldierCount(row);
            pq.offer(new int[]{ group++, soldierCount });
            if(pq.size() > k) pq.poll();
        }
        
        int[] weakest = new int[k];
        int[] lastWeakestGroup = pq.poll();
        weakest[k - 1] = lastWeakestGroup[0];
        for(int i = k - 2; i >= 0; i--){
            int[] currentGroup = pq.poll();
            weakest[i] = currentGroup[0];
            if(weakest[i] > weakest[i + 1] && lastWeakestGroup[1] == currentGroup[1]){
                swap(weakest, i, i + 1);
            }
            lastWeakestGroup = currentGroup;
        }
        
        return weakest;
    }
    
    public int findSoldierCount(int[] row){
        int low = 0;
        int high = row.length - 1;
        while(low <= high){
            int middle = low + ((high - low) / 2);
            if(row[middle] == 1){
                if(middle + 1 >= row.length) return row.length;
                if(row[middle + 1] == 0) return middle + 1;
                low = middle + 1;
            } else {
                high = middle - 1;
            }
        }
        return 0;
    }
    
    public void swap(int[] arr, int a, int b){
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }
}
