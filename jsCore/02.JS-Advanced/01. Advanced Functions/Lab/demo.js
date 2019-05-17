function test() {
    let test2 = (function () {
        let index = 0;

        return () => {
            console.log(++index);
        }
    })();

    return test2;
}

const test1 = test();

test1();test1();test1();test1();test1();test1();