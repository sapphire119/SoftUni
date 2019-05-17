function solve(inputArr) {

    let word = "";
    for (let element of inputArr) {
        let currentElement = element;

        if (startingCondition !== null) {
            let match;
            while (match = startingPattern.exec(currentElement)){
                let wordToAdd = match[2];
                let matchToRemove = match[0];

                word += wordToAdd;

                currentElement = currentElement.replace(matchToRemove, "");
            }
        }
    }

    console.log(word);
}

// solve(['<h1><span>Hello World!</span></h1>',
//     '<p>I am Peter.']
// );

solve(['<div><p>This</p> is</div>',
    '<div><a>perfectly</a></div>',
    '<divs><p>valid</p></divs>',
    '<div><p>This</div></p>',
    '<div><p>is not</p><div>']
);