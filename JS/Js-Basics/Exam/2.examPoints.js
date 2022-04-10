function examPoints(task, points, course) {

    task = task;
    points = Number(points);

    let finalPoints = 0;

    if (course === 'Basics') {

        switch (task) {
            case '1':
                finalPoints = points * 0.08 * 0.8;
                break;
            case '2':
                finalPoints = points * 0.09;
                break;
            case '3':
                finalPoints = points * 0.09;
                break;
            case '4':
                finalPoints = points * 0.1;
                break;
        }

    } else if (course === 'Fundamentals') {
        switch (task) {
            case '1':
                finalPoints = points * 0.11;
                break;
            case '2':
                finalPoints = points * 0.11;
                break;
            case '3':
                finalPoints = points * 0.12;
                break;
            case '4':
                finalPoints = points * 0.13;
                break;
        }
    } else if (course === 'Advanced') {
        switch (task) {
            case '1':
                finalPoints = points * 0.14;
                break;
            case '2':
                finalPoints = points * 0.14;
                break;
            case '3':
                finalPoints = points * 0.15;
                break;
            case '4':
                finalPoints = points * 0.16;
                break;
        }
        finalPoints *= 1.2;
    }
    console.log(`Total points: ${finalPoints.toFixed(2)}`);
}

examPoints('1',
    100,
    'Basics'
)