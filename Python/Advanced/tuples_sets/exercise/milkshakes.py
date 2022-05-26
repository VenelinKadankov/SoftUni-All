from collections import deque

chocolates = list(map(int, input().split(', ')))
cups = deque(list(map(int, input().split(', '))))

milkshakes = 0
is_enough = False
# same_chocolate = False

while chocolates and cups:
    cup = cups.popleft()

    choc = chocolates[-1]

    if choc <= 0:
        chocolates.pop()

        if not chocolates:
            break

        choc = chocolates[-1]

    if cup == choc:
        milkshakes += 1
        chocolates.pop()
    else:
        if cup > 0:
            cups.append(cup)

        if not cups:
            break

        chocolates[-1] -= 5

    if milkshakes >= 5:
        is_enough = True
        break


if is_enough:
    print('Great! You made all the chocolate milkshakes needed!')
else:
    print('Not enough milkshakes.')

if chocolates:
    print(f"Chocolate: {', '.join(map(str, chocolates))}")
else:
    print('Chocolate: empty')

if cups:
    print(f"Milk: {', '.join(map(str, cups))}")
else:
    print('Milk: empty')
