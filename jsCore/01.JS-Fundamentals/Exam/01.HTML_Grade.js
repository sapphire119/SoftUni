function solve(examPoints, homeworksCompleted, totalHomeWork) {
    let maxPointsCourse = 100;
    let maxExamPoints = 400;

    let inputExamPoints = Number(examPoints);
    let inputHWCompleted = Number(homeworksCompleted);
    let inputTotalHws = Number(totalHomeWork);

    let grade = 0;
    let totalScore = 0;

    if (inputExamPoints === maxExamPoints) grade = 6;
    else {
        let tempScore = inputExamPoints / maxExamPoints;
        let currentScoreExam = tempScore * (maxPointsCourse - 10);

        let tempScoreHW = inputHWCompleted / inputTotalHws;
        let currentScoreHw = tempScoreHW * 10;

        totalScore = currentScoreExam + currentScoreHw;

        grade = 3 + 2 * (totalScore - maxPointsCourse / 5) / (maxPointsCourse / 2);
        if (grade < 3) grade = 2;
        else if (grade > 6) grade = 6;
    }

    console.log(grade.toFixed(2));
}

solve(399, 5, 5);

solve(300, 10, 10);

solve(200, 5 ,5);
