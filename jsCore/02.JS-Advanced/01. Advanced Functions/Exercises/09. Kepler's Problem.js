// function solve(){

// }

function solve(mean, ecc) {
    //E -- eccentric anomaly
    //M -- mean anomaly
    //e -- eccentricity

    //Cannot Solve For E
    //Calculate E with Numerical Analysis to approximate a root with accuracy 1 x 10 на -9та
    //Recursive solution.

    //Input
    //Current Mean Anomaly (M) in radians
    //orbital eccentricity of the body (e)

    //Output
    //Approximation of the Eccentric anomaly (E)
    //Print on console, display only the SIGNIFICANT DIGITS

    //Formula: M = E - e * sinE;
    function approximate(E0, ecc, series) {
        if (Math.abs(mean - (E0 - ecc * Math.sign(E0))) < 1e-9 || series > 200) {
            return E0;
        }

        return approximate(E0 - (E0 - ecc * Math.sin(E0) - mean) / (1 - ecc * Math.cos(E0)), ecc, ++series);
    }

    let result = Number(approximate(mean, ecc, 0).toFixed(9));

    console.log(result);
}

keplersProblem(1, 0);
keplersProblem(3.1415926535, 0.75);
keplersProblem(0.25, 0.99);
keplersProblem(4.8, 0.2);