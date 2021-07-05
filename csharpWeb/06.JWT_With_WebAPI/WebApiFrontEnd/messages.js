async function fetchAllMessages() {
    let result = await $.get({
        url: `${APP_SERVICE_URL}${MESSAGES_ENDPOINT}/all`
    });

    for (let i = 0; i < result.length; i++) {
        let currentEntry = result[i];
        let $div = $(`<div class=\"message d - flex justify - content - start\"><strong>${currentEntry.username}</strong>: ${currentEntry.content}</div>`);
        $messages.append($div);
    }
}

async function createMessage() {
    let message = $messageInpt.val();
    let jwt = localStorage.getItem("jwt");

    if (message && jwt) {
        let jwtObj = parseJwt(jwt);

        // let username = jwtObj["unique_name"];
        let userId = jwtObj["nameid"];

        let postData = JSON.stringify({
            "content": message,
            "userId": userId
        });

        let result = await $.post({
            beforeSend: (jqXHR, settings) => {
                jqXHR.setRequestHeader("authorization", `Bearer ${jwt}`);
            },
            url: `${APP_SERVICE_URL}${MESSAGES_ENDPOINT}/create`,
            data: postData,
            contentType: "application/json"
        });

        $messageInpt.val("");
        $messages.append($(`<div class=\"message d - flex justify - content - start\"><strong>${result.username}</strong>: ${result.content}</div>`));
    }
}