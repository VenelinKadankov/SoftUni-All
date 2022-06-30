def kwargs_length(**kwargs):
    result = 0

    for _ in kwargs.items():
        result += 1

    return result


dd = {'name': 'Peter', 'age': 25}
print(kwargs_length(**dd))

