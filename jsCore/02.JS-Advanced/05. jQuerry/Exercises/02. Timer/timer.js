function timer() {
    $("#start-timer").click(startTimer);

    $("#stop-timer").click(stopTimer);
    let obj = {};

    let $seconds = $("#seconds");
    let $minutes = $("#minutes");
    let $hours = $("#hours");

    let isIntervalSet = false;

    function stopTimer() {
        isIntervalSet = false;
        clearInterval(obj.int);
    }

    function startTimer() {
        if (!isIntervalSet) {
            let interval = setInterval(function () {
                let secondsVal = Number($seconds.text());
                let minutesVal = Number($minutes.text());
                let hoursVal = Number($hours.text());

                debugger;
                secondsVal++;

                if (secondsVal >= 60) {
                    minutesVal += 1;
                    secondsVal = 0;
                }
                if (minutesVal >= 60) {
                    hoursVal += 1;
                    minutesVal = 0;
                }

                if (secondsVal < 10) {
                    debugger;
                    $seconds.text(`0${secondsVal}`);
                    debugger;
                } else {
                    debugger;
                    $seconds.text(secondsVal);
                }

                if (minutesVal < 10) {
                    $minutes.text(`0${minutesVal}`);
                } else {
                    $minutes.text(minutesVal);
                }

                if (hoursVal < 10) {
                    $hours.text(`0${hoursVal}`);
                } else {
                    $hours.text(hoursVal);
                }
            }, 1000);
            obj["int"] = interval;

            isIntervalSet = true;
        }
    }
}