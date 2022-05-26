input_text = input()

dd = {}

for symbol in input_text:
    if symbol not in dd:
        dd[symbol] = 0
    dd[symbol] += 1

[print(f'{key}: {value} time/s') for key, value in sorted(dd.items())]
