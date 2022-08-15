class Jockey:
    def __init__(self, name: str, age: int):
        self.age = age
        self.name = name
        self.horse = None

    @property
    def age(self):
        return self.__age

    @age.setter
    def age(self, value):
        self.validate_age(value)
        self.__age = value

    @property
    def name(self):
        return self.__name

    @name.setter
    def name(self, value):
        self.validate_name(value)
        self.__name = value

    # @property
    # def horse(self):
    #     return self.__horse
    #
    # @horse.setter
    # def horse(self, value):
    #     if self.horse is not None:
    #         return
    #     self.__horse = value

    @staticmethod
    def validate_age(age):
        if (not isinstance(age, int)) or age < 18:   #check if allright
            raise ValueError(f'Jockeys must be at least 18 to participate in the race!')

    @staticmethod
    def validate_name(name: str):
        if (not isinstance(name, str)) or name is None or name.isspace() or name == '':
            raise ValueError('Name should contain at least one character!')
