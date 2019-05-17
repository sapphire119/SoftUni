function solve() {
    let button = document.getElementById('searchBtn')
        .addEventListener('click', clickEvent);

    function clickEvent(event) {
        let isMatch = false;
        let input = document.getElementById('searchField');

        let tableBody = document.querySelector("table tbody");
        let bodyChildren = Array.from(tableBody.children);

        bodyChildren.forEach((tr) => {
            tr.classList.remove('select');
        });

        for(let tr of bodyChildren){
            let rowElements = Array.from(tr.children);
            for(let elem of rowElements){
                let currentCellValue = elem.innerHTML.toLowerCase();
                if (input.value !== '' && currentCellValue.includes(input.value)){
                    isMatch = true;
                    break;
                }
            }
            if (isMatch) {
                tr.classList.add('select');
                isMatch = false;
            }
        }

        input.value = '';
    }
}