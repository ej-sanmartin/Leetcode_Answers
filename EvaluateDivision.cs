/*
    You are given an array of variable pairs equations and an array of real numbers values, where equations[i] = [Ai, Bi] and 
    values[i] represent the equation Ai / Bi = values[i]. Each Ai or Bi is a string that represents a single variable.

    You are also given some queries, where queries[j] = [Cj, Dj] represents the jth query where you must find the answer for 
    Cj / Dj = ?.

    Return the answers to all queries. If a single answer cannot be determined, return -1.0.

    Note: The input is always valid. You may assume that evaluating the queries will not result in division by zero and that 
    there is no contradiction.

    Note: N is number of equations and M is number of queries
    T - O((M + N) log star N), find on each equation and then find on all queries result in this time complexity
    S - O(N), without result M, Union Find data structure holds only N elements
*/
public class Solution {
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        Dictionary<string, Tuple<string, double>> nodeWeight = new Dictionary<string, Tuple<string, double>>();
        
        for(int i = 0; i < equations.Count; i++){
            List<string> equation = equations[i] as List<string>;
            string dividend = equation[0];
            string divisor = equation[1];
            double quotient = values[i];
            
            Union(nodeWeight, dividend, divisor, quotient);
        }
        
        double[] results = new double[queries.Count];
        for(int i = 0; i < queries.Count; i++){
            List<string> query = queries[i] as List<string>;
            string dividend = query[0];
            string divisor = query[1];
            if(!nodeWeight.ContainsKey(dividend) || !nodeWeight.ContainsKey(divisor)){
                results[i] = -1.0;
            } else {
                Tuple<string, double> dividendEntry = Find(nodeWeight, dividend);
                Tuple<string, double> divisorEntry = Find(nodeWeight, divisor);
                
                string dividendID = dividendEntry.Item1;
                string divisorID = divisorEntry.Item1;
                double dividendWeight = dividendEntry.Item2;
                double divisorWeight = divisorEntry.Item2;
                
                if(!dividendID.Equals(divisorID)){
                    results[i] = -1.0;
                } else {
                    results[i] = dividendWeight / divisorWeight;
                }
            }
        }
        return results;
    }
    
    private Tuple<string, double> Find(Dictionary<string, Tuple<string, double>> nodeWeight, string nodeID){
        if(!nodeWeight.ContainsKey(nodeID)){
            nodeWeight.Add(nodeID, new Tuple<string, double>(nodeID, 1.0));
        }
        
        Tuple<string, double> entry = nodeWeight[nodeID];
        if(!entry.Item1.Equals(nodeID)){
            Tuple<string, double> newEntry = Find(nodeWeight, entry.Item1);
            nodeWeight[nodeID] = new Tuple<string, double>(newEntry.Item1, newEntry.Item2 * entry.Item2);
        }
        return nodeWeight[nodeID];
    }
    
    private void Union(Dictionary<string, Tuple<string, double>> nodeWeight, string dividend, string divisor, double weight){
        Tuple<string, double> dividendEntry = Find(nodeWeight, dividend);
        Tuple<string, double> divisorEntry = Find(nodeWeight, divisor);
        
        string dividendID = dividendEntry.Item1;
        string divisorID = divisorEntry.Item1;
        double dividendWeight = dividendEntry.Item2;
        double divisorWeight = divisorEntry.Item2;
        
        if(!dividendID.Equals(divisorID)){
            nodeWeight[dividendID] = new Tuple<string, double>(divisorID, divisorWeight * weight / dividendWeight);
        }
    }
}
