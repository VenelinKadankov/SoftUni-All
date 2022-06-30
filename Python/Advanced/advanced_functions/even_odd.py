def even_odd(*args):
    result = []
    numbers = args[:-1]
    number_type = args[-1]

    for num in numbers:
        if number_type == 'even' and num % 2 == 0:
            result.append(num)
        elif number_type == 'odd' and num % 2 == 1:
            result.append(num)

    return result


print(even_odd(1, 2, 3, 4, 5, 6, 'even'))
print(even_odd(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 'odd'))
