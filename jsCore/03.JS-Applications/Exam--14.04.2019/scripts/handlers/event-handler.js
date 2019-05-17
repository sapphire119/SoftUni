handlers.getCreateEvent = function (ctx) {
    ctx.isAuth = userService.isAuth();
    ctx.username = sessionStorage.getItem('username');

    ctx.loadPartials({
        header: './templates/common/header.hbs',
        footer: './templates/common/footer.hbs'
    }).then(function () {
        this.partial('./templates/events/create.hbs');
    }).catch(function (err) {
        console.log(err);
    });
};

handlers.postCreateEvent = function (ctx) {
    let name = ctx.params.name;
    if (name.length < 6) {
        notifications.showError("Event name should be at least 6 characters long.");
        return;
    }
    let dateTime = ctx.params.dateTime;

    let description = ctx.params.description;
    if (description.length < 10) {
        notifications.showError("Description length should be at least 10 characters");
        return;
    }

    let imageURL = ctx.params.imageURL;
    if (!imageURL.startsWith("http://") && !imageURL.startsWith("https://")){
        notifications.showError("Image URL is not valid");
        return;
    }

    let organizer = sessionStorage.getItem('username');


    // let username = ctx.params.username;
    // let password = ctx.params.password;
    // let repeatPassword = ctx.params.rePassword;
    // if (repeatPassword !== password) {
    //     notifications.showError('Passwords must match');
    //     return;
    // }
    eventService.createEvent(name, description, imageURL, dateTime, organizer)
        .then((res) => {
            notifications.showSuccess("Event created successfully.");
            ctx.redirect("#/home");
        })
        .catch(err => {
            notifications.showError(err.responseJSON.description);
        });
    // userService.register(username, password).then((res) => {
    //     userService.saveSession(res);
    //     notifications.showSuccess('User registered successfully');
    //     context.redirect('#/home');
    // }).catch(function (err) {
    //     notifications.showError(err.responseJSON.description);
    // });
};

handlers.getDetailsEvent = async function (ctx) {
    ctx.isAuth = userService.isAuth();
    ctx.username = sessionStorage.getItem('username');

    let currentEventId = ctx.params.id;
    //{"_acl.creator":"${user_id}"}
    let currentEvents = await kinvey.get("appdata", `events?query={"_id":"${currentEventId}"}`, "kinvey");
    let currentEvent = currentEvents[0];

    ctx.event = currentEvent;
    ctx.isCreator = currentEvent.organizer === ctx.username;

    ctx.loadPartials({
        header: './templates/common/header.hbs',
        footer: './templates/common/footer.hbs',

    }).then(function () {
        this.partial('./templates/events/details.hbs');
    }).catch(function (err) {
        console.log(err);
    });
};

handlers.getEditEvent = async function (ctx) {
    ctx.isAuth = userService.isAuth();
    ctx.username = sessionStorage.getItem('username');

    let currentEventId = ctx.params.id;
    let currentEvents = await kinvey.get("appdata", `events?query={"_id":"${currentEventId}"}`, "kinvey");
    let currentEvent = currentEvents[0];

    ctx.event = currentEvent;

    ctx.loadPartials({
        header: './templates/common/header.hbs',
        footer: './templates/common/footer.hbs',
    }).then(function () {
        this.partial('./templates/events/edit.hbs');
    }).catch(function (err) {
        console.log(err);
    });
};

handlers.postEditEvent = function (ctx) {

    let name = ctx.params.name;
    let dateTime = ctx.params.dateTime;

    debugger;
    // if (dateTime.)

    let description = ctx.params.description;
    let _id = ctx.params.id;
    let imageURL = ctx.params.imageURL;
    let organizer = ctx.params.organizer;
    let peopleInterestedIn = ctx.params.peopleInterestedIn;

    //dateTime: "12 April - 4PM"
    // description: "Random cats"
    // id: "5cb2e7165c9d444b2f7243b2"
    // imageURL: "https://upload.wikimedia.org/wikipedia/commons/6/69/June_odd-eyed-cat_cropped.jpg"
    // name: "Cat"
    // organizer: "pesho"
    // peopleInterestedIn: "0"
    eventService.updateEvent(dateTime, description, _id, imageURL, name, organizer, peopleInterestedIn)
        .then((res) => {
            notifications.showSuccess("Event edited successfully.");
            ctx.redirect("#/home");
        })
        .catch(err => {
            notifications.showError(err.responseJSON.description);
        });
};

handlers.getJoinEvent = async function (ctx) {
    let currentEventId = ctx.params.id;
    let currentEvents = await kinvey.get("appdata", `events?query={"_id":"${currentEventId}"}`, "kinvey");
    let currentEvent = currentEvents[0];

    let dateTime = currentEvent.dateTime;
    let description = currentEvent.description;
    let _id = currentEventId;
    let imageURL = currentEvent.imageURL;
    let name = currentEvent.name;
    let organizer = currentEvent.organizer;

    let peopleInterestedIn = `${Number(currentEvent.peopleInterestedIn) + 1}`;


    eventService.updateEvent(dateTime, description, _id, imageURL, name, organizer, peopleInterestedIn)
        .then((res) => {
            notifications.showSuccess("You join the event successfully.");
            ctx.redirect("#/home");
        })
        .catch(err => {
            notifications.showError(err.responseJSON.description);
        });
};

handlers.getDeleteEvent = async function (ctx) {
    // ctx.isAuth = userService.isAuth();
    // ctx.username = sessionStorage.getItem('username');

    let currentEventId = ctx.params.id;
    // let currentEvents = await kinvey.get("appdata", `events?query={"_id":"${currentEventId}"}`, "kinvey");
    // let currentEvent = currentEvents[0];

    // let dateTime = currentEvent.dateTime;
    // let description = currentEvent.description;
    // let _id = currentEvent._id;
    // let imageURL = currentEvent.imageURL;
    // let name = currentEvent.name;
    // let organizer = currentEvent.organizer;
    //
    // let peopleInterestedIn = `${Number(currentEvent.peopleInterestedIn) + 1}`;


    eventService.deleteEvent(currentEventId)
        .then((res) => {
            notifications.showSuccess("Event closed successfully.");
            ctx.redirect("#/home");
        })
        .catch(err => {
            notifications.showError(err.responseJSON.description);
        });
};