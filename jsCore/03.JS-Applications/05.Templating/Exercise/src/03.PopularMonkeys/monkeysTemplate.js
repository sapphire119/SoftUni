$(async () => {
    //load Source
    let moneyTempSource = await $.get("./templates/monkeyTemp.hbs");
    //compile
    let template = Handlebars.compile(moneyTempSource); // func
    //context
    let context = {
        monkeys
    };
    let parsedHtml = template(context);
    //append
    $(".monkeys").append(parsedHtml);
});

function showDetails(id) {
    $(`#${id}`).toggle();
}