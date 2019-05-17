function solve() {
    let avaibleCourses = {
        "js-fundamentals": 170,
        "js-advanced": 180,
        "js-applications": 190,
        "js-web": 490
    };
    let $fundamental = $("[name='js-fundamentals']");
    let $advanced = $("[name='js-advanced']");

    let $button = $("[value='signMeUp']");
    $button.on("click", function (e) {
        let $inputs = $('input[type=checkbox]:checked', '.courseBody');

        let $formOfLearning = $($('input[type=radio]:checked', '#educationForm')[0]);

        let isAdvPresent = false;
        let isFundPresent = false;
        let isModuleDiscount = false;
        let getBonusCourse = false;
        // let onlineStudent = false;

        for (const input of $inputs) {
            let $input = $(input);
            if ($input.val() === "js-fundamentals") {
                isFundPresent = true;
            }
            if ($input.val() === 'js-advanced') {
                isAdvPresent = true;
            }
            if ($input.val() === 'js-applications' && isFundPresent && isAdvPresent) {
                isModuleDiscount = true;
            }
            if ($input.val() === 'js-web' && isModuleDiscount) {
                getBonusCourse = true;
            }
        }
        debugger;
        if (isFundPresent && isAdvPresent) {
            avaibleCourses["js-advanced"] = avaibleCourses["js-advanced"] * 0.90;
        }

        if (isModuleDiscount) {
            avaibleCourses["js-advanced"] = avaibleCourses["js-advanced"] * 0.94;
            avaibleCourses["js-applications"] = avaibleCourses["js-applications"] * 0.94;
            avaibleCourses["js-fundamentals"] = avaibleCourses["js-fundamentals"] * 0.94;
        }

        if ($formOfLearning.val() === "online") {
            avaibleCourses["js-fundamentals"] *= 0.94;
            avaibleCourses["js-applications"] *= 0.94;
            avaibleCourses["js-advanced"] *= 0.94;
            avaibleCourses["js-web"] *= 0.94;
        }

        let $ul = $($(".courseBody > ul").eq(1));
        debugger;
        let totalCost = 0;
        for (const input of $inputs) {
            let $input = $(input);
            let output = getOutput($input.val());

            let $li = $("<li>")
                .text(output);
            $ul.append($li);

            totalCost += avaibleCourses[$input.val()];
        }

        if (getBonusCourse) {
            let $bonusCourse = $("<li>")
                .text("HTML and CSS");
            $ul.append($bonusCourse);
            getBonusCourse = !getBonusCourse;
        }

        let $price = $(".courseFoot > p");
        let tokens = $price.text().split(/[: ]/).map(e => e.trim()).filter(e => e);
        let newCost = Number(tokens[1]) + totalCost;
        $price.text(`Cost: ${Math.floor(newCost).toFixed(2)} BGN`);
    });

    function getOutput(value) {
        switch (value) {
            case "js-fundamentals": return "JS-Fundamentals";
            case "js-advanced": return "JS-Advanced";
            case "js-applications": return "JS-Applications";
            case "js-web": return "JS-Web";
        }
    }
}