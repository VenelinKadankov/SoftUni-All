n, m = map(int, input().split(' '))

set1 = set()
set2 = set()

for i in range(n + m):
    if i < n:
        set1.add(int(input()))
    else:
        set2.add(int(input()))

[print(num) for num in set2.intersection(set1)]
