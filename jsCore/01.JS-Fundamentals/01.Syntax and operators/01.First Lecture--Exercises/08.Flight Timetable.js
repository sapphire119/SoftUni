// function solve(inputArray){
//     if(!(inputArray instanceof Array) && inputArray.length < 5){
//         return;
//     }

//     let flightStatusArg = inputArray[0];

//     if(flightStatusArg !== 'Arrivals' &&
//     flightStatusArg !== 'Departures'){
//         return;
//     }
    
//     let townNameArg = inputArray[1];
//     let isTownNumberValid = Number(townNameArg);
//     if(!isNaN(isTownNumberValid)){
//         return;
//     }

//     let timeArg = inputArray[2];

//     let timePattern = /[0-9]{1,2}:[0-9]{2}/;
//     if(!timePattern.test(timeArg)){
//         return;
//     }
//     let timeTokens = timeArg.split(':');

//     let inputHours = Number(timeTokens[0]);
//     let inputMinutes = Number(timeTokens[1]);
    
//     if(!Number.isInteger(inputHours) || !Number.isInteger(inputMinutes)){
//         return;
//     }

    

//     if(!(0 <= inputHours && inputHours <= 24)){
//         return;
//     }

//     if(!(0 <= inputMinutes && inputMinutes <= 60)){
//         return;
//     }
    
//     let dateTime;
//     try {
//         dateTime = new Date(0,0,0,inputHours, inputMinutes,0,0);
//     } catch (error) {
//         return;
//     }

//     if(dateTime == 'Invalid'){
//         return;
//     }
    
//     let timeResult = dateTime.toTimeString().split(' ')[0];
//     timeResult = timeResult.substring(0, timeResult.length - 3);

//     let pattern = /^[A-Z]{1,2}[0-9]{1,}$/;

//     let flightNumberArg = inputArray[3];

//     if(!pattern.test(flightNumberArg)){
//         return;
//     }


//     let gateNumberArg = inputArray[4];
    
//     let gateNumberInt = Number(gateNumberArg);

//     if(!Number.isInteger(gateNumberInt)){
//         return;
//     }
    
//     let result = 
//     `${flightStatusArg}: Destination - ${townNameArg}, Flight - ${flightNumberArg}, Time - ${timeResult}, Gate - ${gateNumberArg}`;
    
//     console.log(result);
// }

function test(inputArray){
    let firstString = inputArray[0];
    let second = inputArray[1];
    let third = inputArray[2];
    let fourth = inputArray[3];
    let fifth = inputArray[4];

    console.log(`${firstString}: Destination - ${second}, Flight - ${fourth}, Time - ${third}, Gate - ${fifth}`);
}