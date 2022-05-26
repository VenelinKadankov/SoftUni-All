n = int(input())

odd_set = set()
even_set = set()

for i in range(n):
    name = input()
    letter_sum = 0

    for l in name:
        letter_sum += ord(l)

    divided_sum = int(letter_sum / (i + 1))
    if divided_sum % 2 == 0:
        even_set.add(divided_sum)
    else:
        odd_set.add(divided_sum)

odd_sum = sum(odd_set)
even_sum = sum(even_set)

if odd_sum == even_sum:
    print(', '.join(map(str, odd_set.union(even_set))))
elif odd_sum > even_sum:
    print(', '.join(map(str, odd_set.difference(even_set))))
else:
    print(', '.join(map(str, even_set.union(odd_set))))
