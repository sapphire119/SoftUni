function solve(inputArr) {
    let module = (function () {
        let objs = {};
        return{
            create: function(args) {
                objs[args[0]] = {};
                if (args[1] === "inherit"){
                    Object.setPrototypeOf(objs[args[0]], objs[args[2]]);
                }
            },
            set: (args) => objs[args[0]][args[1]] = args[2],
            print: (args) => {
                let output = [];
                for (let property in objs[args[0]]) {
                    output.push(`${property}:${objs[args[0]][property]}`);
                }

                console.log(output.join(", "));
            }
        }
    })();

    for (let line of inputArr) {
        let [command, ...args] = line.split(" ");
        module[command](args);
    }
}

solve(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2']
);