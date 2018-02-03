/*
Sort Binary Array in Linear Time
Given an binary array, sort it in linear time and constant space. Output should print contain all zeroes followed by all ones.
For example,

Input: { 1, 0, 1, 0, 1, 0, 0, 1 }
Output:{ 0, 0, 0, 0, 1, 1, 1, 1 }
*/
var util = require('../../util');
function sort(arr){
    let zeroes = 0;
    for (let i = 0; i < arr.length; i++) {
       if(arr[i] == 0){
           zeroes++;
       }
    }
    for (let j = 0; j < arr.length; j++) {
        if(zeroes-- > 0){
            arr[j] = 0;
        }
        else{
            arr[j] = 1;
        }
    }
    util.print(arr);
}
function partitionSort(arr){
    let pivot = 1;
    let j = 0;
    for (let index = 0; index < arr.length; index++) {
        if(arr[index] < arr[j]){
            let tmp = arr[index];
            arr[index] = arr[j];
            arr[j] = tmp;
            j++;
        }
    }
    util.print(arr);
}
let arr = [1, 0, 1, 0, 1, 0, 1, 1];
sort(arr);
let arr1 = [1, 0, 1, 0, 1, 0, 1, 1];
partitionSort(arr1);