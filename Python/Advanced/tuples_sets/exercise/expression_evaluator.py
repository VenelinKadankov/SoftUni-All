def subtract(numbers_list):
    start = numbers_list[0]

    for index, num in enumerate(numbers_list):
        if index > 0:
            start -= num

    return [start]


def divide(numbers_list):
    start = numbers_list[0]

    for index, num in enumerate(numbers_list):
        if index > 0:
            start /= num
            start = int(start)

    return [start]


def multiply(numbers_list):
    start = numbers_list[0]

    for index, num in enumerate(numbers_list):
        if index > 0:
            start *= num

    return [start]


string_expression = input().split(' ')

operators = {'+', '-', '*', '/'}

numbers = []

for symbol in string_expression:
    if symbol in operators:
        if symbol == '+':
            numbers = [sum(numbers)]
        elif symbol == '-':
            numbers = subtract(numbers)
        elif symbol == '/':
            numbers = divide(numbers)
        elif symbol == '*':
            numbers = multiply(numbers)
    elif symbol != "'":
        numbers.append(int(symbol))

print(numbers[0])
