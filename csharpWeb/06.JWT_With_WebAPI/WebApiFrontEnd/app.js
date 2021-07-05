function main() {
    fetchAllMessages();

    let jwt = checkIfUserIsLoggedIn();

    if (jwt){
        processLoggedIn(jwt);
    } else {
        processAnon();
    }
}

main();