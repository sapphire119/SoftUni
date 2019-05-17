function attachEvents() {
    //students collection
    let api_key = "kid_BJXTsSi-e";
    let api_secret = "447b8e7046f048039d95610c1b039390";

    let username = "guest";
    let password = "guest";

    function userCredentials(jqXHR) {
        jqXHR.setRequestHeader("Authorization", "Basic " + btoa("guest" + ":" + "guest"));
    }

    let url = `https://baas.kinvey.com/appdata/kid_BJXTsSi-e/students`;

    let $tbody = $("tbody");

    (function () {
        let loadStudentsPromise = $.get({
            beforeSend: userCredentials,
            url
        });
        loadStudentsPromise.then(data => {
            let distinctStudents = removeDuplicatingStudentsFromCollection(data);
            displayStudents(distinctStudents, true, true);
        })
    })();


    function removeDuplicatingStudentsFromCollection(students) {
        let studentIds = students
            .map(item => item.ID)
            .filter((v, i, self) => self.indexOf(v) === i);

        let distinctStudents = [];

        for (const studentId of studentIds) {
            let currentStudent = students.find(student => student.ID === studentId);
            distinctStudents.push(currentStudent);
        }

        return distinctStudents;
    }

    function sortStudentsById(students) {
        students.sort((a, b) => {
            return a.ID - b.ID;
        })
    }

    function displayStudents(students, sortCurrentStudentCollection = false, clearTableBody = false) {
        if (sortCurrentStudentCollection) {
            sortStudentsById(students);
        }
        if (clearTableBody) {
            $tbody.empty();
            appendTableHeaders();
            appendAddStudentRow();
        }
        for (const student of students) {
            let $tr = $("<tr>")
                .append($("<td>").text(`${student["ID"]}`))
                .append($("<td>").text(`${student["FirstName"]}`))
                .append($("<td>").text(`${student["LastName"]}`))
                .append($("<td>").text(`${student["FacultyNumber"]}`))
                .append($("<td>").text(`${student["Grade"]}`));

            $tbody.append($tr);
        }
    }

    function appendTableHeaders() {
        let headersHtml = "<tr>\n" +
            "        <th>ID</th>\n" +
            "        <th>First Name</th>\n" +
            "        <th>Last Name</th>\n" +
            "        <th>Faculty Number</th>\n" +
            "        <th>Grade</th>\n" +
            "    </tr>";

        $tbody.append(headersHtml);
    }

    function appendAddStudentRow() {
        let rowHtml = "<tr id=\"addStudent\">\n" +
            "        <td><label for='id'><input type=\"number\" id=\"id\"></label></td>\n" +
            "        <td><input type=\"text\" id=\"firstName\"></td>\n" +
            "        <td><input type=\"text\" id=\"lastName\"></td>\n" +
            "        <td><input type=\"text\" id=\"factNumb\"></td>\n" +
            "        <td><input type=\"number\" id=\"grade\"></td>\n" +
            "</tr>";

        $tbody.append(rowHtml);

        attachAddStudentFunctionality();
    }

    function attachAddStudentFunctionality() {
        let [id, firstName, lastName, factNumb, grade] = $("#addStudent input");

        let $id = $(id);
        let $firstName = $(firstName);
        let $lastName = $(lastName);
        let $factNumb = $(factNumb);
        let $grade = $(grade);

        let $tr = $("#addStudent");
        $tr.on("keypress", (e) => {
            if ($id.val() && $firstName.val() && $lastName.val() && $factNumb.val() && $grade.val() && e.key === "Enter") {
                //•	    ID – a number, non-empty
                // •	FirstName – a String, non-empty
                // •	LastName – a String, non-empty
                // •	FacultyNumber – a String of numbers, non-empty
                // •	Grade – a number, non-empty
                disableButton($id);
                disableButton($firstName);
                disableButton($lastName);
                disableButton($factNumb);
                disableButton($grade);

                if (isNaN($factNumb.val())) {
                    alert("Faculty Number is not valid!");
                    return;
                }

                let studentObj = {
                    ID: Number($id.val()),
                    FirstName: $firstName.val(),
                    LastName: $lastName.val(),
                    FacultyNumber: $factNumb.val(),
                    Grade: Number($grade.val())
                };

                let studentCreatePromise = $.post({
                    beforeSend: userCredentials,
                    url,
                    contentType: "application/json",
                    data: JSON.stringify(studentObj),
                });

                studentCreatePromise
                    .then(student => displayStudents([student]))
                    .then(() => {
                        clearButton($id);
                        clearButton($firstName);
                        clearButton($lastName);
                        clearButton($factNumb);
                        clearButton($grade);

                        enableButton($id);
                        enableButton($firstName);
                        enableButton($lastName);
                        enableButton($factNumb);
                        enableButton($grade);
                    });
            }
        });
    }

    function clearButton($btn) {
        $btn.val("");
    }

    function disableButton($btn) {
        $btn.prop("disabled", true);
    }

    function enableButton($btn) {
        $btn.prop("disabled", false);
    }
}