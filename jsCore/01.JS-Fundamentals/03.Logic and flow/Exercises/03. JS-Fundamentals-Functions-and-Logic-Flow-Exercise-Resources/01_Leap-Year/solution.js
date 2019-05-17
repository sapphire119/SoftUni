function leapYear() {
    debugger;
    let button = document.querySelector('#main #exercise button');

    button.addEventListener('click', clickEvent);

    function clickEvent(event){
        debugger;
        let input = document.getElementsByTagName('input')[0];
        let inputNumber = Number(input.value);

        let isLeapYear = (year) => new Date(year, 1, 29).getDate() === 29;

        let divYear = document.getElementById('year');
        divYear.children[0].innerHTML = `${isLeapYear(inputNumber) ? "Leap Year" : "Not Leap Year"}`;
        divYear.children[1].innerHTML = `${inputNumber}`;

        input.value = '';
    }
}