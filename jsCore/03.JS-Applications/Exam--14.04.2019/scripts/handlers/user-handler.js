handlers.getRegister = function (context) {
    context.loadPartials({
        header: './templates/common/header.hbs',
        footer: './templates/common/footer.hbs'
    }).then(function () {
        this.partial('./templates/user/register.hbs');
    }).catch(function (err) {
        console.log(err);
    });
};

handlers.getLogin = function (context) {
    context.loadPartials({
        header: './templates/common/header.hbs',
        footer: './templates/common/footer.hbs'
    }).then(function () {
        this.partial('./templates/user/login.hbs');
    }).catch(function (err) {
        console.log(err);
    });
};

handlers.registerUser = function (context) {
    //TODO: Validate user
    let username = context.params.username;
    if (username.length < 3) {
        notifications.showError("The username should be at least 3 characters long.");
        return;
    }
    let password = context.params.password;
    if (password.length < 6) {
        notifications.showError("The password should be at least 6 characters long.");
        return;
    }

    let repeatPassword = context.params.rePassword;
    if (repeatPassword !== password) {
        notifications.showError('Passwords do not match.');
        return;
    }
    userService.register(username, password).then((res) => {
        userService.saveSession(res);
        notifications.showSuccess('User registration successful.');
        context.redirect('#/home');
    }).catch(function (err) {
        notifications.showError(err.responseJSON.description);
    });
};

handlers.logoutUser = function (context) {
    userService.logout().then(() => {
        sessionStorage.clear();
        notifications.showSuccess('Logout successful.');
        context.redirect('#/home');
    })
};

handlers.postLoginUser = function (context) {
    let username = context.params.username;
    let password = context.params.password;
    userService.login(username, password).then((response) => {
        userService.saveSession(response);
        notifications.showSuccess('Login successful.');
        context.redirect('#/home');
    }).catch(function (err) {
        notifications.showError(err.responseJSON.description);
    });
};

handlers.getUserDetails = async function (ctx) {
    ctx.isAuth = userService.isAuth();
    ctx.username = sessionStorage.getItem('username');
    let userId = sessionStorage.getItem('id');

    let eventsCreatedByUser = await kinvey.get("appdata", `events?query={"_acl.creator":"${userId}"}`, "kinvey");

    ctx.eventCounter = eventsCreatedByUser.length;
    ctx.anyEvents = eventsCreatedByUser.length > 0;
    ctx.events = eventsCreatedByUser;

    ctx.loadPartials({
        header: './templates/common/header.hbs',
        footer: './templates/common/footer.hbs'
    }).then(function () {
        this.partial('./templates/user/details.hbs');
    }).catch(function (err) {
        console.log(err);
    });
};