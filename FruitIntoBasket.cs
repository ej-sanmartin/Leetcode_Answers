/*
    T - O(n), n being the length of the int[]
    S- O(1), we are only ever creating local int variables
*/
public class Solution {
    public int TotalFruit(int[] tree) {
        if(tree.Length == 0) return -1;
        
        int lastFruit = -1;
        int secondLastFruit = -1;
        int lastFruitCount = 0;
        int currentSum = 0;
        int largest = 0;
        
        for(int i = 0; i < tree.Length; i++){
            if(tree[i] == lastFruit || tree[i] == secondLastFruit){
                currentSum++;
            } else {
                currentSum = lastFruitCount + 1;
            }
            
            if(tree[i] == lastFruit){
                lastFruitCount++;
            } else {
                lastFruitCount = 1;
                secondLastFruit = lastFruit;
                lastFruit = tree[i];
            }
            
            largest = Math.Max(largest, currentSum);
        }
        
        return largest;
    }
}

/*
    T - O(n), where n is the length of the tree int[]. Inner while loop only loops through characters
              from startIndex up until frequencyTable only has two kvps, so that would take O(n + n)
               time in totla, which is equivalent to O(2n) and we drop constants in time complexity
               analysis so it is simply O(n)
    S - O(n) to O(1), linear because of space to have dictionary, could be constant since dictionary
                      will only hold up to 2 kvp
*/
public class Solution {
    public int TotalFruit(int[] tree){
        Dictionary<int, int> frequencyTable = new Dictionary<int, int>(3);
        int startIndex = 0;
        int currentSum = 0;
        int largest = 0;
        for(int i = 0; i < tree.Length; i++){
            if(frequencyTable.ContainsKey(tree[i])){
                frequencyTable[tree[i]]++;
            } else {
                frequencyTable.Add(tree[i], 1);
            }
            
            currentSum++;
                
            while(frequencyTable.Count > 2){
                frequencyTable[tree[startIndex]]--;
                if(frequencyTable[tree[startIndex]] == 0){
                    frequencyTable.Remove(tree[startIndex]);
                }
                currentSum--;
                startIndex++;
            }
            
            largest = Math.Max(largest, currentSum);
        }
        
        return largest;
    }
}
