function validate() {
    $("#company").on('change', (event) => {
        let $input = $(event.target);
        let $fieldsetCompany = $("#companyInfo");

        if ($input.prop('checked')) {
            $fieldsetCompany.css('display', 'block');
        } else {
            $fieldsetCompany.css('display', 'none');
        }
    });

    $("#submit").click(clickEvent);

    function clickEvent(event) {
        event.preventDefault();

        function setBorderRed($field) {
            $field.css('border-color', 'red');
        }

        function setBorderNone($field) {
            $field.css('border-color', '');
        }

        const usernamePattern = /^[a-zA-Z0-9]{3,20}$/gm;
        // const emailPattern = /^\w+\@\w*$/gm;
        const passwordPattern = /^\w{5,15}$/gm;
        const emailPattern = /^[^@]+\@[^@]*$/gm;

        let $username = $("#username");
        let $email = $("#email");
        let $password = $("#password");
        let $confirmPassword = $("#confirm-password");

        let $company = $("#company");
        let $companyNumber = $("#companyNumber");

        debugger;
        if (!usernamePattern.test($username.val())) {
            setBorderRed($username);
        } else {
            setBorderNone($username);
        }

        if (emailPattern.test($email.val())) {
            let secondEmailVal = $email.val().split("@")[1];
            secondEmailVal = secondEmailVal === undefined ? "" : secondEmailVal;
            if (!secondEmailVal.includes(".")) {
                //red
                setBorderRed($email);
            } else {
                setBorderNone($email);
            }
        } else {
            setBorderRed($email);
        }

        if (!passwordPattern.test($password.val()) || ($password.val() !== $confirmPassword.val())) {
            setBorderRed($password);
            setBorderRed($confirmPassword);
        } else {
            setBorderNone($password);
            setBorderNone($confirmPassword);
        }

        if ($company.prop('checked')) {
            if (!(1000 <= $companyNumber.val() && $companyNumber.val() <= 9999)) {
                setBorderRed($companyNumber);
            } else {
                setBorderNone($companyNumber);
            }
        }

        let $allInputs = $('.pairContainer input');

        if ($company.prop('checked')) $allInputs.splice(4, 1);
        else $allInputs.splice(4, 2);

        let areThereAnyRedBorers = false;
        for (const input of $allInputs) {
            let $input = $(input);
            let borderVal = $input.prop('style')['borderColor'];
            if (borderVal === 'red') {
                areThereAnyRedBorers = true;
            }
        }
        if (areThereAnyRedBorers) {
            $("#valid").css('display', 'none');
        } else {
            $("#valid").css('display', 'block');
        }
    }
}