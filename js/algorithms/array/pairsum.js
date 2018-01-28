/* Given an unsorted array of integers, find a pair with given sum in it.
For example,
Input:arr = [8, 7, 2, 5, 3, 1]
sum = 10
Output:
Pair found at index 0 and 2 (8 + 2)
OR
Pair found at index 1 and 4 (7 + 3)
*/
var util = require('../../util');

// Naive method o(n*2)
function findPair_0(arr, sum) {
    for (let i = 0; i < arr.length - 1; i++) {
        for (let j = i + 1; j < arr.length; j++) {
            if (arr[i] + arr[j] == sum) {
                util.print('[' + i + ',' + j + ']');
                return;
            }
        }
    }
}

//Efficient o(n log n)
function findPair_1(arr, sum) {
    arr.sort();
    let low = 0;
    let high = arr.length;

    while (low < high) {
        if (arr[low] + arr[high] == sum) {
            util.print('[' + low + ',' + high + ']');
            return;
        }
        (arr[low] + arr[high] < sum) ? low++ : high--;
    }
}

//O(n)
function findPair_2(arr, sum) {
    let map = {}
    for (let i = 0; i < arr.length; i++) {
        if(map[sum - arr[i]] != undefined){
            util.print('[' + map[sum - arr[i]] + ',' + i + ']');
            return;
        }
        map[arr[i]] = i;
    }
}

let arr = [8, 7, 2, 5, 3, 1];
let sum = 10;
findPair_0(arr, sum);
findPair_2(arr, sum);
findPair_1(arr, sum);