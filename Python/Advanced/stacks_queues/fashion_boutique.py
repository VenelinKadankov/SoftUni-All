clothes_box = input().split(' ')
clothes_box = list(map(int, clothes_box))
rack_capacity = int(input())

rack_counter = 1

while clothes_box:
    capacity = rack_capacity
    while capacity >= 0:
        if clothes_box[-1] > capacity:
            rack_counter += 1
            break
        capacity -= clothes_box.pop()

        if not clothes_box:
            break

print(rack_counter)