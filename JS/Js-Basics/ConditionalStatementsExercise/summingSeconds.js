function sumSeconds(runner1,runner2,runner3){
    let first = Number(runner1);
    let second = Number(runner2);
    let third = Number(runner3);
    let totalTime = first + second + third;
    let min = parseInt(totalTime / 60);
    let sec = totalTime % 60;

    if (sec < 10){
        sec = '0' + sec;
    } 
    
    console.log(`${min}:${sec}`);
}
sumSeconds(14,
    12,
    10)