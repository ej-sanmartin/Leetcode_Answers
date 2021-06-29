/*
    You are given an array items, where each items[i] = [typei, colori, namei] describes the type, color, 
    and name of the ith item. You are also given a rule represented by two strings, ruleKey and ruleValue.

    The ith item is said to match the rule if one of the following is true:

    ruleKey == "type" and ruleValue == typei.
    ruleKey == "color" and ruleValue == colori.
    ruleKey == "name" and ruleValue == namei.

    Return the number of items that match the given rule.

    T - O(n), n being the amount of items in the list
    S - O(1), since we are only ever creating variables that are not dependent on the input size
*/
public class Solution {
    public int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue) {
        int ruleIndex = getRuleIndex(ruleKey);
        int count = 0;
        
        foreach(List<string> item in items){
            if(item[ruleIndex] == ruleValue) count++;
        }
        
        return count;
        
    }
    
    private int getRuleIndex(string ruleKey){
        switch (ruleKey){
            case "type":
                return 0;
                break;
            case "color":
                return 1;
                break;
            case "name":
                return 2;
        }
        return -1;
    }
}
