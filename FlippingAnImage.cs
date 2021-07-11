/*
    Given an n x n binary matrix image, flip the image 
    horizontally, then invert it, and return the resulting image.

    To flip an image horizontally means that each row of the image 
    is reversed.

    For example, flipping [1,1,0] horizontally results in [0,1,1].
    To invert an image means that each 0 is replaced by 1, and 
    each 1 is replaced by 0.

    For example, inverting [0,1,1] results in [1,0,0].
    

    T - O(n^2), as w are traversing through entire matrix
    S - O(1), no additional space is created that depends on
              input
*/
public class Solution {
    public int[][] FlipAndInvertImage(int[][] image){
        int start, end;
        for(int row = 0; row < image.Length; row++){
            start = 0;
            end = image[row].Length - 1;
            while(start <= end){
                Swap(image, row, start++, end--);
            }
        }
        return image;
    }
    
    private void Swap(int[][] image, int row, int start, int end){
        int temp = image[row][start];
        image[row][start] = image[row][end] == 0 ? 1 : 0; // ^1
        image[row][end] = temp == 0 ? 1 : 0; // ^1
    }
}
