import os

from project.movie_specification.movie import Movie
from project.user import User


class MovieApp:
    def __init__(self):
        self.movies_collection = []
        self.users_collection = []

    def __str__(self):
        result = ''
        if len(self.users_collection) > 0:
            result += f'All users: {", ".join([user.username for user in self.users_collection])}' + os.linesep
        else:
            result += "All users: No users." + os.linesep

        if len(self.movies_collection) > 0:
            result += f'All movies: {", ".join([current_movie.title for current_movie in self.movies_collection])}'
        else:
            result += "All movies: No movies."

        return result

    def register_user(self, username: str, age: int):
        if username in [user.username for user in self.users_collection]:
            raise Exception('User already exists!')

        self.users_collection.append(User(username, age))
        return f'{username} registered successfully.'

    def upload_movie(self, username: str, movie: Movie):
        if username not in [user.username for user in self.users_collection]:
            raise Exception('This user does not exist!')
        elif username in [user.username for user in self.users_collection] and movie.owner.username != username:
            raise Exception(f'{username} is not the owner of the movie {movie.title}!')
        elif movie in self.movies_collection:
            raise Exception('Movie already added to the collection!')
        else:
            self.movies_collection.append(movie)
            user = [x for x in self.users_collection if x.username == username][0]
            user.movies_owned.append(movie)
            return f'{username} successfully added {movie.title} movie.'

    def edit_movie(self, username: str, movie: Movie, **kwargs):
        if movie.owner.username != username:
            raise Exception(f'{username} is not the owner of the movie {movie.title}!')
        if movie not in [current_movie for current_movie in self.movies_collection]:
            raise Exception(f'The movie {movie.title} is not uploaded!')

        edit_movie_title = movie.title

        if edit_movie_title:
            edit_movie = [x for x in self.movies_collection if x.title == edit_movie_title][0]
            if edit_movie:
                edit_movie.title = kwargs['title']
                for key, value in kwargs.items():
                    edit_movie.key = value

                return f'{username} successfully edited {movie.title} movie.'

    def delete_movie(self, username: str, movie: Movie):
        if movie.owner.username != username:
            raise Exception(f'{username} is not the owner of the movie {movie.title}!')
        if movie not in [current_movie for current_movie in self.movies_collection]:
            raise Exception(f'The movie {movie.title} is not uploaded!')

        user = [x for x in self.users_collection if x.username == username][0]

        self.movies_collection.remove(movie)
        user.movies_owned.remove(movie)

        return f'{username} successfully deleted {movie.title} movie.'

    def like_movie(self, username: str, movie: Movie):
        user = [x for x in self.users_collection if x.username == username][0]

        if movie.owner.username == username:
            raise Exception(f'{username} is the owner of the movie {movie.title}!')
        if movie in user.movies_liked:
            raise Exception(f'{username} already liked the movie {movie.title}!')

        user.movies_liked.append(movie)
        movie.likes += 1

        return f'{username} liked {movie.title} movie.'

    def dislike_movie(self, username: str, movie: Movie):
        user = [x for x in self.users_collection if x.username == username][0]

        if movie not in user.movies_liked:
            raise Exception(f'{username} has not liked the movie {movie.title}!')

        user.movies_liked.remove(movie)
        movie.likes -= 1

        return f'{username} disliked {movie.title} movie.'

    def display_movies(self):
        if len(self.movies_collection) > 0:
            self.movies_collection.sort(key=lambda x: (x.year, x.title), reverse=False)
            return os.linesep.join([current_movie.details() for current_movie in self.movies_collection])

        return "No movies found."
