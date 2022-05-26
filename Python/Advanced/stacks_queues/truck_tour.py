from collections import deque

petrol_stations = int(input())
minimum_starting_index = 0
is_completed = False
command_lines = deque()

for i in range(petrol_stations):
    command_lines.append(input())

while not is_completed:
    available_gas = 0
    distance_to_travel = 0

    for i in range(petrol_stations):
        tokens = command_lines[i].split(' ')
        tokens = list(map(int, tokens))
        gas_at_station = tokens[0]
        next_station = tokens[1]

        available_gas += gas_at_station
        distance_to_travel += next_station

        if distance_to_travel > available_gas:
            station = command_lines.popleft()
            command_lines.append(station)
            is_completed = False
            minimum_starting_index += 1
            break

        available_gas -= distance_to_travel
        distance_to_travel = 0
        is_completed = True

print(minimum_starting_index)
