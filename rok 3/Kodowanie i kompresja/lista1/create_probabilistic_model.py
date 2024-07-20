import os
import string
from collections import Counter


def create_probabilistic_model(file_path):
    with open(file_path, 'r', encoding='utf-8') as file:
        text = file.read().lower()

    # Zliczanie liter
    letter_counts = Counter(c for c in text if c in string.ascii_lowercase)

    # Obliczanie prawdopodobieństw
    total_letters = sum(letter_counts.values())
    probabilistic_model = {letter: count / total_letters for letter, count in letter_counts.items()}

    return probabilistic_model


if __name__ == "__main__":
    current_directory = os.path.dirname(os.path.abspath(__file__))
    file_path = os.path.join(current_directory, 'example.txt')

    # Tworzenie modelu probabilistycznego
    model = create_probabilistic_model(file_path)
    print("Probabilistic Model:", model)

    # Zapisanie modelu do pliku
    model_file_path = os.path.join(current_directory, 'model.txt')
    with open(model_file_path, 'w', encoding='utf-8') as model_file:
        for letter, probability in model.items():
            model_file.write(f"{letter}:{probability}\n")
