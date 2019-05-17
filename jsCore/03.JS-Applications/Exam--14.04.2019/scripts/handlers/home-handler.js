handlers.getHome = async function (ctx) {
    ctx.isAuth = userService.isAuth();
    ctx.username = sessionStorage.getItem('username');

    if (userService.isAuth()) {
        let currentEvents = await kinvey.get("appdata", `events`, "kinvey");
        let sortedEvents = currentEvents.slice().sort((a, b) => {
            return Number(b.peopleInterestedIn) - Number(a.peopleInterestedIn);
        });
        ctx.events = sortedEvents;
    } else {
        ctx.events = [];
    }
    ctx.anyEvents = ctx.events.length > 0;
    //getEvents()
    // ctx.name = "random";
    // ctx.imageURL = "https://upload.wikimedia.org/wikipedia/commons/6/69/June_odd-eyed-cat_cropped.jpg";

    ctx.loadPartials({
        header: './templates/common/header.hbs',
        footer: './templates/common/footer.hbs',
        eventPartial: './templates/events/partials/eventPartial.hbs',
        loggedHomeView: './templates/home/loggedHomeView.hbs',
        loggedOutHomeView: './templates/home/loggedOutHomeView.hbs',
    }).then(function () {
        this.partial('./templates/home/home.hbs');
    }).catch(function (err) {
        console.log(err);
    });
};