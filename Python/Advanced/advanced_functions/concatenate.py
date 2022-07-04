def concatenate(*args, **kwargs):
    text = ''

    for word in args:
        text += word

    for key in kwargs.keys():
        if key in text:
            new_text = kwargs[key]
            text = text.replace(key, new_text)

    return text


print(concatenate("Soft", "UNI", "Is", "Grate", "!", UNI="Uni", Grate="Great"))
print(concatenate("I", " ", "Love", " ", "Cythons", C="P", s="", java='Java'))
