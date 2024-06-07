import os
import math

os.chdir('lista1')

def load_probabilistic_model(file_path):
    probabilistic_model = {}
    with open(file_path, 'r', encoding='utf-8') as file:
        for line in file:
            letter, probability = line.strip().split(':')
            probabilistic_model[letter] = float(probability)
    return probabilistic_model

def calculate_entropy(probabilistic_model):
    entropy = -sum(prob * math.log2(prob) for prob in probabilistic_model.values())
    return entropy

if __name__ == "__main__":
    current_directory = os.path.dirname(os.path.abspath(__file__))
    model_file_path = os.path.join(current_directory, 'model.txt')

    # Wczytanie modelu probabilistycznego
    model = load_probabilistic_model(model_file_path)

    # Obliczanie entropii
    entropy = calculate_entropy(model)
    print(f'Entropy: {entropy} bits')
