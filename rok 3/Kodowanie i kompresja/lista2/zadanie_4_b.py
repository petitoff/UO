from collections import Counter
import random

# Wczytywanie pliku i liczenie częstotliwości liter
with open('4wyrazy.txt', 'r', encoding='windows-1250') as file:
    words = file.read().split()

letter_freq = Counter(''.join(words))
total_letters = sum(letter_freq.values())

# Prawdopodobieństwa dla każdej litery
letter_prob = {letter: freq / total_letters for letter, freq in letter_freq.items()}

# Generowanie słów na podstawie modelu probabilistycznego
probabilistic_words = []
for _ in range(200):
    word = ''.join(random.choices(list(letter_prob.keys()), list(letter_prob.values()), k=4))
    probabilistic_words.append(word)

print("Probabilistic Words:", probabilistic_words)
