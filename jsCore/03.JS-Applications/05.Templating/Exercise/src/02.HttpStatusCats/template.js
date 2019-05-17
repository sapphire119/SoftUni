$(async () => {
    try {
        let catsTemplateSource = await $.get("./templates/catTemplate.hbs");

        let template = Handlebars.compile(catsTemplateSource);

        let context = {
            cats
        };

        let parsedHtml = template(context);

        $("#allCats").append(parsedHtml);
    } catch (e) {
        console.log(e);
    }
});

function showDetails(e, id) {
    let $div = $(`#${id}`);
    $div.is(":visible") === true ?
        $(e.target).text(`Show status code`) : $(e.target).text(`Hide status code`);
    $div.toggle();
}
