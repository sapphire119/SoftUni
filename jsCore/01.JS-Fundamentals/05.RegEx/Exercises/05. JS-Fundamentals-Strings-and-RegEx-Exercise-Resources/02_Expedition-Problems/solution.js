function solve() {
    let keyWordToLookFor = document.getElementById('str').value;
    let text = document.getElementById('text').value;

    let output = document.getElementById('result');
    // (north|east)[^0-9]*(\d{2})[^,]*(,)[^,]*?(\d{6})

    // (north|east)[^0-9]*(\d{2})[^,]*(,)[^,]*?(\d{6})

    let latOrLongPattern = /(north|east).*?(\d{2})[^,]*(,)[^,]*?(\d{6})/gi;

    let results = {};

    let match;
    while(match = latOrLongPattern.exec(text)){
        let latOrLong = match[1].toUpperCase();
        let coordinate = `${match[2]}.${match[4]} ${latOrLong.charAt(0) === 'N' ? 'N' : 'E'}`;
        results[latOrLong] = coordinate;
    }
    let startingIndex = text.indexOf(keyWordToLookFor);
    let lastIndex = text.lastIndexOf(keyWordToLookFor);

    let message = text.substring(startingIndex + keyWordToLookFor.length, lastIndex);
    debugger;
    let p = document.createElement('p');
    let p1 = p.cloneNode();
    let p2 = p.cloneNode();


    p.textContent = `Message: ${message}`;
    p1.textContent = results["NORTH"];
    p2.textContent = results["EAST"];

    output.appendChild(p1);
    output.appendChild(p2);
    output.appendChild(p);
}