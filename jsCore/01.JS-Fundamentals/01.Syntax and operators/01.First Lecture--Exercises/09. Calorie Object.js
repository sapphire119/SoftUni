function solve(inputArray){
    if(inputArray instanceof Array){
        let obj = {};
        for(let i = 0, j = 1; i < inputArray.length - 1 && j < inputArray.length; i+=2, j+=2){
            let element = inputArray[i];
            let value = +inputArray[j];
            obj[element] = value;       
        }

        console.log(obj);
    }
}