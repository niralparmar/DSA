var util = require('../util');

var insertion = function (arr) {
    let tmp;
    for (let i = 0; i < arr.length; i++) {
        tmp = arr[i];
        let j;
        for (j = i; j > 0 && arr[j-1] > tmp  ; j--) {
            arr[j] = arr[j-1];
        }
        arr[j] = tmp;
    }
}

const a1 = [6,2,5,9,1,4,10,0,1,3,7,8,2,6];
util.print(a1);
insertion(a1);
util.print(a1);