function result() {
    let obj = {};
    obj.extend = function(template) {
        Object.keys(template).forEach(key => {
            if (typeof template[key] === "function") {
                let currentPrototype = Object.getPrototypeOf(this);
                currentPrototype[key] = template[key];
            } else {
                this[key] = template[key];
            }
        });

        return this;
    };

    return obj;
}

let template = {
    extensionMethod: function () {
        console.log("From extension method")
    }
};

let testObject = result();
testObject.extend(template);
debugger;