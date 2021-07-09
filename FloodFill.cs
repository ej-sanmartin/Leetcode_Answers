/*
    An image is represented by an m x n integer grid image where image[i][j] represents 
    the pixel value of the image.

    You are also given three integers sr, sc, and newColor. You should perform a flood 
    fill on the image starting from the pixel image[sr][sc].

    To perform a flood fill, consider the starting pixel, plus any pixels connected 4-
    directionally to the starting pixel of the same color as the starting pixel, plus any 
    pixels connected 4-directionally to those pixels (also with the same color), and so 
    on. Replace the color of all of the aforementioned pixels with newColor.

    Return the modified image after performing the flood fill.

    T - O(V + E), since we are doing DFS
    T - O(n), could also be linear as we may be changing the color of every pixel in image
    S - O(h), where h is height of recursive call stack, which depends on longest path
              of found by DFS
*/
public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor) {
        int startColor = image[sr][sc];
        FindPixels(image, sr, sc, startColor, newColor);
        return image;
    }
    
    private void FindPixels(int[][] image, int row, int column, int startColor, int newColor){
        if(IsOutOfBounds(image, row, column)) return;
        if(image[row][column] != startColor) return;
        
        image[row][column] = -1;
        
        FindPixels(image, row - 1, column, startColor, newColor);
        FindPixels(image, row, column + 1, startColor, newColor);
        FindPixels(image, row + 1, column, startColor, newColor);
        FindPixels(image, row, column - 1, startColor, newColor);
        
        image[row][column] = newColor;
    }
    
    private bool IsOutOfBounds(int[][] image, int row, int column){
        if(row < 0 || column < 0 || row >= image.Length || column >= image[0].Length) return true;
        return false;
    }
}
