def even_odd_filter(**kwargs):
    dd = {}

    for key in kwargs.keys():
        result = []

        if key == 'odd':
            for num in kwargs[key]:
                if num % 2 == 1:
                    result.append(num)
            dd['odd'] = result
        elif key == 'even':
            for num in kwargs[key]:
                if num % 2 == 0:
                    result.append(num)
            dd['even'] = result

    sorted_dd = sorted(
        dd.items(),
        key=lambda x: x[1],
        reverse=True
    )

    return_dictionary = {}

    for entry in sorted_dd:
        return_dictionary[entry[0]] = entry[1]

    return return_dictionary


print(even_odd_filter(
    odd=[1, 2, 3, 4, 10, 5],
    even=[3, 4, 5, 7, 10, 2, 5, 5, 2],
))

print(even_odd_filter(
    odd=[2, 2, 30, 44, 10, 5],
))
