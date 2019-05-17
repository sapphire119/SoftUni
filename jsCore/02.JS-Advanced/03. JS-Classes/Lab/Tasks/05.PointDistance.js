class Point{
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    static distance(point1, point2){
        let diffX = Math.abs(point1.x - point2.x);
        let diffY = Math.abs(point1.y - point2.y);

        let distance = Math.sqrt(Math.pow(diffX, 2) + Math.pow(diffY, 2));

        return distance;
    }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));