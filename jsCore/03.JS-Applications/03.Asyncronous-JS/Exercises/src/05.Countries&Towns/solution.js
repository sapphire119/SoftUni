function attachEvents() {
    let api_key = "kid_HkXpygbF4";

    function userCredentials(jqXHR) {
        jqXHR.setRequestHeader("Authorization", "Basic " + btoa("guest" + ":" + "guest"));
    }

    let $btnLoadCountries = $("#btnLoadCountries");
    $btnLoadCountries.on("click", () => {
        let url = `https://baas.kinvey.com/appdata/${api_key}/Country`;

        let loadCountriesPromise = $.get({
            beforeSend: userCredentials,
            url
        });

        loadCountriesPromise.then(countries => displayCountries(countries, true));
    });

    let $btnCountryCreate = $("#btnCountryCreate");
    $btnCountryCreate.on("click", () => {
        let url = `https://baas.kinvey.com/appdata/${api_key}/Country`;

        let $country = $("#country");

        let countryObj = { name: $country.val()};

        $.post({
            beforeSend: userCredentials,
            url,
            contentType: "application/json",
            data: JSON.stringify(countryObj),
            success: country => {
                displayCountries([country]);
                alert(`Successfully created country: ${country["name"]}`);
                $country.val("");
            }
        })
    });

    function displayCountries(countries, emptyList = false) {
        let $countries = $("#countries");

        if (emptyList) {
            $countries.empty();
        }

        for (const country of countries) {
            let $li = $("<li>")
                .append($(`<input type='text' class='mb-2' value='${country["name"]}' id="${country["_id"]}">`))
                .append($("<button class=\"bg-success text-white rounded\">View</button>").on("click", e => viewSelectedCountryEvent(e, country)))
                .append($("<button class=\"bg-success text-white rounded\">Edit</button>").on("click", e => editEvent(e, country)))
                .append($("<button class=\"bg-success text-white rounded\">Delete</button>").on("click", e => deleteEvent(e, country)));

            $countries.append($li);
        }
    }

    function viewSelectedCountryEvent(e, currentCountry) {
        let url = `https://baas.kinvey.com/appdata/${api_key}/Town`;

        let loadTownsPromise = $.get({
            beforeSend: userCredentials,
            url
        });

        loadTownsPromise.then(data => displayTownsForCountry(currentCountry, data));
    }

    function displayTownsForCountry(currentCountry, allTowns) {
        let $loadedCountry = $("#loadedCountry");
        $loadedCountry.empty();

        $loadedCountry.append($(`<h1>${currentCountry["name"]}</h1>`))
            .append($("<h2>Towns</h2>"))
            .append($(`<ul id="currentCountry-towns"></ul>`))
            .append($("<h3>Add Town To Country</h3>"))
            .append($("<label for=\"createTown\" class=\"font-weight-bold\">Town</label>"))
            .append($("<input type=\"text\" id=\"createTown\">"))
            .append($("<button id='addTown' class='bg-success text-white rounded'>Add</button>")
                .on("click", e => createTownEvent(e, currentCountry)));

        let currentTownsForCountry = allTowns.filter(t => t["countryId"] === currentCountry["_id"]);

        displayTownsInList(currentTownsForCountry);
    }

    function displayTownsInList(filteredTowns) {
        let $currentCountryTown = $("#currentCountry-towns");
        for (const town of filteredTowns) {
            let $li = $("<li>")
                .append($(`<input type='text' class='mb-2' value='${town["name"]}' id="${town["_id"]}">`))
                .append($("<button class=\"bg-success text-white rounded\">Edit</button>").on("click", e => editEvent(e, town, true)))
                .append($("<button class=\"bg-success text-white rounded\">Delete</button>").on("click", e => deleteEvent(e, town, true)));

            $currentCountryTown.append($li);
        }
    }

    function createTownEvent(e, currentCountry) {
        let url = `https://baas.kinvey.com/appdata/${api_key}/Town`;

        let $town = $("#createTown");

        let townObj = {
            name: $town.val(),
            countryId: currentCountry["_id"]
        };

        $.post({
            beforeSend: userCredentials,
            url,
            contentType: "application/json",
            data: JSON.stringify(townObj),
            success: town => {
                displayTownsInList([town]);
                alert(`Successfully created Town: ${town["name"]} to Country: ${currentCountry["name"]}`);
                $town.val("");
            }
        })
    }

    async function deleteEvent(e, countryOrTown, isTown = false) {
        let url = "";
        isTown === false ? url = `https://baas.kinvey.com/appdata/${api_key}/Country/${countryOrTown["_id"]}` :
            url = `https://baas.kinvey.com/appdata/${api_key}/Town/${countryOrTown["_id"]}`;

        let deletedTowns = [];
        if (!isTown) {
            let townsUrl = `https://baas.kinvey.com/appdata/${api_key}/Town`;

            let towns = await $.get({
                beforeSend: userCredentials,
                url: townsUrl
            });

            let townsByCountry = towns.filter(t => t["countryId"] === countryOrTown["_id"]);

            for (const currentTown of townsByCountry) {
                let deleteUrl = `https://baas.kinvey.com/appdata/${api_key}/Town/${currentTown["_id"]}`;
                await $.ajax({
                    beforeSend: userCredentials,
                    method: "DELETE",
                    url: deleteUrl
                });

                deletedTowns.push(currentTown)
            }
        }

        try {
            let deleteResponse = await $.ajax({
                beforeSend: userCredentials,
                method: "DELETE",
                url
            });

            if (!isTown) {
                let message = `Successfully deleted Country with name: ${countryOrTown["name"]} and with ID: ${countryOrTown["_id"]}`;

                deletedTowns.length > 0 ?
                    message += ` and Towns: ${deletedTowns.map(e => e["name"]).join(", ")}` : "";

                $("#loadedCountry").empty();

                alert(message);
            } else {
                alert(`Successfully deleted Town with name: ${countryOrTown["name"]} and with ID: ${countryOrTown["_id"]}`);
            }

            $(`#${countryOrTown["_id"]}`).parent().remove();
        } catch (e) {
            console.error(e.message);
        }
    }

    function editEvent(e, countryOrTown, isTown = false) {
        let url = "";
        let entityVal = $(`#${countryOrTown["_id"]}`).val();

        let entity = {
            name: entityVal
        };

        if (isTown) {
            url = `https://baas.kinvey.com/appdata/${api_key}/Town/${countryOrTown["_id"]}`;
            entity["countryId"] = countryOrTown["countryId"];
        } else {
            url = `https://baas.kinvey.com/appdata/${api_key}/Country/${countryOrTown["_id"]}`;
        }

        $.ajax({
            beforeSend: userCredentials,
            method: "PUT",
            url,
            contentType: "application/json",
            data: JSON.stringify(entity),
            success: newEntity => alert(`Successfully changed value of ${countryOrTown["name"]} to ${newEntity["name"]}.\nReload the page so changes can take effect.`)
        });
    }
}