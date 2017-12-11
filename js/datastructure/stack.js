var util = require('../util');
function Stack() {
    this.dataStore = [];
    this.top = 0;
    this.push = push;
    this.pop = pop;
    this.peek = peek;
    this.clear = clear;
    this.length = length;
}

function push(element) {
    this.dataStore[this.top++] = element;
}

function peek() {
    return this.dataStore[this.top - 1];
}

function pop() {
    return this.dataStore[--this.top];
}

function clear() {
    this.top = 0;
}

function length() {
    return this.top;
}
var s = new Stack();
s.push("David");
s.push("Raymond");
s.push("Bryan");
util.print("length: " + s.length());
util.print(s.peek());
var popped = s.pop();
util.print("The popped element is: " + popped);
util.print(s.peek());
s.push("Cynthia");
util.print(s.peek());
s.clear();
util.print("length: " + s.length());
util.print(s.peek());
s.push("Clayton");
util.print(s.peek());