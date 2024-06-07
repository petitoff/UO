import collections


# Funkcja do stworzenia słownika digramów
def create_digram_dictionary(text, dictionary_size):
    # Zliczanie wystąpień digramów
    digrams = collections.defaultdict(int)
    for i in range(len(text) - 1):
        digram = text[i:i + 2]
        digrams[digram] += 1

    # Sortowanie digramów według częstotliwości i wybieranie najczęstszych
    sorted_digrams = sorted(digrams.items(), key=lambda item: item[1], reverse=True)
    dictionary = {digram: chr(256 + i) for i, (digram, _) in enumerate(sorted_digrams[:dictionary_size])}

    return dictionary


# Funkcja do kodowania tekstu za pomocą słownika digramów
def encode_text(text, dictionary):
    encoded_text = text
    for digram, symbol in dictionary.items():
        encoded_text = encoded_text.replace(digram, symbol)
    return encoded_text


# Funkcja do dekodowania tekstu za pomocą słownika digramów
def decode_text(encoded_text, dictionary):
    decoded_text = encoded_text
    reverse_dictionary = {v: k for k, v in dictionary.items()}
    for symbol, digram in reverse_dictionary.items():
        decoded_text = decoded_text.replace(symbol, digram)
    return decoded_text


# Funkcja do wczytania tekstu z pliku
def read_file(file_path):
    with open(file_path, 'r', encoding='utf-8') as file:
        return file.read()


# Funkcja do zapisania tekstu do pliku
def write_file(file_path, text):
    with open(file_path, 'w', encoding='utf-8') as file:
        file.write(text)


# Przykład użycia
if __name__ == "__main__":
    # Ścieżki do plików
    input_file_path = 'input.txt'
    encoded_file_path = 'encoded.txt'
    decoded_file_path = 'decoded.txt'

    # Wczytanie tekstu z pliku
    text = read_file(input_file_path)

    # Tworzenie słownika digramów
    dictionary_size = 256  # Rozmiar słownika
    dictionary = create_digram_dictionary(text, dictionary_size)

    # Kodowanie tekstu
    encoded_text = encode_text(text, dictionary)
    write_file(encoded_file_path, encoded_text)

    # Dekodowanie tekstu
    decoded_text = decode_text(encoded_text, dictionary)
    write_file(decoded_file_path, decoded_text)

    # Analiza stopnia kompresji
    original_size = len(text)
    encoded_size = len(encoded_text)
    compression_ratio = original_size / encoded_size

    print(f'Original size: {original_size}')
    print(f'Encoded size: {encoded_size}')
    print(f'Compression ratio: {compression_ratio:.2f}')

    # Przykład kodowania i dekodowania innego tekstu
    another_text = "This is a different text to analyze compression."
    another_encoded_text = encode_text(another_text, dictionary)
    another_decoded_text = decode_text(another_encoded_text, dictionary)

    print(f'Original another text: {another_text}')
    print(f'Encoded another text: {another_encoded_text}')
    print(f'Decoded another text: {another_decoded_text}')
