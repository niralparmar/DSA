var util = require('../util');
function Node(value) {
    this.value = value;
    this.next = null;
}

function LList() {
    this.head = null;
    this.tail = null;
    this.insert = insert;
    this.printList = printList;
    this.find = find;
}

function find(value) {
    var currentHead = this.head;
    while (currentHead != null) {

        if (currentHead.value == value) return currentHead;

        currentHead = currentHead.next;
    }
    return null;
}

function insert(value) {
    if (!this.head) {
        var newNode = new Node(value);
        this.head = newNode;
        this.tail = newNode;
    }
    else{
        var newNode = new Node(value);
        this.tail.next = newNode; 
        this.tail = newNode;
    }
}

function printList() {
    var currentHead = this.head;
    var values = '';
    while (currentHead != null) {

        values = values + currentHead.value;
        if(currentHead.next)values = values + '->';

        currentHead = currentHead.next;
    }
    return values;
}

var list = new LList();
list.insert('1');
list.insert('2');
list.insert('3');
util.print(list.printList());