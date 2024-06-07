import collections
import string
import math
import os

os.chdir('lista2')

def stworz_model_probabilistyczny(sciezka_pliku):
    # Inicjalizacja słownika do przechowywania liczby wystąpień liter
    liczniki_liter = collections.defaultdict(int)
    suma_liter = 0
    
    # Odczytanie pliku i zliczanie liter
    with open(sciezka_pliku, 'r', encoding='utf-8') as plik:
        for linia in plik:
            for znak in linia:
                if znak in string.ascii_letters:  # Uwzględnij tylko znaki alfabetu
                    liczniki_liter[znak.lower()] += 1
                    suma_liter += 1
    
    # Obliczanie prawdopodobieństw
    model_probabilistyczny = {znak: liczba / suma_liter for znak, liczba in liczniki_liter.items()}
    
    return model_probabilistyczny

def oblicz_entropie(model_probabilistyczny):
    entropia = -sum(prawdopodobienstwo * math.log2(prawdopodobienstwo) for prawdopodobienstwo in model_probabilistyczny.values())
    return entropia

# Przykładowe użycie
sciezka_pliku = 'przyklad.txt'  # Zastąp swoją ścieżką do pliku
model_probabilistyczny = stworz_model_probabilistyczny(sciezka_pliku)
print(model_probabilistyczny)

entropia = oblicz_entropie(model_probabilistyczny)
print(f'Entropia: {entropia} bitów')
