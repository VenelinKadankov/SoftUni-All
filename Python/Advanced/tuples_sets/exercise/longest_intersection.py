n = int(input())

ss = set()

for _ in range(n):
    first_borders, second_borders = input().split('-')
    low1, high1 = map(int, first_borders.split(','))
    low2, high2 = map(int, second_borders.split(','))

    first_set = set()
    for v in range(low1, high1 + 1):
        first_set.add(v)

    second_set = set()
    for v in range(low2, high2 + 1):
        second_set.add(v)

    intersection = first_set.intersection(second_set)

    if len(intersection) > len(ss):
        ss = intersection

print(f'Longest intersection is {list(ss)} with length {len(ss)}')
