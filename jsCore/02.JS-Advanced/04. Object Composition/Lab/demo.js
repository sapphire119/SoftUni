function Person(name, age) {
    this.name = name;
    this.age = age;
}

Person.prototype.talk = function () {
    return `Hello I am ${this.name} and I am ${this.age} years old`;
};

function customNew(constructor, ...args) {
    let obj = {};

    Object.setPrototypeOf(obj, constructor.prototype);

    constructor.apply(obj, args);

    return obj;
}

let pesho = customNew(Person, "Pesho", 22);

console.log(pesho.talk());