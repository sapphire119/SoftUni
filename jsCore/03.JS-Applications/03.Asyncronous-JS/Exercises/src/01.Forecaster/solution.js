function attachEvents() {
    //Valid data for location names "London", "New York" and "Barcelona".
    let weatherCondtions = {
        "Sunny": "&#x2600", // ☀
        "Partly sunny": "&#x26C5;", // ⛅
        "Overcast": "&#x2601;", // ☁
        "Rain": "&#x2614;", // ☂
        "Degrees": "&#176;"   // °
    };

    let $submit = $("#submit");

    let $location = $("#location");
    let $forecast = $("#forecast");

    let locationUrl = `https://judgetests.firebaseio.com/locations.json`;
    $submit.on("click", () => {
        $.get({url: locationUrl})
            .then((data) => displayWeather(data))
            .catch(displayError);
    });

    function displayWeather(locations) {
        let currentLocation = $location.val();
        let mappedLocation = Object.values(locations).find(val => val["name"] === currentLocation);
        if (mappedLocation) {
            let currentWeatherUrl = `https://judgetests.firebaseio.com/forecast/today/${mappedLocation["code"]}.json`;
            let threeDayWeatherUrl = `https://judgetests.firebaseio.com/forecast/upcoming/${mappedLocation["code"]}.json`;

            let currentWeatherPromise = $.get({url: currentWeatherUrl});
            let currentThreeDayPromise = $.get({url: threeDayWeatherUrl});

            Promise.all([currentWeatherPromise, currentThreeDayPromise])
                .then(displayForecasts)
                .catch(displayError);
        } else {
            displayError();
        }
    }

    function displayForecasts([normalForecast, threeDayForecast]) {
        // let normalForecast = forecasts[0];
        // let threeDayForecast = forecasts[1];

        $forecast.empty();
        $forecast.css('display', 'block');
        $forecast.append(`<div id="current">
            <div class="label">Current conditions</div>
        </div>
        <div id="upcoming">
            <div class="label">Three-day forecast</div>
        </div>`);

        displayNormalForecast(normalForecast);

        displayThreeDayForecast(threeDayForecast);
    }

    function displayNormalForecast(currentData) {
        let $current = $("#current");
        $current.empty();
        $current.append("<div class=\"label\">Current conditions</div>");

        let currentForecast = currentData["forecast"];

        let $spanConditionSymbol = $(`<span class='condition symbol'>${weatherCondtions[currentForecast["condition"]]}</span>`);

        let $spanCondition = $("<span class='condition'>");
        let $spanNameData = $(`<span class='forecast-data'>${currentData["name"]}</span>`);
        let $spanDegreesData =
            $(`<span class="forecast-data">${currentForecast["low"]}${weatherCondtions.Degrees}/${currentForecast["high"]}${weatherCondtions.Degrees}</span>`);

        let $spanConditionData = $(`<span class="forecast-data">${currentForecast["condition"]}</span>`);

        $spanCondition.append($spanNameData)
            .append($spanDegreesData)
            .append($spanConditionData);

        $current.append($spanConditionSymbol);
        $current.append($spanCondition);
    }

    function displayThreeDayForecast(currentData) {
        let $upcoming = $("#upcoming");
        $upcoming.empty();
        $upcoming.append("<div class=\"label\">Three-day forecast</div>");

        let forecasts = currentData["forecast"];
        for (const forecast of forecasts) {
            let $spanUpcoming = $(`<span class="upcoming"></span>`);
            let $symbolSpan = $(`<span class="symbol">${weatherCondtions[forecast["condition"]]}</span>`);
            let $degreesSpan = $(`<span class="forecast-data">${forecast["low"]}${weatherCondtions.Degrees}/${forecast["high"]}${weatherCondtions.Degrees}</span>`);
            let $nameData = $(`<span class="forecast-data">${forecast["condition"]}</span>`);

            $spanUpcoming.append($symbolSpan)
                .append($degreesSpan)
                .append($nameData);

            $upcoming.append($spanUpcoming);
        }
    }

    function displayError() {
        $forecast.css('display', 'block');
        // $forecast.empty();
        $forecast.text(`Error`);
    }
}