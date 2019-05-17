function greatestCD() {
    let num1Input = document.getElementById('num1');
    let num1 = Number(num1Input.value);

    let num2Input = document.getElementById('num2');
    let num2 = Number(num2Input.value);

    debugger;
    let gcd = function gcd(a,b) {
        debugger;
        a = Math.abs(a);
        b = Math.abs(b);
        if (b > a) {
            let temp = a;
            a = b;
            b = temp;
        }

        while (true) {
            if (b === 0) return a;
            let wat = a % b;
            // a %= b;
            a = wat;
            if (a === 0) return b;
            let wat2 = b % a;
            b = wat2;
            // b %= a;
        }
    };

    let greatestDivisor = gcd(num1, num2);

    let output = document.getElementById('result');

    output.innerHTML = `${greatestDivisor}`;
    // debugger;
    // if (isNaN(num1) || isNaN(num2)){
    //     return;
    // }
    //
    // let divisorFactor = 0;
    //
    // let greatestDivisor = 0;
    //
    // let maxValue = Math.max(num1, num2);
    // let minValue = Math.min(num1, num2);
    //
    // debugger;
    // while(minValue <= 1){
    //     minValue *= 10;
    //     maxValue *= 10;
    //     divisorFactor++;
    // }
    //
    // debugger;
    // if (minValue === 0){
    //     return;
    // }
    //
    // for (let i = 1; i <= minValue; i++) {
    //     if (maxValue % i === 0 && minValue % i === 0){
    //         greatestDivisor = i;
    //     }
    // }
    //
    // if (divisorFactor > 0) greatestDivisor /= (divisorFactor * 10);
}