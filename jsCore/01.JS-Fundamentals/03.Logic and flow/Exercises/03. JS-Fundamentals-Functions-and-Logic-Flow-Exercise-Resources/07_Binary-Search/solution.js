function binarySearch() {
    debugger;
    let arrInput = document.getElementById('arr');
    let array = JSON.parse("[" + arrInput.value + "]");
    let elementsN = array.length - 1;

    let numInput = document.getElementById('num');
    let number = Number(numInput.value);

    function binary_search(array, number){
        debugger;
        let leftSideOfArrayIndex = 0;
        let rightSideOfArrayIndex = array.length - 1;

        while (leftSideOfArrayIndex <= rightSideOfArrayIndex){
            let middleOfArrayIndex = Math.floor((leftSideOfArrayIndex + rightSideOfArrayIndex) / 2);

            if (array[middleOfArrayIndex] < number){
                leftSideOfArrayIndex = middleOfArrayIndex + 1;
            } else if (array[middleOfArrayIndex] > number){
                rightSideOfArrayIndex = middleOfArrayIndex - 1;
            } else{
                return `Found ${number} at index ${middleOfArrayIndex}`;
            }
        }
        return `${number} is not in the array`;
    }

    let output = document.getElementById('result');
    let result = binary_search(array, number);
    output.textContent = result;
}