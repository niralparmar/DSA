var util = require('../../util');
/*
Check if given set of moves is circular or not. The move is circular if its starting and ending coordinates are the same. The moves can contain instructions to move one unit in same direction (M), to change direction to left of current direction (L) and to change direction to right of current direction (R).
For example,
Set of moves MRMRMRM is circular
Set of moves MRMLMRMRMMRMM is circular
*/

function isCircular(str) {

    let dir = 'N';
    let x = 0;
    let y = 0;
    for (let index = 0; index < str.length; index++) {
        const element = str[index];
        switch (element) {
            case 'M':
            if(dir === 'N') y++;
            else if(dir === 'S') y--;
            else if(dir === 'E') x++;
            else if(dir === 'W') x--;
                break;
            case 'L':
            if(dir === 'N') dir = 'W';
            else if(dir === 'S') dir = 'E';
            else if(dir === 'E') dir = 'N';
            else if(dir === 'W') dir = 'S';
                break;
            case 'R':
            if(dir === 'N') dir = 'E';
            else if(dir === 'S') dir = 'W';
            else if(dir === 'E') dir = 'S';
            else if(dir === 'W') dir = 'N';
                break;
            default:
                break;
        }
    }
    return (!x && !y);
}

util.print(isCircular('MRMRMRM'));
util.print(isCircular('MRMLMRMRMMRMM'));
util.print(isCircular('MRMRMRMMMMMMM'));
util.print(isCircular('MMMMMMMMMM'));
util.print(isCircular('RRRR'));