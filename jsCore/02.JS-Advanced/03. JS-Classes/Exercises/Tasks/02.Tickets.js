function solve(inputArr, sortCriteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }
    let tickets = [];

    for (const arrElement of inputArr) {
        let [destination, price, status] = arrElement.split("|");
        tickets.push(new Ticket(destination, Number(price), status));
    }

    let sortedTickets = tickets.sort((a, b) => {
        if (sortCriteria.toLowerCase() !== "price"){
            let first = a[sortCriteria].toLowerCase();
            let second = b[sortCriteria].toLowerCase();
            return first.localeCompare(second);
        }
        return a - b;
        // a[sortCriteria] - b[sortCriteria]
    });

    return sortedTickets;
}

// console.log(solve(['Philadelphia|94.20|available',
//         'New York City|95.99|available',
//         'New York City|95.99|sold',
//         'Boston|126.20|departed'],
//     'destination'
// ));

console.log(solve(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'price'
));