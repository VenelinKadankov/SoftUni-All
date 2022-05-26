class Robot:
    def __init__(self, name, work_time):
        self.name = name
        self.work_time = work_time


robots_input = 'ROB-15;SS2-10;NX8000-3'.split(';')
start_time = '8:00:00'
robots = []

while robots_input:
    tokens = robots_input.pop().split('-')
    robots.append(Robot(tokens[0], int(tokens[1])))
