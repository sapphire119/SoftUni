function attachEventsListeners() {
    let conversionTableInMetres = {
        'km': 1000,
        'm': 1,
        'cm': 0.01,
        'mm': 0.001,
        'mi': 1609.34,
        'yrd': 0.9144,
        'ft': 0.3048,
        'in': 0.0254
    };

    let $button = $("#convert");
    let $input = $("#inputDistance");
    let $output = $("#outputDistance");

    // 1 km = 1000 m
    // 1 m = 1 m
    // 1 cm = 0.01 m
    // 1 mm = 0.001 m
    // 1 mi = 1609.34 m
    // 1 yrd = 0.9144 m
    // 1 ft = 0.3048 m
    // 1 in = 0.0254 m

    let $unitsInput = $("#inputUnits");
    let $unitsOutput = $("#outputUnits");

    $button.on('click', () => {
        let unitToMultiply = $unitsInput.val();
        let unitToDivideTo = $unitsOutput.val();

        let initialVal = Number($input.val());
        debugger;
        let intermediaryResult = conversionTableInMetres[unitToMultiply] * initialVal;
        let endResult = intermediaryResult / conversionTableInMetres[unitToDivideTo];

        $output.val(endResult);
        // console.log($unitsInput.val());
        // console.log($unitsOutput.val());
    });
}