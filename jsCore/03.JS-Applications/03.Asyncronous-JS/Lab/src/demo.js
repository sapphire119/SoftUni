const  promise1 = new Promise((resolve, reject) => {
    // reject(123);
   resolve(123);
});

let test = Promise.resolve(promise1);
test
    .then((data) => {
        console.log("data");
    })
    .catch(error => console.log(error));

// const promise2 = new Promise((resolve, reject) => {
//     // reject("pesho");
//     resolve("pesho");
// });
//
// Promise.all([promise1, promise2])
//     .then((resolveArgs) => {
//         console.log(resolveArgs);
//         console.log(`${resolveArgs[0]} people with the names ${resolveArgs[1]}`);
//     })
//     .catch(error => console.log(error));