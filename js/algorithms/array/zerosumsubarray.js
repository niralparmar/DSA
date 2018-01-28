/*
Given an array of integers, check if array contains a sub-array having 0 sum.
For example,

Input:{ 3, 4, -7, 3, 1, 3, 1, -4, -2, -2 }
Output: Subarray with 0 sum exists

{ 3, 4, -7 } { 4, -7, 3 } { -7, 3, 1, 3 } { 3, 1, -4 } { 3, 1, 3, 1, -4, -2, -2 } { 3, 4, -7, 3, 1, 3, 1, -4, -2, -2 } 
*/ 
var util = require('../../util');

function zerosumsubarray(arr){
    let map = {};
    let sum = 0;
    map[0] = 0;
    for (let i = 0; i < arr.length; i++) {
        sum += arr[i];
        if(map[sum] != undefined){
            util.print("Sub array exist");
            return;
        }
        else{
            map[i] = sum;
        }
        
    }
}
let arr = [3, 4, -7, 3, 1, 3, 1, -4, -2, -2];
zerosumsubarray(arr);

