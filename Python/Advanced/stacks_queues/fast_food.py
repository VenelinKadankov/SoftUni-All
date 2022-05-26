from collections import deque

available_food = input()
food_count = int(available_food)
orders = input().split(' ')
orders = list(map(int, orders))

order_queue = deque(orders)

biggest_order = max(orders)

while food_count:
    if not order_queue:
        break
    next_order = order_queue[0]
    current_order = int(next_order)

    if current_order > food_count:
        break
    else:
        current_order = int(order_queue.popleft())
        food_count -= current_order

        # if current_order > biggest_order:
            # biggest_order = current_order

    if orders == 0:
        break

print(biggest_order)

if order_queue:
    orders_left = ' '.join(list(map(str, order_queue)))
    print(f'Orders left: {orders_left}')
else:
    print('Orders complete')