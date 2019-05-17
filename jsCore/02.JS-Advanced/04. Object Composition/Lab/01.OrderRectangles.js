function solve(inputArrArr) {
    // function Rectangle(width, height) {
    //     this.width = width;
    //     this.height = height;
    // }
    //
    // Rectangle.prototype.area = function () {
    //     return this.width * this.height;
    // };
    //
    // Rectangle.prototype.toString = function () {
    //     return `width:${this.width}, height:${this.height}, area:${typeof this.area}, compareTo:${typeof this.compareTo}`;
    // };
    //
    // Rectangle.prototype.compareTo = function (other) {
    //     let currentRectArea = this.area();
    //     let nextRectangleArea = other.area();
    //
    //     if (nextRectangleArea < currentRectArea) return -1;
    //     else if (nextRectangleArea > currentRectArea) return 1;
    //     else {
    //         if (other.width < this.width) return -1;
    //         else if (other.width > this.width) return 1;
    //         else return 0;
    //     }
    // };

    function comparator(w, h) {
        let rect = {
            width: w,
            height: h,
            area: () => rect.width * rect.height,
            compareTo: function (other) {
                let result = other.area() - rect.area();
                return result || (other.width - rect.width);
            }
        };

        return rect;
    }


    let rects = [];
    for (let [width, height] of inputArrArr) {
        let rect = comparator(width, height);
        rects.push(rect);
    }
    rects.sort((a, b) => a.compareTo(b));
    return rects;

    // let rectangles = [];
    // for (let i = 0; i < inputArrArr.length; i++) {
    //     let inputArr = inputArrArr[i];
    //     let width = inputArr[0];
    //     let height = inputArr[1];
    //     rectangles.push(new Rectangle(width, height));
    // }

    // rectangles.sort((a, b) => a.compareTo(b));
    // return rectangles;
}

console.log(solve([[10, 5], [5, 12]]));
// console.log(solve([[10, 5], [3, 20], [5, 12]]));