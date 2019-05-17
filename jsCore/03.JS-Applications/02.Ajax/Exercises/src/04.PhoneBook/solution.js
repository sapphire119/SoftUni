function attachEvents() {
    let baseUrl = `https://phonebook-nakov.firebaseio.com/phonebook.json`;

    let $btnLoad = $("#btnLoad");
    $btnLoad.on("click", loadEvent);

    let $phonebook = $("#phonebook");

    function deleteEvent(e, key) {
        let deleteUrl = baseUrl.substr(0, baseUrl.length - 5).concat(`/${key}.json`);
        $.ajax({
            url: deleteUrl,
            method: "DELETE",
            success: $(e.target).parent().remove()
        });
    }

    function loadEvent() {
        $phonebook.empty();
        $.get({
            url: baseUrl,
            success: (people) => {
                Object.keys(people).forEach(key => {
                    let currentPerson = people[key];

                    let $li = $("<li>")
                        .append(document.createTextNode(`${currentPerson["person"]}: ${currentPerson["phone"]}`))
                        .append($("<button>Delete</button>").on("click", e => deleteEvent(e, key)));

                    $phonebook.append($li);
                });
            }
        })
    }

    let $btnCreate = $("#btnCreate");
    $btnCreate.on("click", createEvent);

    let $person = $("#person");
    let $phone = $("#phone");

    function createEvent() {
        let person = $person.val();
        let phone = $phone.val();

        let personObj = { person, phone };
        $.post({
            url: baseUrl,
            dataType: "json",
            data: JSON.stringify(personObj),
            success: (key) => {
                let $li = $("<li>")
                    .append(document.createTextNode(`${person}: ${phone}`))
                    .append($("<button>Delete</button>").on("click", e => deleteEvent(e, key)));

                $phonebook.append($li);
            }
        });

        $person.val("");
        $phone.val("");
    }
}