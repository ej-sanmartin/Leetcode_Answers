/*
    Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate
    (i, ai). n vertical lines are drawn such that the two endpoints of the line i is at (i, ai)
    and (i, 0). Find two lines, which, together with the x-axis forms a container,
    such that the container contains the most water.

    Notice that you may not slant the container.
    
    Input: height = [1,8,6,2,5,4,8,3,7]
    Output: 49
    
    T - O(n), where n is the size of the height int array we must traverse every element in
    S - O(1), since we are only ever creating 5 int variables to keep track of values during while loop
              which will be constant regardless of size of the input
*/

public class Solution {
    public int MaxArea(int[] height) {
        int left, maxArea, currentArea, smallestHeight;
        left = maxArea = currentArea = smallestHeight = 0;
        int right = height.Length - 1;
        
        while(left < right){
            smallestHeight = Math.Min(height[left], height[right]);
            currentArea = smallestHeight * (right - left);
            maxArea = Math.Max(maxArea, currentArea);
            
            if(height[left] >= height[right]){
                right--;
            } else {
                left++;
            }
        }
        
        return maxArea;
    }
}
