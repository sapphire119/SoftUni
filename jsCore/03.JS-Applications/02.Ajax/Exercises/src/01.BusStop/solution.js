function getInfo() {
    //TODO: The web host will respond with valid data to IDs 1287, 1308, 1327 and 2334.
    let stopId = $("#stopId").val();
    let url = `https://judgetests.firebaseio.com/businfo/${stopId}.json `;

    let $stopName = $("#stopName");
    let $buses = $("#buses");

    $.ajax({
        method: "GET",
        url,
        success: onBusLoadSuccess,
        error: onNoBusesInAPIError
    });

    function onBusLoadSuccess(args) {
        $stopName.empty();
        $buses.empty();
        $stopName.text(args.name);
        let busAndArrivalTime = args["buses"];
        Object.keys(busAndArrivalTime).forEach(key => {
           let $li = $("<li>")
               .text(`Bus ${key} arrives in ${busAndArrivalTime[key]} minutes`);

           $buses.append($li);
        });
    }

    function onNoBusesInAPIError() {
        $stopName.empty();
        $buses.empty();
        $stopName.text("Error");
    }
}