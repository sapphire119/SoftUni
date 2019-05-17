function solve() {
    debugger;
    let number = Number(document.getElementById('num').value);

    let output = document.getElementById('result');

    const factors = number => Array
        .from(Array(number + 1), (_, i) => i)
        .filter(i => number % i === 0);

    let result = factors(number);

    output.textContent = result.join(" ");
}