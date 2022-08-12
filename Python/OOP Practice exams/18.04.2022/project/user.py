import os


class User:
    def __init__(self, username: str, age: int):
        self.age = age
        self.username = username
        self.movies_liked = []
        self.movies_owned = []

    @property
    def age(self):
        return self.__age

    @age.setter
    def age(self, value):
        self.validate_age_over_limit(value)
        self.__age = value

    @property
    def username(self):
        return self.__username

    @username.setter
    def username(self, value):
        self.validate_name_not_empty(value)
        self.__username = value

    def __str__(self):
        liked_movies_text = os.linesep.join([movie.details() for movie in self.movies_liked])
        liked_movies_response = 'No movies liked.' if len(self.movies_liked) < 1 else liked_movies_text

        owned_movies_text = os.linesep.join([movie.details() for movie in self.movies_owned])
        owned_movies_response = 'No movies owned.' if len(self.movies_owned) < 1 else owned_movies_text

        return f'Liked movies: {os.linesep}{liked_movies_response}{os.linesep}' \
               f'Owned movies: {os.linesep}{owned_movies_response}'

    @staticmethod
    def validate_name_not_empty(name):
        if name is None or name == '':
            raise ValueError('Invalid username!')

    @staticmethod
    def validate_age_over_limit(age):
        if age < 6:
            raise ValueError('Users under the age of 6 are not allowed!')