/*
    You are a product manager and currently leading a team to develop a new product. 
    Unfortunately, the latest version of your product fails the quality check. Since 
    each version is developed based on the previous version, all the versions after a 
    bad version are also bad.

    Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad 
    one, which causes all the following ones to be bad.

    You are given an API bool isBadVersion(version) which returns whether version is 
    bad. Implement a function to find the first bad version. You should minimize the 
    number of calls to the API.
    
    T - O(logn), binary search
    S - O(1), constant space used, no additional space dependend on input size
*/

/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        int early = 0;
        int latest = n;
        while(early < latest){
            int middleVersion = early + ((latest - early) / 2);
            bool result = IsBadVersion(middleVersion);
            if(result){
                latest = middleVersion;
            } else {
                early = middleVersion + 1;
            }
        }
        
        return early;
    }
}
