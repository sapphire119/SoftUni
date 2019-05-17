function attachEvents() {
    //Valid information for dates "23-11", "24-11", "25-11", "26-11" and "27-11", in this exact format.
    // Use these to test your solution (no validation is required).

    let api_key = "kid_BJ_Ke8hZg";

    function userCredentials(jqXHR) {
        jqXHR.setRequestHeader("Authorization", "Basic " + btoa("guest" + ":" + "pass"));
    }

    let $getVenues = $("#getVenues");

    $getVenues.on("click", getVenuesEvent);

    async function getVenuesEvent(e) {
        let $venueDate = $("#venueDate");

        let url = `https://baas.kinvey.com/rpc/kid_BJ_Ke8hZg/custom/calendar?query=${$venueDate.val()}`;

        try {
            let ids = await $.post({
                beforeSend: userCredentials,
                url
            });

            let venues = [];

            for (const id of ids) {
                let venue = await $.get({
                    beforeSend: userCredentials,
                    url: `https://baas.kinvey.com/appdata/kid_BJ_Ke8hZg/venues/${id}`
                });
                venues.push(venue);
            }

            let htmlTemplate = await $.get("./templates/venue.html");

            displayVenues(venues, htmlTemplate);

            clearField($venueDate);
        } catch (e) {

        }
    }

    function displayVenues(venues, htmlTemplate) {
        let $venueInfo = $("#venue-info");
        $venueInfo.empty();
        for (const venue of venues) {
            let templateToDisplay = htmlTemplate
                .replace("{venue._id}", venue["_id"])
                .replace("{venue.name}", venue["name"])
                .replace("{venue.price}", venue["price"])
                .replace("{venue.description}", venue["description"])
                .replace("{venue.startingHour}", venue["startingHour"]);

            let $template = $(templateToDisplay);
            let $infoButton = $template.find("input.info");
            $infoButton.on("click", (e) => {
                let $currentVenueDetails = $(`#${venue["_id"]} > div.venue-details`);
                $currentVenueDetails.toggle();
            });

            let $quantitySelect = $template.find("select.quantity");
            let $purchaseBtn = $template.find(`input.purchase`);
            $purchaseBtn.on("click", e => loadPurchasePageTemplate(e, venue, $quantitySelect));
            // $purchaseBtn.on("click", e => console.log(e.target));

            $venueInfo.append($template);
        }
    }

    async function loadPurchasePageTemplate(e, venue, $quantitySelect) {
        let htmlTemplate = await $.get("./templates/confirmation.html");

        let totalSum = Number($quantitySelect.val()) * Number(venue["price"]);
        let quantity = $quantitySelect.val();

        let displayTemplate = htmlTemplate.replace("{name}", venue["name"])
            .replace("{qty}", quantity)
            .replace("{price}", venue["price"])
            .replace("{qty * price}",totalSum);

        displayConfirmationPage(displayTemplate, venue["_id"], quantity);
    }

    function displayConfirmationPage(displayTemplate, id, quantity) {
        let $venueInfo = $("#venue-info");
        $venueInfo.empty();
        $venueInfo.append(displayTemplate);

        let $confirmBtn = $("div.purchase-info > input");
        $confirmBtn.on("click", e => confirmPurchaseEvent(e, id, quantity))
    }

    async function confirmPurchaseEvent(e, id, quantity) {
        let url = `https://baas.kinvey.com/rpc/kid_BJ_Ke8hZg/custom/purchase?venue=${id}&qty=${quantity}`;

        let htmlTemplateObj = await $.post({
            beforeSend: userCredentials,
            url
        });

        let $venueInfo = $("#venue-info");
        $venueInfo.empty();
        $venueInfo.append(document.createTextNode("You may print this page as your ticket"));
        $venueInfo.append(htmlTemplateObj["html"]);
    }

    function clearField($field) {
        $field.val("");
    }
}