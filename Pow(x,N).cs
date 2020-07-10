// Implement pow(x, n), which calculates x raised to the power n (xn).

public class Solution {
    public double MyPow(double x, int n) {
        long N = n;
        if(N < 0){
            x = 1/x;
            N = -N;
        }

        double  answer = 1;
        double current = x;
        
        for(long i = N; i > 0; i >>= 1){
            if( (i % 2) == 1){ answer *=  current; }
            current *= current;
        }
        
        return answer;
    }   
}
