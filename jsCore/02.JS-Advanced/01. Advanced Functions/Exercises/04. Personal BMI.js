function solve(name, age, weightInKg, heightInCm) {
    debugger;
    let heightInMetres = heightInCm / 100;
    //Body Mass Index
    let bmi = weightInKg / Math.pow(heightInMetres, 2);
    debugger;

    let currentPerson = {
        name: name,
        personalInfo: {
            age: Math.round(age),
            weight: Math.round(weightInKg),
            height: Math.round(heightInCm)
        },
        BMI: Math.round(bmi)
    };

    let statusFunc = (bmi, person) => {
        if (bmi < 18.5) person["status"] = "underweight";
        else if (18.5 <= bmi && bmi < 25) person["status"] = "normal";
        else if (25 <= bmi && bmi < 30) person["status"] = "overweight";
        else if (30 <= bmi) {
            person["status"] = "obese";
            person["recommendation"] = "admission required";
        }
    };
    
    statusFunc(bmi, currentPerson);

    return currentPerson;
}

// solve("Peter", 29, 75, 182);

solve("Honey Boo Boo", 9, 57, 137);