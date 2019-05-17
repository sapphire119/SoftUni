function solve() {
    let disableButton = ($buttonToDisable, $buttonToEnable) => {
        $buttonToDisable.prop("disabled", true);
        if ($buttonToEnable) {
            $buttonToEnable.prop("disabled", false);
        }
    };

    let $depart = $("#depart");
    let $arrive = $("#arrive");
    let $info = $("span.info");

    let currentStopId = "depot";
    let currentStopName = "";

    function depart() {
        debugger;
        let url = `https://judgetests.firebaseio.com/schedule/${currentStopId}.json`;
        $.ajax({
            method: "GET",
            url,
            success: onStopLoadSuccess,
            error: onStopError
        });

        function onStopLoadSuccess(currentBusStop) {
            debugger;
            disableButton($depart, $arrive);
            currentStopName = currentBusStop["name"];
            $info.text(`Next stop ${currentStopName}`);
            currentStopId = currentBusStop["next"];
        }

        function onStopError(args) {
            disableButton($arrive);
            disableButton($depart);
            $info.text(`Error`);
        }
    }

    function arrive() {
        //Arriving at {stopName}
        disableButton($arrive, $depart);
        $info.text(`Arriving at ${currentStopName}`);
    }

    return {
        depart,
        arrive
    };
}