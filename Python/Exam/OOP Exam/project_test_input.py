from project.horse_race_app import HorseRaceApp
from project.horse_specification.appaloosa import Appaloosa
from project.horse_specification.horse import Horse
from project.horse_specification.thoroughbred import Thoroughbred

horseRaceApp = HorseRaceApp()
horse = Thoroughbred('Somename', 135)
print(horse.train())
horse.train()
print(horse.speed)
print(horseRaceApp.add_horse("Appaloosa", "Spirit", 80))
print(horseRaceApp.add_horse("Thoroughbred", "Pesho", 120))
print(horseRaceApp.add_horse("Thoroughbred", "Rocket", 110))
print(horseRaceApp.add_jockey("Peter", 18))
print(horseRaceApp.add_jockey("Mariya", 21))
print(horseRaceApp.add_jockey("Stoyan", 21))
print(horseRaceApp.create_horse_race("Summer"))
print(horseRaceApp.create_horse_race("Winter"))
print(horseRaceApp.create_horse_race("Winter"))
print(horseRaceApp.add_horse_to_jockey("Peter", "Appaloosa"))
print(horseRaceApp.add_horse_to_jockey("Peter", "Thoroughbred"))
print(horseRaceApp.add_horse_to_jockey("Mariya", "Thoroughbred"))
# print(horseRaceApp.add_horse_to_jockey("Stoyan", "Thoroughbred"))
print(horseRaceApp.add_jockey_to_horse_race("Summer", "Mariya"))
print(horseRaceApp.add_jockey_to_horse_race("Summer", "Peter"))
print(horseRaceApp.add_jockey_to_horse_race("Summer", "Mariya"))
# print(horseRaceApp.add_jockey_to_horse_race("Winter", "Stoyan"))
print(horseRaceApp.start_horse_race("Summer"))
# print(horseRaceApp.start_horse_race("Winter"))
