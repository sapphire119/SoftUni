const APP_SERVICE_URL = 'https://localhost:44306';

const MESSAGES_ENDPOINT = "/Messages";
const USERS_ENDPOINT = "/Users"

const $messageInpt = $("#message");
const $chooseDataDiv = $("#choose-data");
const $messages = $("#messages");
const $register_data = $("#register-data");
const $login_data = $("#login-data");
const $logged_in_data = $("#logged-in-data");

const $username_register = $("#username-register");
const $password_register = $("#password-register");
const $username_login = $("#username-login");
const $password_login = $("#password-login");

const $username_logged_in = $("#username-logged-in");

const $guest_navbar = $("#guest-navbar");


const parseJwt = (token) => {
    try {
      return JSON.parse(atob(token.split('.')[1]));
    } catch (e) {
      return null;
    }
};