handlers.getRegister = function (context) {
  context.loadPartials({
    header: './templates/common/header.hbs',
    footer: './templates/common/footer.hbs'
  }).then(function () {
    this.partial('./templates/register.hbs');
  }).catch(function (err) {
    console.log(err);
  });
};

handlers.getLogin = function (context) {
  context.loadPartials({
    header: './templates/common/header.hbs',
    footer: './templates/common/footer.hbs'
  }).then(function () {
    this.partial('./templates/login.hbs');
  }).catch(function (err) {
    console.log(err);
  });
};

handlers.registerUser = function (context) {
  let username = context.params.username;
  let password = context.params.password;
  // let repeatPassword = context.params.repeatPassword;
  // if (repeatPassword !== password) {
  //   notifications.showError('Passwords must match');
  //   return;
  // }
  userService.register(username, password).then((res) => {
    userService.saveSession(res);
    notifications.showSuccess('User registered successfully');
    context.redirect('#/home');
  }).catch(function (err) {
    notifications.showError(err.responseJSON.description);
  });
};

handlers.logoutUser = function (context) {
  userService.logout().then(() => {
    sessionStorage.clear();
    notifications.showSuccess('User logged out successfully');
    context.redirect('#/home');
  })
};

handlers.postLoginUser = function (context) {
  let username = context.params.username;
  let password = context.params.password;
  userService.login(username, password).then((response) => {
    userService.saveSession(response);
    notifications.showSuccess('User logged in successfully');
    context.redirect('#/home');
  }).catch(function (err) {
    notifications.showError(err.responseJSON.description);
  });
};