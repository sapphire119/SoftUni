function solve(dayOfWeekArg, serviceArg, timeOfVisitArg){
    
    let avaibleDays = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday']

    if(avaibleDays.indexOf(dayOfWeekArg) >= 0){
        if(typeof(serviceArg) === 'string' && typeof(timeOfVisitArg) === 'number'){
            let result = 0;
            let openTime = new Date(0,0,0,8,0,0,0);
            let afterNoonTime = new Date(0,0,0,15,0,0,0);
            let eveningTime = new Date(0,0,0,22,0,0,0);


            function getDate(timeArg){
                let hours;
                let minutes;
                let newTime;
                if(0 <= timeArg && timeArg <= 24){
                    if(timeArg % 1 == 0){
                        hours = timeArg;
                        minutes = 0;
                    }
                    else{
                        let leftOverMinutes = (timeArg - Math.floor(timeArg)) * 100;
                        if(leftOverMinutes > 60){
                            hours = Math.floor(timeArg) + 1;
                            newTime = new Date(0,0,0,hours,leftOverMinutes - 60,0,0);
                            return newTime;
                        }
                        hours = Math.floor(timeArg);
                        minutes = leftOverMinutes;
                    }
                }
                newTime = new Date(0,0,0,hours,minutes,0,0);
                return newTime;
            }

            let dateOfVisit = getDate(timeOfVisitArg);

            switch(serviceArg){
                case 'Fitness': 
                    let fitnessDayPrice = 5;
                    let fitnessNightPrice = 7.5;

                    if(dayOfWeekArg == 'Saturday' || dayOfWeekArg == 'Sunday') {
                        let fitnessWeekendPrice = 8;
                        
                        if(openTime <= dateOfVisit && dateOfVisit < afterNoonTime){
                            result = fitnessWeekendPrice;
                        }
                        else if(
                            afterNoonTime <= dateOfVisit && dateOfVisit <= eveningTime ){
                            result = fitnessWeekendPrice;
                        }
                        return console.log(result);
                    }
        
                    if(openTime <= dateOfVisit && dateOfVisit < afterNoonTime){
                        result = fitnessDayPrice;
                    }
                    else if(
                        afterNoonTime <= dateOfVisit && dateOfVisit <= eveningTime ){
                        result = fitnessNightPrice;
                    }
        
                    return console.log(result);
                    break;
                case 'Sauna': 
                    let saunaDayPrice = 4;
                    let saunaNightPrice = 6.5;
                    if(dayOfWeekArg == 'Saturday' || dayOfWeekArg == 'Sunday') {
                        let saunaWeekendPrice = 7;
                        if(openTime <= dateOfVisit && dateOfVisit < afterNoonTime){
                            result = saunaWeekendPrice;
                        }
                        else if(
                            afterNoonTime <= dateOfVisit && dateOfVisit <= eveningTime){
                            result = saunaWeekendPrice;
                        }
                        return console.log(result);
                    }
                    if(openTime <= dateOfVisit && dateOfVisit < afterNoonTime){
                        result = saunaDayPrice;
                    }
                    else if(
                        afterNoonTime <= dateOfVisit && dateOfVisit <= eveningTime ){
                        result = saunaNightPrice;
                    }
        
                    return console.log(result);
                case 'Instructor': 
                    let insDayPrice = 10;
                    let insNightPrice = 12.5;
                    if(dayOfWeekArg == 'Saturday' || dayOfWeekArg == 'Sunday') {
                        let instWeekendPrice = 15;
        
                        if(openTime <= dateOfVisit && dateOfVisit < afterNoonTime){
                            result = instWeekendPrice;
                        }
                        else if(
                            afterNoonTime <= dateOfVisit && dateOfVisit <= eveningTime){
                            result = instWeekendPrice;
                        }
                        return console.log(result);
                    }
                    if(openTime <= dateOfVisit && dateOfVisit < afterNoonTime){
                        result = insDayPrice;
                    }
                    else if(
                        afterNoonTime <= dateOfVisit && dateOfVisit <= eveningTime ){
                        result = insNightPrice;
                    }
                    return console.log(result);
            }
        }
    }
}