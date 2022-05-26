from collections import deque

parentheses = input()
parentheses_stack = []
parentheses_list = []
parentheses_list[:0] = parentheses
is_balanced = True

opened_parentheses = 0
parentheses_queue = deque(parentheses_list)

while parentheses_queue:
    char = parentheses_queue.popleft()

    if char == '(' or char == '[' or char == '{':
        parentheses_stack.append(char)
    elif char == ')' and parentheses_stack:
        if parentheses_stack[-1] == '(':
            parentheses_stack.pop()
        else:
            is_balanced = False
            break
    elif char == '}' and parentheses_stack:
        if parentheses_stack[-1] == '{':
            parentheses_stack.pop()
        else:
            is_balanced = False
            break
    elif char == ']' and parentheses_stack:
        if parentheses_stack[-1] == '[':
            parentheses_stack.pop()
        else:
            is_balanced = False
            break
    else:
        is_balanced = False
        break

if parentheses_stack or not is_balanced:
    print('NO')
else:
    print('YES')
