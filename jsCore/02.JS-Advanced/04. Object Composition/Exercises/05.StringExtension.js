(function () {
    String.prototype.ensureStart = function(str) {
        if (!this.startsWith(str)) {
            return str.concat(this);
        }

        return this.toString();
    };

    String.prototype.ensureEnd = function(str) {
        if (!this.endsWith(str)) {
            return this.concat(str);
        }

        return this.toString();
    };

    String.prototype.isEmpty = function() {
        return !(this.length > 0)
    };

    String.prototype.truncate = function(n) {
        let elipsis = "...";
        let currentStr = this.toString();

        while (currentStr.length > n) {
            if (currentStr.includes(" ")) {
                let indexOfLastSpace = currentStr.lastIndexOf(" ");
                let newStr = currentStr.substring(0, indexOfLastSpace);
                newStr = newStr.concat(elipsis);
                currentStr = newStr;
            } else if (!currentStr.includes(" ") && (n - 3 >= 1)){
                let charactersToReturn = n - 3;
                let output = [];
                for (let i = 0; i < charactersToReturn; i++) {
                    output.push(currentStr[i]);
                }
                let result = output.join("").concat(elipsis);
                currentStr = result;
            } else if (n < 4) {
                currentStr = ".".repeat(n);
            }
        }
        return currentStr;
    };
    String.format = function(string, ...params){
        let output = "";
        Object.keys(params).map(Number).forEach(key => {
            if (string.includes(`{${key}}`)) {
                string = string.replace(`{${key}}`, params[key]);
            }
        });
        output = string;
        return output;
    };
})();


let str = 'hello my string';
// str = str.ensureStart('my');
// str = str.ensureStart('hello ');
// str = str.ensureEnd("ing");
// str = str.ensureEnd(" asd");
str = str.truncate(16);
str = str.truncate(14);
str = str.truncate(8);
str = str.truncate(4);
str = str.truncate(2);
str = String.format('The {0} {1} fox',
    'quick', 'brown');
str = String.format('jumps {0} {1}',
    'dog');
