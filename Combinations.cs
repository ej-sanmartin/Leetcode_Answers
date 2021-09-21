/*
    Given two integers n and k, return all possible combinations of k numbers out of the range [1, n].
    You may return the answer in any order.
    
    T - O(K * nCk), combinations formula, time to create all of them, times k to create new list
    S - O(nCk), space to hold all combinations as dictated by combinations formula
*/
public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
        var output = new List<IList<int>>();
        Helper(new List<int>(), 1, n, k, output);
        return output;
    }
    
    public void Helper(List<int> current, int start, int end, int k, List<IList<int>> list){
        if(current.Count == k){
            list.Add(new List<int>(current));
        } else {
            for(int i = start; i <= end; i++){
                current.Add(i);
                Helper(current, i + 1, end, k, list);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
