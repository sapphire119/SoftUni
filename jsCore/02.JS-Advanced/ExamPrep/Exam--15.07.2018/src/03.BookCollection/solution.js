class BookCollection {
    constructor(shelfGenre, room, shelfCapacity) {
        this.shelfGenre = shelfGenre; //string
        this.room = room; //string
        this.shelfCapacity = shelfCapacity; //number //always valid positive number
        this.shelf = [];
    }

    toString(){
        let result = "";
        if (this.shelf.length > 0){
            //"{shelfGenre}" shelf in {room} contains:
            //    \uD83D\uDCD6 "{bookName}" – {bookAuthor}
            result = `"${this.shelfGenre}" shelf in ${this.room} contains:\n`;
            this.shelf.forEach(b => {
                result += `\uD83D\uDCD6 "${b.bookName}" - ${b.bookAuthor}\n`;
            })
        } else {
            result = "It's an empty shelf";
        }

        return result.trim();
    }

    showBooks(genre) {
        debugger;
        //TODO: test if current genre is missing
        let currentBooks = this.shelf.filter(b => b.genre === genre);
        let result = `Results for search "${genre}":\n`;
        currentBooks.forEach(b => {
            result += `\uD83D\uDCD6 ${b.bookAuthor} - "${b.bookName}"\n`;
        });

        return result.trim();
    }

    throwAwayBook(bookName) {
        this.shelf = this.shelf.filter(b => b.bookName !== bookName);

        return this;
    }

    addBook(bookName, bookAuthor, genre) {
        //add book if there is enough space
        let book = {bookName, bookAuthor, genre};
        //if not remove first book and add to shelf
        if (this.shelfCondition < 1) this.shelf.shift();
        
        this.shelf.push(book);
        //sort alphabetically by author's name
        this.shelf.sort((a, b) => a.bookAuthor.localeCompare(b.bookAuthor));

        return this;
    }

    get shelfCondition() {
        return this.shelfCapacity - this.shelf.length;
    }

    get room() {
        return this._room;
    }

    set room(value) {

        //livingRoom" or "bedRoom" or "closet
        switch (value) {
            case "livingRoom":
            case "bedRoom":
            case "closet":
                this._room = value;
                break;
            default:
                throw `Cannot have book shelf in ${value}`;
        }

        return this;
    }
}

// let livingRoom = new BookCollection("livingRoom", "Programming", 5)
//     .addBook("Introduction to Programming with C#", "Svetlin Nakov")
//     .addBook("Introduction to Programming with Java", "Svetlin Nakov")
//     .addBook("Programming for .NET Framework", "Svetlin Nakov");
// console.log(livingRoom.toString());

// let bedRoom = new BookCollection('bedRoom', 'Mixed', 5);
// bedRoom.addBook("John Adams", "David McCullough", "history");
// bedRoom.addBook("The Guns of August", "Cuentos para pensar", "history");
// bedRoom.addBook("Atlas of Remote Islands", "Judith Schalansky");
// bedRoom.addBook("Paddle-to-the-Sea", "Holling Clancy Holling");
// console.log("Shelf's capacity: " + bedRoom.shelfCondition);
// console.log(bedRoom.toString());
// debugger;


