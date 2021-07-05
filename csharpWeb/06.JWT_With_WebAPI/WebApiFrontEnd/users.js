
function toggleRegister() {
    if ($register_data.css('display') == 'none') {
        $register_data.show();
        clearLoginRegisterInputs();
        $login_data.hide();
    }
}


function toggleLogin() {
    if ($login_data.css('display') == 'none') {
        $login_data.show();
        $register_data.hide();
        clearLoginRegisterInputs();
    }
}

async function register() {
    if (checkIfUserIsLoggedIn()) {
        return;
    }

    let username = $username_register.val();
    let password = $password_register.val();

    let result = await postRegister(username, password);

    if (result) {
        let jwt = await postLogin(username, password);
        localStorage.setItem("jwt", jwt);

        processLoggedIn(jwt);
    }
}

async function login() {
    if (checkIfUserIsLoggedIn()) {
        return;
    }

    let username = $username_login.val();
    let password = $password_login.val()

    let jwt = await postLogin(username, password);

    localStorage.setItem("jwt", jwt);

    processLoggedIn(jwt);
}

function logout() {
    localStorage.removeItem("jwt");
    processAnon();
}

function postLogin(username, password) {
    let postData = JSON.stringify({
        username,
        password
    });

    return $.post({
        url: `${APP_SERVICE_URL}${USERS_ENDPOINT}/login`,
        data: postData,
        contentType: "application/json"
    });
}

function postRegister(username, password) {
    let postData = JSON.stringify({
        username,
        password
    });

    return $.post({
        url: `${APP_SERVICE_URL}${USERS_ENDPOINT}/register`,
        data: postData,
        contentType: "application/json"
    });
}

function setLoginData(username) {
    $username_logged_in.text(username);
}

function checkIfUserIsLoggedIn() {
    return localStorage.getItem("jwt");
}

function hideLoginRegisterButtons() {
    let $children = Array.from($guest_navbar.children());
    $children.forEach(ele => {
        $(ele).hide();
    });
}

function showLoginRegisterButtons() {
    if ($guest_navbar.children().length > 2) {
        $guest_navbar.children().last().remove();
    }

    let childElements = Array.from($guest_navbar.children());

    childElements.forEach(ele => {
        $(ele).show();
    });
}

function processLoggedIn(jwt) {
    hideEverything();

    let username = parseJwt(jwt).unique_name;
    $username_logged_in.text(username);
    $logged_in_data.show();
    hideLoginRegisterButtons();
    $guest_navbar.append($("<h2>Welcome to Chat-Inc!</h2>"))
    clearLoginRegisterInputs();
}

function processAnon() {
    hideEverything();
    showLoginRegisterButtons();
    $login_data.show();
    clearLoginRegisterInputs();
}

function hideEverything() {
    $register_data.hide();
    $login_data.hide();
    $logged_in_data.hide();
}

function clearLoginRegisterInputs() {
    $username_login.val("");
    $password_login.val("");
    $username_register.val("");
    $password_register.val("");
}