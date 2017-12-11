var util = require('../../util');
/*
Given two strings, determine if they are anagrams or not.
Any word that exactly reproduces the letters in another order is an anagramap. In other words, X and Y are anagrams if by rearranging the letters of X, we can get Y using all the original letters of X exactly once.
For Example
silent = listen
Tom Marvolo Riddle = I am Lord Voldemort
William Shakespeare = I am a weakish speller
 */

 var isAnagram = function(stringA,stringB){

    if(stringA.length !== stringB.length) return false;

    const str1 = stringA.toLowerCase().split('').sort().join('');
    const str2 = stringB.toLowerCase().split('').sort().join('');
    return str1 === str2;
 }
 var isAnagram1 = function(stringA,stringB){
    if(stringA.length !== stringB.length) return false;
    const map = {};
    stringA = stringA.toLowerCase();
    stringB = stringB.toLowerCase();
    for (let index = 0; index < stringA.length; index++) {
        const element = stringA[index];
        if(element == ' ') continue;
        if(!map[element]){
            map[element] = 0;
        }
        map[element]++;
    }
    for (let index = 0; index < stringB.length; index++) {
        const element = stringB[index];
        if(!element) continue;
        if(!map[element]) return false;

        map[element]--;

        if(map[element] == 0){
            delete map[element];
        } 
    }
    return !Object.keys(map).length;
 }

 util.print(isAnagram('silent','listen'));
 util.print(isAnagram1('silent','listen'));
 util.print(isAnagram('Tom Marvolo Riddle','I am Lord Voldemort'));
 util.print(isAnagram1('Tom Marvolo Riddle','I am Lord Voldemort'));