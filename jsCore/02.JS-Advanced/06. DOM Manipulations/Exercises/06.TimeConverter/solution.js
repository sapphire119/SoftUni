function attachEventsListeners() {
    $(":button").on('click', clickEvent);

    function clickEvent(e) {
        let currentButtonId = e.target.id.substr(0, e.target.id.length - 3);

        let $inputValToTake = $(`#${currentButtonId}`);

        let $fieldsToConvert = $(":text").filter((_, e) => e.id !== currentButtonId);

        switch (currentButtonId) {
            case "days": convertFromDays($inputValToTake, $fieldsToConvert); break;
            case "hours": convertFromHours($inputValToTake, $fieldsToConvert); break;
            case "minutes": convertFromMinutes($inputValToTake, $fieldsToConvert); break;
            case "seconds": convertFromSeconds($inputValToTake, $fieldsToConvert); break;
        }

        function convertFromDays($inputValToTake, $fieldsToConvert) {
            let value = Number($inputValToTake.val());

            let hours = $($fieldsToConvert[0]);
            hours.val(value * 24);

            let minutes = $($fieldsToConvert[1]);
            minutes.val(value * 24 * 60);

            let seconds = $($fieldsToConvert[2]);
            seconds.val(value * 24 * 60 * 60);
        }

        function convertFromHours($inputValToTake, $fieldsToConvert) {
            let value = Number($inputValToTake.val());

            let days = $($fieldsToConvert[0]);
            days.val(value / 24);

            let minutes = $($fieldsToConvert[1]);
            minutes.val(value * 60);

            let seconds = $($fieldsToConvert[2]);
            seconds.val(value * 60 * 60);
        }

        function convertFromMinutes($inputValToTake, $fieldsToConvert) {
            let value = Number($inputValToTake.val());

            let days = $($fieldsToConvert[0]);
            days.val(value / (24 * 60));

            let hours = $($fieldsToConvert[1]);
            hours.val(value / 60);

            let seconds = $($fieldsToConvert[2]);
            seconds.val(value * 60);
        }

        function convertFromSeconds($inputValToTake, $fieldsToConvert) {
            let value = Number($inputValToTake.val());

            let days = $($fieldsToConvert[0]);
            days.val(value / (24 * 60 * 60));

            let hours = $($fieldsToConvert[1]);
            hours.val(value / (60 * 60));

            let minutes = $($fieldsToConvert[2]);
            minutes.val(value / 60);
        }
    }
}