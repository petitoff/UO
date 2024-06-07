# Tworzenie modelu przejść (dwuliterowy kontekst)
import random
from collections import Counter

from lista2.zadanie_4_b import words, letter_prob
from lista2.zadanie_4_c import transitions

# Tworzenie modelu przejść (dwuliterowy kontekst)
bigram_transitions = {}
for word in words:
    for i in range(len(word) - 2):
        key = word[i:i+2]
        if key not in bigram_transitions:
            bigram_transitions[key] = Counter()
        bigram_transitions[key][word[i+2]] += 1

# Generowanie słów z dwuliterowym kontekstem
contextual_words_2 = []
for _ in range(200):
    word = random.choices(list(letter_prob.keys()), list(letter_prob.values()), k=1)[0]
    word += random.choices(list(transitions[word].keys()), list(transitions[word].values()))[0]
    for i in range(2):
        key = word[-2:]
        if key in bigram_transitions:
            next_letter = random.choices(list(bigram_transitions[key].keys()), list(bigram_transitions[key].values()))[0]
        else:
            next_letter = random.choices(list(letter_prob.keys()), list(letter_prob.values()))[0]
        word += next_letter
    contextual_words_2.append(word)

print("Contextual Words (2-letter context):", contextual_words_2)
