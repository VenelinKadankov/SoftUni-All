from abc import ABC, abstractmethod


class Horse(ABC):
    SPEED_LIMIT = None

    def __init__(self, name: str, speed: int):
        self.speed = speed
        self.name = name
        self.__is_taken = False

    @property
    def is_taken(self):
        return self.__is_taken

    @property
    def name(self):
        return self.__name

    @name.setter
    def name(self, value):
        self.validate_name(value)
        self.__name = value

    @property
    def speed(self):
        return self.__speed

    @speed.setter
    def speed(self, value):
        self.validate_speed(value)
        self.__speed = value

    @staticmethod
    def validate_name(name):
        if name is None or name == '' or len(name) < 4 or (not isinstance(name, str)):
            raise ValueError(f'Horse name {name} is less than 4 symbols!')

    @abstractmethod
    def train(self):
        pass

    # @abstractmethod
    def validate_speed(self, speed):
        if speed > self.SPEED_LIMIT:
            raise ValueError('Horse speed is too high!')

    def assign_jockey(self):
        self.__is_taken = True

    @property
    @abstractmethod
    def type(self):
        pass

    # @property
    # @abstractmethod
    # def has_jockey(self):
    #     pass
