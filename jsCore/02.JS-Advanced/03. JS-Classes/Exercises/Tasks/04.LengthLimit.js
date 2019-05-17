class Stringer {
    constructor(innerString , innerLength) {
        this.innerString  = innerString;
        this.innerLength = innerLength;
    }
    increase(length){
        // if (isNaN(length)) return;
        this.innerLength += length;
    }

    decrease(length){
        // if (isNaN(length)) return;
        if (this.innerLength - length < 0) this.innerLength = 0;
        else this.innerLength -= length;
    }

    toString() {
        let output = "";
        let dots = "...";

        if (this.innerString.length > this.innerLength) {
            let temp = this.innerString.split("");
            while (temp.length > this.innerLength && temp !== "") temp.pop();
            output += `${temp.join("")}${dots}`;
            return output;
        }

        output = this.innerString;
        return output;
    }
}

let asd = "asd123";
let test1 = asd.substr(-1);

let test = new Stringer("Test", 5);
console.log(test.toString()); //Test

test.decrease(3);
console.log(test.toString()); //Te...

test.decrease(5);
console.log(test.toString()); //...

test.increase(4);
console.log(test.toString()); //Test
