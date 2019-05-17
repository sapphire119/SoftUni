function solve() {
    let $phoneBook = $("#phoneBook");

    let $buttonLoad = $("#btnLoad");

    let $buttonCreate = $("#btnCreate");

    $buttonLoad.on("click", loadEvent);

    function loadEvent(e) {
        let url = "https://testapp-d7e8b.firebaseio.com/people/.json";

        $.ajax({
            method: "GET",
            url,
            success: function(args) {
                $phoneBook.empty();
                Object.keys(args).forEach(key => {
                    let currentPerson = args[key];
                    if (currentPerson) {
                        let $li = $("<li>")
                            .text(`${currentPerson["name"]} ${currentPerson["phone"]} `)
                            .append(
                                $("<button>Delete</button>").on("click",e => deleteEvent(e, key, currentPerson)));
                        $phoneBook.append($li);
                    }
                })
            },
            error: function (args) {
                alert("Something went wrong!");
                console.log(args);
            }
        })
    }

    function deleteEvent(e, id, person) {
        let $parent = $(e.target).parent();
        let url = `https://testapp-d7e8b.firebaseio.com/people/${id}.json`;

        $.ajax({
            method:"DELETE",
            url,
            success:function() {
                $parent.remove();
                alert(`Successfully deleted: ${person["name"]}`);
            }
        });
    }

    $buttonCreate.on("click", createEvent);

    function createEvent(e) {
        let url = "https://testapp-d7e8b.firebaseio.com/people/.json";

        let $person = $("#person");
        let $phone = $("#phone");

        let obj = {
            name: $person.val(),
            phone: $phone.val()
        };

        $.ajax({
            method: "POST",
            url,
            data: JSON.stringify(obj),
            dataType: "json",
            success: function (resultData) {
                alert("Save Complete");
            }
        })
    }
}