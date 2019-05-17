function attachEvents() {
    let api_key = "kid_SyXblLA_V";

    function userCredentials(jqXHR) {
        jqXHR.setRequestHeader("Authorization", "Basic " + btoa("guest" + ":" + "guest"));
    }

    let $catches = $("#catches");

    let $addBtn = $("button.add");
    $addBtn.on("click", () => {
        let url = `https://baas.kinvey.com/appdata/${api_key}/biggestCatches`;

        let $angler = $("#addForm input.angler");
        let $weight = $("#addForm input.weight");
        let $species = $("#addForm input.species");
        let $location = $("#addForm input.location");
        let $bait = $("#addForm input.bait");
        let $captureTime = $("#addForm input.captureTime");

        let inputCatchObj = {
            angler: $angler.val(),
            weight: Number($weight.val()),
            species: $species.val(),
            location: $location.val(),
            bait: $bait.val(),
            captureTime: Number($captureTime.val())
        };

        let createPromise = $.post({
            beforeSend: userCredentials,
            url,
            contentType: "application/json",
            data: JSON.stringify(inputCatchObj)
        });

        createPromise.then(catchOfTheDay => displayCatches([catchOfTheDay]));
    });

    let $loadBtn = $("button.load");
    $loadBtn.on("click", () => {
        let url = `https://baas.kinvey.com/appdata/${api_key}/biggestCatches`;

        let loadPromise = $.get({
            beforeSend: userCredentials,
            url
        });

        loadPromise
            .then(data => {
                $catches.empty();
                return data;
            })
            .then(data => displayCatches(data));
    });

    function updateCatch(e, id) {
        let url = `https://baas.kinvey.com/appdata/${api_key}/biggestCatches/${id}`;

        let [angler, weight, species, location, bait, captureTime] = $(`div[data-id='${id}'] input`);

        let changedCatch = {
            angler: $(angler).val(),
            weight: $(weight).val(),
            species: $(species).val(),
            location: $(location).val(),
            bait: $(bait).val(),
            captureTime: $(captureTime).val()
        };

        $.ajax({
            beforeSend: userCredentials,
            method: "PUT",
            url,
            contentType: "application/json",
            data: JSON.stringify(changedCatch),
        });
    }

    function deleteCatch(e, id) {
        let url = `https://baas.kinvey.com/appdata/${api_key}/biggestCatches/${id}`;

        let $currentCatch = $(`div[data-id='${id}']`);

        $.ajax({
            beforeSend: userCredentials,
            method: "DELETE",
            url,
            success: $currentCatch.remove()
        })
    }

    function displayCatches(catches) {
        Object.values(catches).forEach(currentCatch => {
            let $catchDiv = $(`<div class='catch' data-id='${currentCatch["_id"]}'>`)
                .append($("<label>Angler</label>"))
                .append($(`<input type='text' class='angler' value='${currentCatch["angler"]}'>`))
                .append($(`<label>Weight</label>`))
                .append($(`<input type='text' class='weight' value='${currentCatch["weight"]}'>`))
                .append($(`<label>Species</label>`))
                .append($(`<input type='text' class='species' value='${currentCatch["species"]}'>`))
                .append($(`<label>Location</label>`))
                .append($(`<input type='text' class='location' value='${currentCatch["location"]}'>`))
                .append($(`<label>Bait</label>`))
                .append($(`<input type='text' class='bait' value='${currentCatch["bait"]}'>`))
                .append($(`<label>Capture Time</label>`))
                .append($(`<input type='text' class='captureTime' value='${currentCatch["captureTime"]}'>`));

            $catchDiv.append($("<button class='update'>Update</button>").on("click", e => updateCatch(e, currentCatch["_id"])));
            $catchDiv.append($("<button class='delete'>Delete</button>").on("click",e => deleteCatch(e, currentCatch["_id"])));

            $catches.append($catchDiv);
        });
    }
}