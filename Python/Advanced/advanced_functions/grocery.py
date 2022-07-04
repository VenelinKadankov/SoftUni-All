def grocery_store(**kwargs):
    dd = sorted(kwargs.items(), key=lambda x: (-x[1], -len(x[0]), x[0]))
    result = []
    [result.append(f'{grocery_item[0]}: {grocery_item[1]}') for grocery_item in dd]

    return '\n'.join(result)


print(grocery_store(
    bread=2,
    pasta=2,
    eggs=20,
    carrot=1,
))

print(grocery_store(
    bread=5,
    pasta=12,
    eggs=12,
))
