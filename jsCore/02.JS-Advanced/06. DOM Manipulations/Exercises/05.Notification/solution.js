function notify(message) {
    let $divNotification = $("#notification");
    $divNotification.text(message);
    $divNotification.css('display', 'block');
    setTimeout(function () {
        $divNotification.css('display', 'none');
    }, 2000)
}