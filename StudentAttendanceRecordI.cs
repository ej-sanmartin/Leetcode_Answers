/*
    You are given a string s representing an attendance record for a student where 
    each character signifies whether the student was absent, late, or present on 
    that day. The record only contains the following three characters:

    'A': Absent.
    'L': Late.
    'P': Present.

    The student is eligible for an attendance award if they meet both of the 
    following criteria:

    The student was absent ('A') for strictly fewer than 2 days total.
    The student was never late ('L') for 3 or more consecutive days.
    Return true if the student is eligible for an attendance award, or false
    otherwise.

    T - O(n), as we must pass through every element in s to determine if a student 
              is disqualified
    S - O(1), as we are only ever creating int variables to keep track of tardiness
              and absenses
*/
public class Solution {
    public bool CheckRecord(string s) {
        int absentCount, tardyCount;
        absentCount = tardyCount = 0;
        
        for(int i = 0; i < s.Length; i++){
            if(s[i] == 'A') absentCount++;
            if(absentCount == 2) return false;
            
            if(s[i] == 'L') tardyCount++;
            else tardyCount = 0;
            
            if(tardyCount == 3) return false;
        }
        
        return true;
    }
}
