from project.horse_specification.horse import Horse


class Appaloosa(Horse):
    SPEED_LIMIT = 120

    def __init__(self, name: str, speed: int):
        super().__init__(name, speed)

    # @property
    # def speed(self):
    #     return self.__speed
    #
    # @speed.setter
    # def speed(self, value):
    #     self.validate_speed(value)
    #     self.__speed = value

    # def validate_speed(self, speed):
    #     if speed > self.SPEED_LIMIT:
    #         raise ValueError('Horse speed is too high!')

    def train(self):
        if self.speed + 2 > self.SPEED_LIMIT:
            self.speed = self.SPEED_LIMIT
        else:
            self.speed += 2

    @property
    def type(self):
        return 'Appaloosa'
