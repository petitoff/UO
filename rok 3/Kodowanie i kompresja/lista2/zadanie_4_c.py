# Tworzenie modelu przejść (jednoliterowy kontekst)
from collections import Counter
import random

from lista2.zadanie_4_b import letter_prob, words

transitions = {letter: Counter() for letter in letter_prob.keys()}
for word in words:
    for i in range(len(word) - 1):
        transitions[word[i]][word[i + 1]] += 1

# Generowanie słów z jednoliterowym kontekstem
contextual_words_1 = []
for _ in range(200):
    word = random.choices(list(letter_prob.keys()), list(letter_prob.values()), k=1)[0]
    for i in range(3):
        next_letter = random.choices(list(transitions[word[-1]].keys()), list(transitions[word[-1]].values()))[0]
        word += next_letter
    contextual_words_1.append(word)

print("Contextual Words (1-letter context):", contextual_words_1)
