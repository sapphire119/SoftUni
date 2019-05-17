$(document).ready(async () => {
    // context;
    // template;
    // source;

    //{
    //         id: 1,
    //         name: "John",
    //         phoneNumber: "0847759632",
    //         email: "john@john.com"
    //     },

    let userPartial = await $.get("./userPartial.hbs");

    let userInfoPartial = await $.get("./userInfoPartial.hbs");

    console.log(userPartial);
    console.log(userInfoPartial);

    Handlebars.registerPartial("userInfoPartial", userInfoPartial);

    let template = Handlebars.compile(userPartial);

    let context = {
        people: contacts
    };

    let parsedHtml = template(context);
    console.log(parsedHtml);
    $(".contacts").html(parsedHtml);
});

function showDetails(id) {
    $(`#${id}`).toggle();
}