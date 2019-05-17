function attachEvents() {
    let url = `https://messenger-19566.firebaseio.com/messenger.json`;

    let $submit = $("#submit");
    let $refresh = $("#refresh");
    let $messages = $("#messages");

    function fillData() {
        $.ajax({
            method: "GET",
            url,
            success: (args) => {
                let messages = [];
                Object.keys(args).forEach(key => {
                    // let currentMessage = args[key];
                    messages.push(args[key]);
                    // $messages.append(document.createTextNode(`${currentMessage["author"]}: ${currentMessage["content"]}\n`));
                });

                messages.sort((a, b) => a.timestamp - b.timestamp);

                for (const message of messages) {
                    $messages.append(document.createTextNode(`${message["author"]}: ${message["content"]}\n`));
                }
            },
            error: () => console.log("Error")
        })
    }

    fillData();

    $submit.on("click", submitEvent);

    $refresh.on("click", refreshEvent);

    let $author = $("#author");
    let $content = $("#content");
    function submitEvent(e) {
        let author = $author.val();
        let content = $content.val();
        let timestamp = Date.now();

        let message = {
            author,
            content,
            timestamp
        };

        $author.val("");
        $content.val("");

        $.ajax({
            method: "POST",
            url,
            dataType: "json",
            data: JSON.stringify(message)
        });
    }

    function refreshEvent(e) {
        $messages.empty();
        fillData();
    }
}