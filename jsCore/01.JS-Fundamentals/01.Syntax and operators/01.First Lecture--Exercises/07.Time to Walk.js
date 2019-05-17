function solve(numberOfStepsArg, lengthOfStudentFootPrintsArg, speedKmHArg){
    if(typeof(numberOfStepsArg) === 'number' &&
    typeof(lengthOfStudentFootPrintsArg) === 'number' &&
    typeof(speedKmHArg) === 'number' && Number.isInteger(numberOfStepsArg)){
        let restDivisor = 500;

        let hours;
        let minutes;
        let seconds;
debugger;
        let lengthToSchoolInMetres = 
        lengthOfStudentFootPrintsArg * numberOfStepsArg;

        let restMinutes = Math.floor(lengthToSchoolInMetres / restDivisor);

        let lengthToSchoolInKm = lengthToSchoolInMetres / 1000;

        let hoursNumber = lengthToSchoolInKm / speedKmHArg;
        hours = Math.floor(hoursNumber);
debugger;
        let minutesNumber = Math.abs(hours - hoursNumber);
        minutes = Math.floor(minutesNumber * 60) + restMinutes;
debugger;
        if(minutes > 60){
            minutes = math.abs(60 - minutes);
            hours += 1;
        }
debugger;
        let secondsNumb = Math.abs((minutes - restMinutes) - (minutesNumber * 60));
        seconds = Math.round(secondsNumb * 60);

        let date = new Date(0,0,0,hours,minutes,seconds,0);
        let result = date.toTimeString().split(' ')[0];
        debugger;
        console.log(result);
    }
}