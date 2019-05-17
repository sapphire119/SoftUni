function attachEvents() {
    $("#btnLoadTowns").on("click", loadTownEvent);

    async function loadTownEvent(e) {
        let $towns = $("#towns");
        let $root = $("#root");

        let townsArr = $towns.val().split(", ");

        let townSource = await $.get("./townTemplate.hbs");

        let template = Handlebars.compile(townSource);

        for (const town of townsArr) {
            let context = { name: town };
            let parsedHtml = template(context);
            $root.append(parsedHtml);
        }

        $towns.val("");
    }
}