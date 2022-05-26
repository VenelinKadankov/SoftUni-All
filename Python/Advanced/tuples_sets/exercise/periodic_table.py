n = int(input())
ss = set()

for _ in range(n):
    tokens = set(input().split(' '))
    new_elements = tokens.difference(ss)
    ss.update(new_elements)

[print(el) for el in ss]
