var util = require('../util');

var bubble = function (arr) {
    let tmp;
    for (let i = 0; i < arr.length; i++) {
        for (let j = 0; j < arr.length; j++) {
            if(arr[i] < arr[j]){
                tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
            }
        }
    }
}

const a1 = [6,2,5,9,1,4,10,0,1,3,7,8,2,6];
util.print(a1);
bubble(a1);
util.print(a1);