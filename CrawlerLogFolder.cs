/*
    The Leetcode file system keeps a log each time some user performs a change folder 
    operation.

    The operations are described below:

    "../" : Move to the parent folder of the current folder. (If you are already in the 
            main folder, remain in the same folder).
    "./" : Remain in the same folder.
    "x/" : Move to the child folder named x (This folder is guaranteed to always exist).
           You are given a list of strings logs where logs[i] is the operation performed by 
           the user at the ith step.

    The file system starts in the main folder, then the operations in logs are performed.

    Return the minimum number of operations needed to go back to the main folder after the 
    change folder operations.

    T - O(n), where n is the number of strings in the logs string array, we have to go
              through each
    S - O(1), we are not creating any additional space that is dependent on size
    
*/
public class Solution {
    public int MinOperations(string[] logs) {
        int distanceFromHome = 0;
        
        foreach(string log in logs){
            if(log.Equals("../")) distanceFromHome = Math.Max(distanceFromHome - 1, 0);
            else if(log.Equals("./")) continue;
            else distanceFromHome++;
        }
        
        return distanceFromHome;
    }
}
