function solve() {
    let id = 0;
    // let reports = [];
    let currentOutput;

    class Report{
        constructor(author, description, reproducible, severity) {
            this.ID = id++;
            this.author = author;
            this.description = description;
            this.reproducible = reproducible;
            this.severity = severity;
            this.status = "Open"
        }
    }

    function report(author, description, reproducible, severity) {
        let currentReport = new Report(author, description, reproducible, severity);
        // reports.push(currentReport);

        // let reportDiv = document.createElement('div');
        // reportDiv.classList.add("report");
        // reportDiv.setAttribute("id", `report_${currentReport.ID}`);
        //
        // let bodyDiv = document.createElement('div');
        // bodyDiv.classList.add("body");
        //
        // let pElement = document.createElement('p');
        // pElement.innerHTML = `${currentReport.description}`;
        //
        // bodyDiv.appendChild(pElement);
        //
        // let titleDiv = bodyDiv.cloneNode();
        // titleDiv.classList.add("title");
        //
        // let authorSpan = document.createElement('span');
        // authorSpan.classList.add("author");
        // authorSpan.innerHTML = `Submitted by: ${currentReport.author}`;
        //
        // let statusSpan = document.createElement('span');
        // statusSpan.classList.add("status");
        // statusSpan.innerHTML = `${currentReport.status} | ${currentReport.severity}`;
        //
        // titleDiv.appendChild(authorSpan);
        // titleDiv.appendChild(statusSpan);
        //
        // reportDiv.appendChild(bodyDiv);
        // reportDiv.appendChild(titleDiv);


        let outputHtml = `<div id=\"report_${currentReport.ID}\" class=\"report\">\n` +
            `  <div class=\"body\">\n` +
            `    <p>${currentReport.description}</p>\n` +
            `  </div>\n` +
            `  <div class=\"title\">\n` +
            `    <span class=\"author\">Submitted by: ${currentReport.author}</span>\n` +
            `    <span class=\"status\">${currentReport.status} | ${currentReport.severity}</span>\n` +
            `  </div>\n` +
            `</div>\n`;
        debugger;

        // currentOutput.appendChild(reportDiv);
        currentOutput.insertAdjacentHTML('beforeend', outputHtml);

        // currentOutput.appendChild(outputHtml.trim());
    }

    function setStatus(id, newStatus) {
        let currentReport = document.querySelector(`#report_${id} .title .status`);
        let tokens = currentReport.innerHTML.split("|").map(e => e.trim());
        debugger;
        tokens[0] = newStatus;
        currentReport.innerHTML = `${tokens[0]} | ${tokens[1]}`;
        // let currentReport = reports.find(e => e.id === id);
        // currentReport.status = newStatus;
    }

    function remove(id) {
        let element = document.getElementById(`report_${id}`);
        // element.parentNode.removeChild(element);
        element.remove();
    }
    
    function sort(method = "ID") {
        if (method === 'author' || method === 'severity' || method === 'ID') {
            let reports = Array.from(document.getElementsByClassName("report"));
            switch (method) {
                case 'author': sortByAuthor(reports); break;
                case 'severity': sortBySeverity(reports); break;
                case 'ID': sortById(reports); break;
            }

            function sortByAuthor(reports) {
                reports.sort((a, b) => {
                    let firstElementVal = a.children[1].children[0].innerHTML;
                    let secondElementVal = b.children[1].children[0].innerHTML;

                    let firstAuthor = firstElementVal.split(":").map(e => e.trim())[1];
                    let secondAuthor = secondElementVal.split(":").map(e => e.trim())[1];

                    let result = firstAuthor.localeCompare(secondAuthor);

                    return result;
                });

                let sortedReports = reports.slice();

                displaySort(sortedReports);
            }

            function sortBySeverity(reports) {
                reports.sort((a, b) => {
                    let firstStatusSeverity = a.children[1].children[1].innerHTML;
                    let secondStatusSeverity = b.children[1].children[1].innerHTML;

                    let firstSeverityVal = firstStatusSeverity.split("|").map(e => e.trim())[1];
                    let secondSeverityVal = secondStatusSeverity.split("|").map(e => e.trim())[1];

                    let firstNum = Number(firstSeverityVal);
                    let secondNum = Number(secondSeverityVal);

                    return firstNum - secondNum;
                });

                let sortedReports = reports.slice();

                debugger;
                displaySort(sortedReports);
            }

            function sortById(reports) {
                reports.sort((a, b) => {
                    let firstId = Number(a.id.split("_")[1]);
                    let secondId = Number(b.id.split("_")[1]);

                    if (isNaN(firstId)) return 1;
                    else if (isNaN(secondId)) return -1;
                    else return firstId - secondId;
                });

                let sortedReports = reports.slice();

                debugger;
                displaySort(sortedReports);
            }

            function displaySort(sortedReports) {
                debugger;
                for (let i = 0; i < sortedReports.length; i++) {
                    let currentReport = sortedReports[i];
                    let parent = currentReport.parentNode;
                    parent.removeChild(currentReport);
                }
                for (let i = 0; i < sortedReports.length; i++) {
                    let sortedReport = sortedReports[i];
                    currentOutput.appendChild(sortedReport);
                }
            }
        }
    }

    function output(selector) {
        currentOutput = document.querySelector(selector);
    }

    return {
        report,
        output,
        setStatus,
        remove,
        sort
    }
}