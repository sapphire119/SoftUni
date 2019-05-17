class SortedList {
    constructor() {
        this.list = [];
        this.size = 0;
    }

    add(element){
        this.list.push(element);
        this._sortList();
        this._setSize();
    }

    remove(index){
        if (!this._indexInRange(index)) return;
        this.list.splice(index, 1);
        this._sortList();
        this._setSize();
    }

    get(index){
        if (!this._indexInRange(index)) return;
        return this.list[index];
    }

    // get size() {
    //     return this.list.length;
    // }

    _indexInRange(index){
        return 0 <= index && index < this.list.length;
    }

    _sortList(){
        this.list.sort((a, b) => a - b);
    }

    _setSize(){
        this.size = this.list.length;
    }
}

let test = new SortedList();
let asd = test.hasOwnProperty("size");
test.add(1);
test.add(2);
test.add(3);
test.add(4);
test.add(5);
test.add(6);

test.remove(-1);
// console.log(test.get(2));
console.log(test.size);