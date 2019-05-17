function search() {
    $("#towns li").css("font-weight", "normal");

    let searchVal = $("#searchText").val();

    let foundTowns = $(`#towns li:contains("${searchVal}")`).css("font-weight", "bold");

    $("#result").text(`${foundTowns.length} matches found.`);
}