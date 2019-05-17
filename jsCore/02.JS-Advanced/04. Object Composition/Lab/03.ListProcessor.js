function solve(inputArr) {
    let module = (function () {
        let strs = [];
        return {
            add: (str) => {
                strs.push(str);
            },
            remove: (str) => {
                strs = strs.filter(e => e !== str);
            },
            print: () => console.log(strs.join(","))
        }
    })();

    for (let element of inputArr) {
        let [command, value] = element.split(" ");
        module[command](value);
    }
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
solve(['add pesho', 'add gosho', 'add pesho', 'remove pesho', 'print']);