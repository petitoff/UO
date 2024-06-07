import random

# Polskie litery
polish_letters = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż"

# Generowanie 200 czteroliterowych słów
random_words = [''.join(random.choices(polish_letters, k=4)) for _ in range(200)]

print("Random Words:", random_words)
