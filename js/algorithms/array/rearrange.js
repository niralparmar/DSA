/**
 Rearrange the array with alternate high and low elements
 Given an array of integers, rearrange the array such that every second element of the array is greater than its left and right elements.
Assume no duplicate elements are present in the array

For example, 
Input:  {1, 2, 3, 4, 5, 6, 7}
Output: {1, 3, 2, 5, 4, 7, 6}
Input:  {9, 6, 8, 3, 7}
Output: {6, 9, 3, 8, 7}
Input:  {6, 9, 2, 5, 1, 4}
Output: {6, 9, 2, 5, 1, 4}
 */
var util = require('../../util');
function swap(arr, i, j) {
    let tmp = arr[i];
    arr[i] = arr[j];
    arr[j] = tmp;
}
function rearrangeArray(arr) {
    let i = 0;
    for (let i = 1; i < arr.length; i += 2) {
        if (arr[i - 1] > arr[i]) {
            swap(arr, i - 1, i);
        }
        if (i + 1 < arr.length && arr[i + 1] > arr[i]) {
            swap(arr, i + 1, i);
        }

    }
    util.print(arr);
}

let arr = [1, 2, 3, 4, 5, 6, 7];
rearrangeArray(arr);
arr = [9, 6, 8, 3, 7];
rearrangeArray(arr);
arr = [6, 9, 2, 5, 1, 4];
rearrangeArray(arr);
