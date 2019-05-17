function initializeTable() {
    $("#createLink").on("click", addLinkToTable);
    let isInitialized = false;

    function addLinkToTable() {
        let countryText = $("#newCountryText").val();
        let capitalText = $("#newCapitalText").val();

        if (countryText !== "" && capitalText !== ""){
            addCountryAndCapitalToTable(countryText, capitalText);
        }
    }

    function addCountryAndCapitalToTable(countryText, capitalText) {
        let table = $("#countriesTable");

        let row = $("<tr>");
        let countryAndCapital = (`<td>${countryText}</td><td>${capitalText}</td>`);

        let actions = $("<td>")
            .append($("<a href='#'>[Up]</a>").click(moveUp))
            .append($("<a href='#'>[Down]</a>").click(moveDown))
            .append($("<a href='#'>[Delete]</a>").click(deleteRow));

        row.append(countryAndCapital, actions);
        table.append(row);
        if (isInitialized) {
            fixLinks();
        }
    }

    function moveUp(event) {
        let parent = $(event.target).parent().parent();
        parent.insertBefore(parent.prev());

        fixLinks();
    }

    function moveDown(event) {
        let parent = $(event.target).parent().parent();
        parent.insertAfter(parent.next());

        fixLinks();
    }

    function deleteRow(event) {
        let parent = $(event.target).parent().parent();
        parent.remove();

        fixLinks();
    }

    function fixLinks() {
        $('tr').children().children().show();

        $('tr:nth-child(3)').children().eq(2).children().eq(0).hide();
        $('tr:last-child').children().eq(2).children().eq(1).hide();
    }

    addCountryAndCapitalToTable("Bulgaria", "Sofia");
    addCountryAndCapitalToTable("Germany", "Berlin");
    addCountryAndCapitalToTable("Russia", "Moscow");
    isInitialized = true;

    fixLinks();
}