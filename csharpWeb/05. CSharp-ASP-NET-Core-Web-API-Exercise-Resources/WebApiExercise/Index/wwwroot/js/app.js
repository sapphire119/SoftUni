function main() {
    //<div class="message d-flex justify-content-start"><strong>Pesho</strong>: Hello!</div>
    let $messages = $("#messages");
    fetchAllMessages($messages);
    let $chooseBtn = $("#choose");
    let $resetBtn = $("#reset");
    let $sendBtn = $("#send");
    let $usernameInpt = $("#username");
    let $messageInpt = $("#message");

    let $usernameField = $("#username-choice");
    let $chooseDataDiv = $("#choose-data");

    $chooseBtn.on("click", function () {
        let currentUsername = $usernameInpt.val();
        if (currentUsername) {
            $chooseDataDiv.toggle();
            $usernameInpt.val("");
            $usernameField.text(currentUsername);
        }
    });

    $resetBtn.on("click", function () {
        let currentUsername = $usernameField.text();
        if (currentUsername) {
            $usernameField.text("");
            $chooseDataDiv.toggle();
        }
    });

    //{
    // "content": "string",
    //  "user": "string"
    //}
    $sendBtn.on("click", async function () {
        let message = $messageInpt.val();
        let currentUsername = $usernameField.text();
        if (message && currentUsername) {
            let postData = JSON.stringify({
                "content": message,
                "user": currentUsername
            });

            await $.post({
                url: "/create",
                data: postData,
                contentType: "application/json"
            });

            $messages.empty();
            $messageInpt.val("");
            fetchAllMessages($messages);
        }
    });
}


async function fetchAllMessages($messages) {
    let result = await $.get({
        url: "/all"
    });

    for (let i = 0; i < result.length; i++) {
        let currentEntry = result[i];
        let $div = $(`<div class=\"message d - flex justify - content - start\"><strong>${currentEntry.user}</strong>: ${currentEntry.content}</div>`);
        $messages.append($div);
    }
}

main();