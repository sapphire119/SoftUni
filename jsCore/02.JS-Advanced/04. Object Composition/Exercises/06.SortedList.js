function solve() {
    function SortedList() {
        this.list = [];
        this.size = 0;
        this.add = function (element) {
            this.list.push(element);
            this._sortArray();
            this._setSize();
        };
        this.remove = function (index) {
            if (this._isInRange(index)) {
                this.list.splice(index, 1);
                this._sortArray();
                this._setSize();
            }
        };
        this.get = function (index) {
            if (this._isInRange(index)) {
                return this.list[index];
            }
        };
    }

    SortedList.prototype._isInRange = function(index){
        return 0 <= index && index < this.list.length;
    };

    SortedList.prototype._sortArray = function(){
        this.list.sort((a, b) => a - b);
    };

    SortedList.prototype._setSize = function () {
        this.size = this.list.length;
    };

    return new SortedList();
}

let result = solve();
let test1 = result.hasOwnProperty('add');
let test2 = result.hasOwnProperty('remove');
let test3 = result.hasOwnProperty('get');
// expect(result.hasOwnProperty('add')).to.equal(true, "Function add() was not found");
// expect(result.hasOwnProperty('remove')).to.equal(true, "Function remove() was not found");
// expect(result.hasOwnProperty('get')).to.equal(true, "Function get() was not found");

// Instantiate and test functionality
let myList = result;
let test = myList.hasOwnProperty('size');
// expect(myList.hasOwnProperty('size')).to.equal(true, "Property size was not found");

myList.add(5);
console.log(myList.get(0));
// expect(myList.get(0)).to.equal(5, "Element wasn't added");

myList.add(3);
console.log(myList.get(0));
// expect(myList.get(0)).to.equal(3, "Collection wasn't sorted");

myList.remove(0);
console.log(myList.get(0));
console.log(myList.size);
// expect(myList.get(0)).to.equal(5, "Element wasn't removed");
// expect(myList.size).to.equal(1, "Element wasn't removed");