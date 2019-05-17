$(document).ready(async () => {
    const people = [
        {
            id: 1,
            name: "John",
            phoneNumber: "0847759632",
            email: "john@john.com",
            grades: [1, 2, 3, 4, 5]
        },
        {
            id: 2,
            name: "Merrie",
            phoneNumber: "0845996111",
            email: "merrie@merrie.com",
            grades: [1, 2, 3, 4, 5]
        },
        {
            id: 3,
            name: "Adam",
            phoneNumber: "0866592475",
            email: "adam@stamat.com",
            grades: [1, 2, 3, 4, 5]
        },
        {
            id: 4,
            name: "Peter",
            phoneNumber: "0866592475",
            email: "peter@peter.com",
            grades: [1, 2, 3, 4, 5]
        },
        {
            id: 5,
            name: "Max",
            phoneNumber: "0866592475",
            email: "max@max.com",
            grades: [1, 2, 3, 4, 5]
        },
        {
            id: 6,
            name: "David",
            phoneNumber: "0866592475",
            email: "david@david.com",
            grades: [1, 2, 3, 4, 5]
        }
    ];

    try {
        let demoTemplate = await $.get("./demoTemplate.hbs");
        let personPartial = await $.get("./personPartial.hbs");

        Handlebars.registerPartial("personPartial", personPartial);
        const template = Handlebars.compile(demoTemplate);

        let context = {
            people
        };

        let parsedHtml = template(context);
        $(".container").append(parsedHtml);

    } catch (e) {
        console.log(e.message);
    }
});