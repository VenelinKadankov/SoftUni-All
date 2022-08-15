from project.horse_specification.horse import Horse


class Thoroughbred(Horse):
    SPEED_LIMIT = 140

    def __init__(self, name: str, speed: int):
        super().__init__(name, speed)

    def train(self):
        if self.speed + 3 > self.SPEED_LIMIT:
            self.speed = self.SPEED_LIMIT
        else:
            self.speed += 3

    @property
    def type(self):
        return 'Thoroughbred'
