def palindrome(word, index):
    if len(word) / 2 <= index:
        return f'{word} is a palindrome'

    backward_index = len(word) - 1 - index

    if word[index] != word[backward_index]:
        return f'{word} is not a palindrome'
    else:
        index += 1
        return palindrome(word, index)


print(palindrome("asdfdsasa", 0))
print(palindrome("peter", 0))
