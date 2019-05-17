class Hotel {
    constructor(name, capacity) {
        this.name = name;
        this.capacity = capacity;
        this.bookings = [];
        this.currentBookingNumber = 1;
        this._setRooms();
    }

    _servicesAvaible(serviceType) {
        return ["food", "drink", "housekeeping"].indexOf(serviceType);
    }

    _avaibleRoomTypes(roomType) {
        return ["single", "double", "maisonette"].indexOf(roomType);
    }

    _setRooms() {
        this._avaibleRooms = {
            single: Math.floor(this.capacity * 0.5),
            double: Math.floor(this.capacity * 0.3),
            maisonette: Math.floor(this.capacity * 0.2)
        };
    }

    get roomsPricing() {
        return {
            single: 50,
            double: 90,
            maisonette: 135
        }
    }

    get servicesPricing() {
        return {
            food: 10,
            drink: 15,
            housekeeping: 25
        }
    }

    rentARoom(clientName, roomType, nights) {

        if (this._avaibleRooms.hasOwnProperty(roomType) && this._avaibleRooms[roomType] > 0) {
            let roomNumber = this.currentBookingNumber;
            let booking = {
                clientName,
                roomType,
                nights,
                roomNumber
            };

            this.bookings.push(booking);

            this.currentBookingNumber++;
            this._avaibleRooms[roomType] -= 1;

            return `Enjoy your time here Mr./Mrs. ${clientName}. Your booking is ${roomNumber}.`;
        } else {
            let output = `No ${roomType} rooms available!`;
            Object.keys(this._avaibleRooms).forEach(key => {
                if (this._avaibleRooms[key] > 0) {
                    output += ` Available ${key} rooms: ${this._avaibleRooms[key]}.`;
                }
            });

            return output.trim();
        }
    }

    roomService(currentBookingNumber, serviceType){
        let currentBooking = this.bookings.find(b => b.roomNumber === currentBookingNumber);

        if (!currentBooking) {
            return `The booking ${currentBookingNumber} is invalid.`;
        }

        if (this._servicesAvaible(serviceType) >= 0) {
            if (!currentBooking.hasOwnProperty("services")) {
                currentBooking.services = [];
            }

            currentBooking.services.push(serviceType);

            return `Mr./Mrs. ${currentBooking.clientName}, Your order for ${serviceType} service has been successful.`;
        } else {
            return `We do not offer ${serviceType} service.`;
        }
    }

    checkOut(currentBookingNumber) {
        let currentBooking = this.bookings.find(b => b.roomNumber === currentBookingNumber);

        if (!currentBooking) {
            return `The booking ${currentBookingNumber} is invalid.`;
        }

        let totalMoneyDue = 0;

        let roomAmount = this.roomsPricing[currentBooking.roomType] * currentBooking.nights;

        let output = `We hope you enjoyed your time here, Mr./Mrs.` +
        ` ${currentBooking.clientName}. The total amount of money you have to pay is ${roomAmount} BGN.`;

        if (currentBooking.hasOwnProperty("services")) {
            let servicesAmount = 0;
            for (const service of currentBooking.services) {
                servicesAmount += this.servicesPricing[service];
            }

            this._avaibleRooms[currentBooking.roomType] += 1;
            this.bookings = this.bookings.filter(b => b.roomNumber !== currentBookingNumber);

            totalMoneyDue = roomAmount + servicesAmount;

            output = `We hope you enjoyed your time here, Mr./Mrs. ${currentBooking.clientName}.` +
            ` The total amount of money you have to pay is ${totalMoneyDue} BGN.` +
            ` You have used additional room services, costing ${servicesAmount} BGN.`;
        }

        return output;
    }

    report() {
        let output = `${this.name.toUpperCase()} DATABASE:\n` +
            "-".repeat(20) +
            "\n";
        if (this.bookings.length) {
            //"{hotelName.toUpperCase()} DATABASE:
            // -------------------- (separate the header and bookings information - 20 dashes)
            // bookingNumber – {bookingNumber}
            // clientName – {clientName}
            // roomType – {roomType}
            // nights – {nights}
            // services – {services} (Optional. Only for those bookings who have used room services. The services should be joined with a comma and a space.)
            // ---------- (booking separator - 10 dashes)
            let outpuArr = [];
            for (const booking of this.bookings) {
                let myOutput = "";
                myOutput += `bookingNumber - ${booking.roomNumber}\n`;
                myOutput += `clientName - ${booking.clientName}\n`;
                myOutput += `roomType - ${booking.roomType}\n`;
                myOutput += `nights - ${booking.nights}\n`;
                if (booking.hasOwnProperty("services")) {
                    myOutput += `services: ${booking.services.join(", ")}\n`;
                }

                outpuArr.push(myOutput);
                // output += "-".repeat(10);
                // output += "\n";
            }
            output += outpuArr.join(`${"-".repeat(10)}\n`);

        } else {
            output += `There are currently no bookings.\n`;
        }

        return output.trim();
    }
}

let hotel = new Hotel('HotUni', 10);

console.log(hotel.rentARoom('Peter', 'asd', 4));
console.log(hotel.rentARoom('Pesho', 'single', 4));
console.log(hotel.rentARoom('Stamat', 'single', 4));
console.log(hotel.rentARoom('Georgi', 'single', 4));
console.log(hotel.rentARoom('Deqn', 'single', 4));
console.log(hotel.rentARoom('Petkan', 'single', 4));
