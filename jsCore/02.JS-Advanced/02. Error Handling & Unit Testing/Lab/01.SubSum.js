function subsum(arr, startIndex, endIndex) {
    if (!arr || !Array.isArray(arr)) return NaN;

    if (startIndex < 0) startIndex = 0;

    if (!arr[startIndex]) return 0;
    
    if (endIndex > arr.length - 1) endIndex = arr.length - 1;

    arr = arr.map(Number).slice();
    debugger;
    let result = arr.slice(startIndex, endIndex + 1).reduce((a, b) => a + b);
    return result;
}

console.log(subsum([10, 20, 30, 40, 50, 60], 3, 300));
console.log(subsum([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
console.log(subsum([10, 'twenty', 30, 40], 0, 2));
console.log(subsum([], 1, 2));
console.log(subsum('text', 0, 2));
