function solve() {
    function convertToCase(arrInput, wordCase) {
        debugger;
        let result = "";
        if (wordCase === 'Camel'){
            result = arrInput.map(e => e.charAt(0).toUpperCase().concat(e.substring(1).toLowerCase())).join("");
            result = result.charAt(0).toLowerCase().concat(result.substring(1));
        } else if(wordCase === 'Pascal'){
            result = arrInput.map(e => e.charAt(0).toUpperCase().concat(e.substring(1).toLowerCase())).join("");
        } else{
            result = 'Error!';
        }
        return result;
    }

    debugger;

    let str1Input = document.getElementById('str1');
    let str1InputValue = str1Input.value.toString().split(' ');

    let str2Input = document.getElementById('str2');
    let str2InputValue = str2Input.value.toString().split(' ')[0];

    let result = convertToCase(str1InputValue, str2InputValue);

    let output = document.getElementById('result');
    output.innerHTML = result;
}