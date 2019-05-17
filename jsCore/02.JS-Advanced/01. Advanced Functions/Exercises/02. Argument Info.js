function solve() {
    let obj = {};
    for (let i = 0; i < arguments.length; i++) {
        let typeOfArgument = typeof arguments[i];
        let valueOfArgument = arguments[i];

        if (!obj.hasOwnProperty(typeOfArgument)) {
            obj[typeOfArgument] = 1;
        } else {
            obj[typeOfArgument]++;
        }

        console.log(`${typeOfArgument}: ${valueOfArgument}`);
    }

    Object.keys(obj)
        .sort((a, b) => obj[b] - obj[a])
        .forEach(key => {
            console.log(`${key} = ${obj[key]}`);
        });
}

solve('cat', 42, 21, 12, function () {
    console.log('Hello world!');
}, true, true);