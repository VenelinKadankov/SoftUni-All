function songsList(input) {

    class Song {
        constructor(typeList, name ,time){
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    let searchedList = input.pop();
    let countSongs = Number(input.shift());

    for (let i = 0; i < countSongs; i++){
        let[typeList, name, time] = input.shift().split('_');
        let song = new Song(typeList, name, time);

        if(song.typeList === searchedList || searchedList === 'all'){
            console.log(song.name);
        }
    }
    
}
songsList([4,
    "favourite_DownTown_3:14",
    "listenLater_Andalouse_3:24",
    "favourite_In To The Night_3:58",
    "favourite_Live It Up_3:48",
    "listenLater"])