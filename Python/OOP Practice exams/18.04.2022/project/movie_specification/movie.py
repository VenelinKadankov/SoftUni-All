from abc import ABC, abstractmethod


class Movie(ABC):
    def __init__(self, title: str, year: int, owner: object, age_restriction: int):
        self.age_restriction = age_restriction
        self.owner = owner
        self.year = year
        self.title = title
        self.likes = 0

    @property
    def owner(self):
        return self.__owner

    @owner.setter
    def owner(self, value):
        self.validate_user_is_correct_type(value)
        self.__owner = value

    @property
    def year(self):
        return self.__year

    @year.setter
    def year(self, value):
        self.validate_movie_year(value)
        self.__year = value

    @property
    def title(self):
        return self.__title

    @title.setter
    def title(self, value):
        self.validate_title_not_empty(value)
        self.__title = value

    @abstractmethod
    def details(self):
        pass

    @staticmethod
    def validate_title_not_empty(title):
        if title is None or title == '':
            raise ValueError('The title cannot be empty string!')

    @staticmethod
    def validate_movie_year(year):
        if year < 1888:
            raise ValueError("Movies weren't made before 1888!")

    @staticmethod
    def validate_user_is_correct_type(user):
        if type(user).__name__ != 'User':
            raise ValueError('The owner must be an object of type User!')

    @staticmethod
    def validate_age_appropriate(movie, age):
        if movie.age_restriction < age:
            raise Exception('User too young for that movie')