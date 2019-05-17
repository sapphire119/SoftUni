function solve(inputString){
    if(typeof(inputString) === 'number') {
        let inputNumber = Number(inputString);

        for(let i = 1; i <= inputNumber; i++){
            if(i % 2 == 0){
                console.log(i);
            }
        }
    }
}