const eventService = (function () {
    function createEvent(name, description, imageURL, dateTime, organizer) {
        return kinvey.post("appdata", "events", "kinvey", {
            name,
            description,
            imageURL,
            dateTime,
            organizer,
            peopleInterestedIn: 0
        });
    }

    function updateEvent(dateTime, description, _id, imageURL, name, organizer, peopleInterestedIn) {
        return kinvey.update("appdata", `events/${_id}`, "kinvey", {
            dateTime,
            description,
            imageURL,
            name,
            organizer,
            peopleInterestedIn
        })
    }

    function deleteEvent(id) {
        return kinvey.remove("appdata", `events/${id}`, kinvey);
    }


    return {
        createEvent,
        updateEvent,
        deleteEvent
    }
})();