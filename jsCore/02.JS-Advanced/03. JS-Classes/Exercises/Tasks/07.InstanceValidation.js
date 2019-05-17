class CheckingAccount {
    //clientId, email, firstName, lastName
    constructor(clientId, email, firstName, lastName) {
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
        this.products = [];
    }

    get lastName() {
        return this._lastName;
    }

    set lastName(value) {
        this._validateName("Last", value);
        this._lastName = value;
    }
    get firstName() {
        return this._firstName;
    }

    set firstName(value) {
        this._validateName("First", value);
        this._firstName = value;
    }

    get email() {
        return this._email;
    }

    set email(value) {
        let emailPattern = /^\w+\@[a-zA-Z\.]+$/gm;
        if (!emailPattern.test(value)){
            throw new TypeError("Invalid e-mail");
        }
        this._email = value;
    }
    get clientId() {
        return this._clientId;
    }

    set clientId(value) {
        let numPattern = /^\d{6}$/gm;
        if (!numPattern.test(value)) {
            throw new TypeError("Client ID must be a 6-digit number");
        }
        this._clientId = value;
    }

    _validateName(propName, value) {
        let nameLengthPattern = /^.{3,20}$/gm;
        let nameTypePattern = /^[a-zA-Z]{3,20}$/gm;
        if (!nameLengthPattern.test(value)) {
            throw new TypeError(`${propName} name must be between 3 and 20 characters long`);
        }
        else if (!nameTypePattern.test(value)) {
            throw new TypeError(`${propName} name must contain only Latin characters`);
        }
    }
}

// let acc = new CheckingAccount('1314', 'ivan@some.com', 'Ivan', 'Petrov');
// Output
// TypeError: Client ID must be a 6-digit number

// let acc1 = new CheckingAccount('131455', 'ivan@', 'Ivan', 'Petrov');
// Output
// TypeError: Invalid e-mail

// let acc2 = new CheckingAccount('131455', 'ivan@some.com', 'Ia2', 'Petrov');
// TypeError: First name must be between 3 and 20 characters long

let acc3 = new CheckingAccount('131455', 'ivan@some.com', 'Ivan', 'P3trov');

// TypeError: "First name must contain only Latin characters
