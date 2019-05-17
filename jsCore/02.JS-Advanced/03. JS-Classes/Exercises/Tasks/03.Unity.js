class Rat {
    constructor(name) {
        this.name = name;
        this.rats = [];
    }

    unite(otherRat){
        if (!(otherRat instanceof  Rat)) return;
        this.rats.push(otherRat);
    }

    getRats(){
        return this.rats;
    }

    toString(){
        let output = "";
        output += `${this.name}\n`;
        if (this.rats.length > 0){
            for (const rat of this.rats) {
                output += `##${rat.name}\n`;
            }
        }
        return output.trim();
    }
}

let test = new Rat("Pesho");
console.log(test.toString()); //Pesho

console.log(test.getRats()); //[]

test.unite(new Rat("Gosho"));
test.unite(new Rat("Sasho"));
console.log(test.getRats());
//[ Rat { name: 'Gosho', unitedRats: [] },
//  Rat { name: 'Sasho', unitedRats: [] } ]

console.log(test.toString());
