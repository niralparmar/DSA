/**
Print all sub-arrays with 0 sum
Given an array of integers, print all sub-arrays with 0 sum.
For example, 

Input:  { 4, 2, -3, -1, 0, 4 }
Sub-arrays with 0 sum are
{ -3, -1, 0, 4 }
{ 0 }

Input:  { 3, 4, -7, 3, 1, 3, 1, -4, -2, -2 }
Sub-arrays with 0 sum are
{ 3, 4, -7 }
{ 4, -7, 3 }
{ -7, 3, 1, 3 }
{ 3, 1, -4 }
{ 3, 1, 3, 1, -4, -2, -2 }
{ 3, 4, -7, 3, 1, 3, 1, -4, -2, -2 }
 */
var util = require('../../util');
//O(n^2)
function findzerosumsubarray_0(arr) {
    for (let i = 0; i < arr.length; i++) {
        let sum = 0;
        for (let j = i; j < arr.length; j++) {
            sum += arr[j];
            if (sum == 0) {
                util.print('Subarray Found at:[' + i + ',' + j + ']');
            }
        }
    }
}
function findzerosumsubarray_1(arr) {
    let map = {};
    let sum = 0;
    map[0] = [-1];
    for (let i = 0; i < arr.length; i++) {
        sum += arr[i];
        if (map[sum] != undefined) {
            const subarray = map[sum];
            for (let j = 0; j < subarray.length; j++) {
                const beginIndex = 1 + subarray[j];
                util.print('Subarray Found at:[' +  beginIndex + ',' + i + ']');
            }
        }
        if (map[sum] == undefined) {
            map[sum] = [];
        }
        map[sum].push(i);
    }
}
let arr = [4, 2, -3, -1, 0, 4];
findzerosumsubarray_0(arr);
findzerosumsubarray_1(arr);
arr = [3, 4, -7, 3, 1, 3, 1, -4, -2, -2];
findzerosumsubarray_0(arr);
findzerosumsubarray_1(arr);