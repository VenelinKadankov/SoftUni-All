class HorseRace:
    def __init__(self, race_type: str):
        self.race_type = race_type
        self.jockeys = []

    @property
    def race_type(self):
        return self.__race_type

    @race_type.setter
    def race_type(self, value):
        self.validate_race_type(value)
        self.__race_type = value

    @staticmethod
    def validate_race_type(race_type):
        if race_type not in ["Winter", "Spring", "Autumn", "Summer"]:
            raise ValueError('Race type does not exist!')
