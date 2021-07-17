public class Solution {
    
    /*
        Merge Sort
        T - O(nlogn), dividing takes logn time and merging all divisions take n time
        S - O(n), we must store divided lists somewhere, also recursive call stack size n
                  where n is number of elements in nums array
    */
    public int[] SortArray(int[] nums) {
        if(nums.Length == 1) return nums;
        
        List<int> left = new List<int>();
        List<int> right = new List<int>();
        
        int middle = nums.Length / 2;
        
        for(int i = 0; i < middle; i++){
            left.Add(nums[i]);
        }
        
        for(int i = middle; i < nums.Length; i++){
            right.Add(nums[i]);
        }
        
        int[] leftArray = SortArray(left.ToArray());
        int[] rightArray = SortArray(right.ToArray());
        
        return Merge(leftArray, rightArray);
    }
    
    private int[] Merge(int[] firstArray, int[] secondArray){
        int[] result = new int[firstArray.Length + secondArray.Length];
        int resultPointer, firstArrayPointer, secondArrayPointer;
        resultPointer = firstArrayPointer = secondArrayPointer = 0;
        
        while(firstArrayPointer < firstArray.Length || secondArrayPointer < secondArray.Length){
            if(firstArrayPointer < firstArray.Length && secondArrayPointer < secondArray.Length){
                if(firstArray[firstArrayPointer] <= secondArray[secondArrayPointer]){
                    result[resultPointer++] = firstArray[firstArrayPointer++];
                } else {
                    result[resultPointer++] = secondArray[secondArrayPointer++];
                }
            } else if(firstArrayPointer < firstArray.Length){
                result[resultPointer++] = firstArray[firstArrayPointer++];
            } else {
                result[resultPointer++] = secondArray[secondArrayPointer++];
            }
        }
        
        return result;
    }
    
    /*
        Radix Sort (needs extra logic to handle negative numbers)
        T - O(n + d) -> O(d(n + d)), non comparative sorting algorithm, speed based on amount of
                                     digits of largest element in the input array
        S - O(n + 2^d), space depends on space created for counting sort
    */
    public int[] SortArray(int[] nums) {
        int max = GetMax(nums);
        for(int exponent = 1; (max/exponent) > 0; exponent *= 10 ){
            CountingSort(nums, exponent);
        }
        return nums;
    }
    
    private int GetMax(int[] array){
        int max = array[0];
        
        for(int i = 1; i < array.Length; i++){
            if(array[i] > max) max = array[i];
        }
        
        return max;
    }
    
    private void CountingSort(int[] input, int exponent){
        int i;
        int[] count = new int[10];
        int[] output = new int[input.Length];
        
        for(i = 0; i < input.Length; i++){
            count[(input[i] / exponent) % 10]++;
        }
        
        for(i = 1; i < 10; i++){
            count[i] += count[i - 1];
        }
        
        for(i = input.Length - 1; i >= 0; i--){
            output[count[(input[i] / exponent) % 10] - 1] = input[i];
            count[(input[i] / exponent) % 10]--;
        }
        
        for(i = 0; i < input.Length; i++){
            input[i] = output[i];
        }
    }
    
    /*
        Heap Sort
        T - O(nlogn), building heap is O(n) time and heapifying is O(logn) time. Swap is constant
        S - O(1), sorted in place, recursive calls only rearranging within same array
    */
    public int[] SortArray(int[] nums) {
        int n = nums.Length;
        
        for(int i = (n / 2) - 1; i >= 0; i--){
            Heapify(nums, n, i);
        }
        
        for(int i = n - 1; i >= 0; i--){
            Swap(0, i, nums);
            Heapify(nums, i, 0);
        }
        
        return nums;
    }
    
    private void Heapify(int[] arr, int bounds, int i){
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;
        
        if(left < bounds && arr[left] > arr[largest]) largest = left;
        if(right < bounds && arr[right] > arr[largest]) largest = right;
        
        if(largest != i){
            Swap(i, largest, arr);
            Heapify(arr, bounds, largest);
        }
    }
    
    private void Swap(int a, int b, int[] arr){
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }
    
    /*
        Quick Sort
        T - O(nlogn),
        S - O(n) -> o(logn), depends on the recursive call stack
    */
    public int[] SortArray(int[] nums) {
        QuickSort(nums, 0, nums.Length - 1);
        return nums;
    }
    
    private void QuickSort(int[] arr, int low, int high){
        if(low < high){
            int partitionIndex = Partition(arr, low, high);
            QuickSort(arr, low, partitionIndex - 1);
            QuickSort(arr, partitionIndex + 1, high);
        }
    }
    
    private int Partition(int[] arr, int low, int high){
        int pivot = arr[high];
        int i = (low - 1);
        
        for(int j = low; j <= high; j++){
            if(arr[j] < pivot){
                i++;
                Swap(arr, i, j);
            }
        }
        
        Swap(arr, i + 1, high);
        return i + 1;
    }
    
    private void Swap(int[] arr, int a, int b){
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }
    
    /*
        Bubble Sort
        T - O(n^2), as we are looping through every element a quadratic amount of times, bubbling
                    up larger elements to the end of the array until sorted
        S - O(1), no additional space is created that is depenedent on input
    */
    public int[] SortArray(int[] nums) {
        int n = nums.Length;
        int temp;
        for(int i = 0; i < n; i++){
            for(int j = 0; j < n - i - 1; j++){
                if(nums[j] > nums[j + 1]){
                    temp = nums[j];
                    nums[j] = nums[j + 1];
                    nums[j + 1] = temp;
                }
            }
        }
        return nums;
    }
    
    /*
        Selection Sort
        T - O(n^2), we are comparing i iterator to every element to the right to check and find 
                    if there are smaller numbers and which index that smaller number is on
        S - O(1), no additional space that is dependent on input is created
    */
    public int[] SortArray(int[] nums) {
        int n = nums.Length;
        int minIndex, temp, i, j;
        for(i = 0; i < n - 1; i++){
            minIndex = i;
            for(j = i + 1; j < n; j++){
                if(nums[minIndex] > nums[j]) minIndex = j;
            }
            if(minIndex != i){
                temp = nums[i];
                nums[i] = nums[minIndex];
                nums[minIndex] = temp;
            }
        }
        return nums;
    }
    
    /*
        Insertion Sort
        T - O(n^2), as we are, at worst case, going to shift every element at every iteration
                    to insert the elements at their correct and sorted position
        S - O(1), only creating three variables to store indexes and a current variable
    */
    public int[] SortArray(int[] nums) {
        int i, j, current;
        for(i = 1; i < nums.Length; i++){
            current = nums[i];
            j = i - 1;
            while(j >= 0 && nums[j] > current){
                nums[j + 1] = nums[j];
                j--;
            }
            nums[j + 1] = current;
        }
        return nums;
    }
}
