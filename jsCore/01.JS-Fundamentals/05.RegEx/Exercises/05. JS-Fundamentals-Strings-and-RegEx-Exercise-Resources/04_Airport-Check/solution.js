// function solve() {
//     let input = document.getElementById('str').value;
//
//     let tokens = input.split(',');
//
//     let textToScan = tokens[0];
//     let outputType = tokens[1].trim();
//     debugger;
//
//     let passengerPattern = /\ ([A-Z][A-Za-z]*)((\-|\ )[A-Z][A-Za-z]*\.)?(\-|\ )([A-Z][A-Za-z]*(?<!\.))\ /gm;
//
//     let airportsPattern = /\ [A-Z]{3}\/[A-Z]{3}\ /gm;
//
//     let flightNumberPattern = /\ [A-Z]{1,3}[0-9]{1,5}\ /gm;
//
//     let companyPattern = /\-\ [A-Z][a-zA-Z]*\*[A-Z][a-zA-Z]*\ /gm;
//
//     // let nameMessage = "Mr/Ms, {0}, have a nice flight!";
//
//     // let flightMessage = "Your flight number {0} is from {1} to {2}.";
//     // let companyMessage = "Have a nice flight with {0}.";
//     // let allMessage = "Mr/Ms, {0}, your flight number {1} is from {2} to {3}. Have a nice flight with {4}.";
//
//     let result = "";
//     if (outputType === "all") {
//         let passangers = textToScan.match(passengerPattern);
//         let destinationsTokens = textToScan.match(airportsPattern);
//         let flightNumbers = textToScan.match(flightNumberPattern);
//         let companies = textToScan.match(companyPattern);
//         for (let i = 0; i < passangers.length; i++) {
//             debugger;
//             let passanger = passangers[i].trim().replace("-", " ");
//             let destionationToken = destinationsTokens[i].split("/").map(e => e.trim());
//             let flighNumber = flightNumbers[i].trim();
//             let company = companies[i].replace("-", "").trim().replace("*", " ");
//             debugger;
//
//             result += `Mr/Ms, ${passanger}, your flight number ${flighNumber} is from ${destionationToken[0]} to ${destionationToken[1]}. Have a nice flight with ${company}.`;
//         }
//         debugger;
//     } else if (outputType === "flight") {
//         let flightNumbers = textToScan.match(flightNumberPattern);
//         let destinations = textToScan.match(airportsPattern);
//
//         for (let i = 0; i < flightNumbers.length; i++) {
//             let flightNumber = flightNumbers[i].trim();
//             let destTokens = destinations[i].split("/").map(e => e.trim());
//
//             let fromFlight = destTokens[0];
//             let toFlight = destTokens[1];
//
//             result += (`Your flight number ${flightNumber} is from ${fromFlight} to ${toFlight}.` + "\n");
//         }
//         debugger;
//         // let flightNumber = flightNumberPattern.exec(textToScan)[0].replace(" ", "").trim();
//         // let flightDestinations = airportsPattern.exec(textToScan)[0].split("/").map(e => e.trim());
//         // let flightFrom = flightDestinations[0];
//         // let flightTo = flightDestinations[1];
//         //
//         // result = flightMessage.replace("{0}", flightNumber)
//         //     .replace("{1}", flightFrom)
//         //     .replace("{2}", flightTo);
//     } else if (outputType === "company") {
//         debugger;
//         let companies = textToScan.match(companyPattern);
//         for (let company of companies) {
//             company = company.substr(2).trim().replace("*", " ");
//             result += (`Have a nice flight with ${company}.` + "\n")
//         }
//         // let companyName = companyPattern.exec(textToScan)[0]
//         //     .replace("-", "")
//         //     .replace(" ", "")
//         //     .replace("*", " ")
//         //     .trim();
//         //
//         // result = companyMessage.replace("{0}", companyName);
//     } else if (outputType === "name") {
//         debugger;
//         let names = textToScan.match(passengerPattern);
//         for (let name of names) {
//             result += (`Mr/Ms, ${name.trim().replace("-", " ")}, have a nice flight!` + "\n");
//         }
//         // debugger;
//         // let passangerName = passengerPattern.exec(textToScan)[0].replace("-", " ").trim();
//         //
//         // result = nameMessage.replace("{0}", passangerName);
//     } else {
//         return;
//     }
//
//     debugger;
//
//     let output = document.getElementById('result');
//     output.innerHTML = result.trim();
// }

function solve() {
    let input = document.getElementById('str').value;

    let tokens = input.split(',');

    let textToScan = tokens[0];
    let outputType = tokens[1].trim();
    debugger;

    let nameMessage = "Mr/Ms, {0}, have a nice flight!";
    let flightMessage = "Your flight number {0} is from {1} to {2}.";
    let companyMessage = "Have a nice flight with {0}.";
    let allMessage = "Mr/Ms, {0}, your flight number {1} is from {2} to {3}. Have a nice flight with {4}.";

    // \ ([A-Z][A-Za-z]*)((\-|\ )[A-Z][A-Za-z]*\.)?(\-|\ )([A-Z][A-Za-z]*(?<!\.))\
    // \ ([A-Z][A-Za-z]*)(\-[A-Z][A-Za-z]*\.)?\-([A-Z][A-Za-z]*(?<!\.))\
    let passengerPattern = /\ ([A-Z][A-Za-z]*)((\-|\ )[A-Z][A-Za-z]*\.)?(\-|\ )([A-Z][A-Za-z]*(?<!\.))\ /gm;

    let airportsPattern = /\ [A-Z]{3}\/[A-Z]{3}\ /gm;

    let flightNumberPattern = /\ [A-Z]{1,3}[0-9]{1,5}\ /gm;

    let companyPattern = /\-\ [A-Z][a-zA-Z]*\*[A-Z][a-zA-Z]*\ /gm;

    debugger;
    let passanger = passengerPattern.exec(textToScan)[0].replace(/-/g, " ").trim();
    let company = companyPattern.exec(textToScan)[0]
        .replace(/[ \-]/g, "")
        .replace(/[*]/g, " ");
    let flightNumber = flightNumberPattern.exec(textToScan)[0].trim();
    let airports = airportsPattern.exec(textToScan)[0].split("/").map(e => e.trim());

    let result = "";

    switch (outputType) {
        case "all":
            result = allMessage.replace("{0}", passanger)
                .replace("{1}", flightNumber)
                .replace("{2}", airports[0])
                .replace("{3}", airports[1])
                .replace("{4}", company);
            break;
        case "flight":
            result = flightMessage.replace("{0}", flightNumber)
                .replace("{1}", airports[0])
                .replace("{2}", airports[1]);
            break;
        case "company":
            result = companyMessage.replace("{0}", company);
            break;
        case "name":
            result = nameMessage.replace("{0}", passanger);
            break;
    }

    let output = document.getElementById('result');
    output.innerHTML = result;
}