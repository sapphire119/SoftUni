function validate() {
    let $emailInput = $('#email');
    $emailInput.on('change', changeEvent);

    function changeEvent(event) {
        //valid Domain:
        // <name>@<domain>.<extension>
        //only lowercase letters
        let $input = $(event.target);

        let currentVal = $input.val();
        let valToLower = currentVal.toLowerCase();

        let usernamePattern = /^(\w+)\@(\w+)\.(\w*)?$/gm;

        if (!usernamePattern.test(currentVal) || valToLower !== currentVal) {
            $input.addClass("error");
        } else {
            $input.removeClass("error");
        }
    }
}