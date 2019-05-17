function solve() {
    let buttons = Array.from(document.getElementsByTagName("button"));

    buttons.forEach(btn => {
        btn.addEventListener('click', e => e.preventDefault());
    });

    buttons.forEach(btn => {
        btn.addEventListener("click", clickEvent);
    });

    function clickEvent(event) {
        let currentButton = event.target;
        switch (currentButton.textContent) {
            case "Submit":
                submitFunc(currentButton);
                break;
            case "Search":
                searchFunc(currentButton);
                break;
        }
    }

    function submitFunc(currentButton) {
        let userInfoTag = Array.from(document.getElementsByClassName("user-info"))[0];
        let userInfoInputs = Array.from(userInfoTag.children)
            .filter(e => e.localName === "input");

        let userInfoInputValues = userInfoInputs.map(e => e.value);

        let topcisTag = Array.from(document.getElementsByClassName("topics"))[0];
        let checkedTopics = Array.from(topcisTag.children)
            .filter(e => e.localName === "input")
            .filter(e => e.checked);

        let checkedTopicsValues = checkedTopics
            .map(e => e.value)
            .join(" ");

        let currentUser = {
            username: userInfoInputValues[0],
            email: userInfoInputValues[2],
            topics: checkedTopicsValues
        };

        let tr = document.createElement("tr");
        for (let property in currentUser) {
            let td = document.createElement("td");
            td.innerHTML = currentUser[property];
            tr.appendChild(td);
        }

        Array.from(document.getElementsByTagName("tbody"))[0].appendChild(tr);

        // userInfoInputs.forEach(inp => {
        //     inp.value = "";
        // });
        //
        // checkedTopics.forEach(inp => {
        //     inp.checked = false;
        // })
    }

    function searchFunc(currentButton) {
        let element = currentButton.previousElementSibling;

        let searchedValue = element.value;
        debugger;

        let tbodyTag = Array.from(document.getElementsByTagName("tbody"))[0];
        let rows = Array.from(tbodyTag.children);
        rows.forEach(row => {
            let rowValues = Array.from(row.children).map(e => e.innerHTML).join(" ");
            if (rowValues.includes(searchedValue)) {
                row.style.visibility = "visible";
            } else {
                row.style.visibility = "hidden";
            }
        });
        // element.value = "";
    }
}