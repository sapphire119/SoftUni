let Extensible = (function () {
    let id = 0;
    return class Extensible {
        constructor() {
            this.id = id++;
        }

        extend(template){
            for (let propertyName in template) {
                if (template[propertyName] instanceof Function){
                    Extensible.prototype[propertyName] = template[propertyName];
                } else {
                    this[propertyName] = template[propertyName];
                }
            }
        }
    }
})();
let template = {
    methodA: function () {
        return 'a';
    }
};

let obj1 = new Extensible();
let obj2 = new Extensible();

obj1.extend(template);
debugger;
// expect(obj1.methodA()).to.equal('a', "Property wasn't copied correctly.");
// expect(obj2.methodA()).to.equal('a', "Property wasn't copied correctly.");