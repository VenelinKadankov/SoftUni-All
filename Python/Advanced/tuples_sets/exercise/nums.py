first_set = set(map(int, input().split(' ')))
second_set = set(map(int, input().split(' ')))

n = int(input())

for _ in range(n):
    command = input().split(' ')

    numbers_to_manipulate = set(map(int, command[2:]))

    if command[0] == 'Add':
        if command[1] == 'First':
            first_set.update(numbers_to_manipulate)
        else:
            second_set.update(numbers_to_manipulate)
    elif command[0] == 'Remove':
        if command[1] == 'First':
            first_set.difference_update(numbers_to_manipulate)
        else:
            second_set.difference_update(numbers_to_manipulate)
    else:
        print(first_set.issubset(second_set) or second_set.issubset(first_set))

print(', '.join(sorted(map(str, first_set))))
print(', '.join(sorted(map(str, second_set))))
