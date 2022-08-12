class Validator:
    @staticmethod
    def validate_name_not_empty(name):
        if name is None or name == '':
            raise ValueError('Invalid username!')

    @staticmethod
    def validate_age_over_limit(age):
        if age < 6:
            raise ValueError('Users under the age of 6 are not allowed!')

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
