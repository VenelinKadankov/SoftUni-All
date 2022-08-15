from project.horse_race import HorseRace
from project.horse_specification.appaloosa import Appaloosa
from project.horse_specification.horse import Horse
from project.horse_specification.thoroughbred import Thoroughbred
from project.jockey import Jockey


class HorseRaceApp:
    def __init__(self):
        self.horses: [Horse] = []
        self.jockeys: [Jockey] = []
        self.horse_races: [HorseRace] = []

    def add_horse(self, horse_type: str, horse_name: str, horse_speed: int):
        horses_ll = [horse for horse in self.horses if horse.name == horse_name]

        if len(horses_ll) > 0:
            raise Exception(f'Horse {horse_name} has been already added!')

        if horse_type not in ["Appaloosa", "Thoroughbred"]:
            return

        horse = None

        if horse_type == "Appaloosa":
            horse = Appaloosa(horse_name, horse_speed)
        else:
            horse = Thoroughbred(horse_name, horse_speed)

        self.horses.append(horse)

        return f'{horse_type} horse {horse_name} is added.'

    def add_jockey(self, jockey_name: str, age: int):
        jockeys_ll = [jock for jock in self.jockeys if jock.name == jockey_name]

        if len(jockeys_ll) > 0:
            raise Exception(f'Jockey {jockey_name} has been already added!')

        jockey = Jockey(jockey_name, age)
        self.jockeys.append(jockey)

        return f'Jockey {jockey_name} is added.'

    def create_horse_race(self, race_type: str):
        races_ll = [race for race in self.horse_races if race.race_type == race_type]

        if len(races_ll) > 0:
            raise Exception(f'Race {race_type} has been already created!')

        race = HorseRace(race_type)

        self.horse_races.append(race)

        return f'Race {race_type} is created.'

    def add_horse_to_jockey(self, jockey_name: str, horse_type: str):
        horses_of_type = [horse for horse in self.horses if horse.type == horse_type and horse.is_taken is False]
        jokeys_ll = [jock for jock in self.jockeys if jock.name == jockey_name]

        if len(jokeys_ll) < 1:
            raise Exception(f'Jockey {jockey_name} could not be found!')
        if len(horses_of_type) < 1:
            raise Exception(f'Horse breed {horse_type} could not be found!')

        jockey = jokeys_ll[0]

        if jockey.horse is not None:
            return f'Jockey {jockey_name} already has a horse.'

        horse = horses_of_type[-1]
        # horse.is_taken = True
        horse.assign_jockey()
        jockey.horse = horse

        return f'Jockey {jockey_name} will ride the horse {horse.name}.'

    def add_jockey_to_horse_race(self, race_type: str, jockey_name: str):
        races_ll = [race for race in self.horse_races if race.race_type == race_type]
        jokeys_ll = [jock for jock in self.jockeys if jock.name == jockey_name]

        if len(races_ll) < 1:
            raise Exception(f'Race {race_type} could not be found!')
        if len(jokeys_ll) < 1:
            raise Exception(f'Jockey {jockey_name} could not be found!')

        jockey = jokeys_ll[0]
        horse_race = races_ll[0]

        if jockey.horse is None:
            raise Exception(f'Jockey {jockey_name} cannot race without a horse!')

        if jockey in horse_race.jockeys:
            return f'Jockey {jockey_name} has been already added to the {race_type} race.'

        # self.jockeys.append(jockey)
        horse_race.jockeys.append(jockey)

        return f'Jockey {jockey_name} added to the {race_type} race.'

    def start_horse_race(self, race_type: str):
        races_ll = [race for race in self.horse_races if race.race_type == race_type]

        if len(races_ll) < 1:
            raise Exception(f'Race {race_type} could not be found!')

        race = races_ll[0]

        if len(race.jockeys) < 2:
            raise Exception(f'Horse race {race_type} needs at least two participants!')

        jockeys_in_race = sorted(race.jockeys, key=lambda x: x.horse.speed, reverse=True)
        winner = jockeys_in_race[0]

        return f"The winner of the {race_type} race, with a speed of {winner.horse.speed}km/h is {winner.name}!" \
               f" Winner's horse: {winner.horse.name}."
