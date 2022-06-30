def add(arr):
    positive_result = 0
    negative_result = 0

    for num in arr:
        if num > 0:
            positive_result += num
        elif num < 0:
            negative_result += num

    return [positive_result, negative_result]


ll = list(map(int, input().split(' ')))

positive, negative = add(ll)

print(negative)
print(positive)

if positive > abs(negative):
    print('The positives are stronger than the negatives')
elif positive < abs(negative):
    print('The negatives are stronger than the positives')
