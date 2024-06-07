import numpy as np
import matplotlib.pyplot as plt
from PIL import Image
import heapq
from collections import defaultdict, Counter


def display_raw_image(filename, width, height):
    with open(filename, 'rb') as file:
        img = np.frombuffer(file.read(), dtype=np.uint8).reshape((height, width))
    plt.imshow(img, cmap='gray')
    plt.title('Oryginalny obraz')
    plt.show()
    return img


# Funkcja do obliczania różnic dla kanałów kolorowych
def calculate_color_differences(image):
    r, g, b = image[:, :, 0], image[:, :, 1], image[:, :, 2]
    diff_r = calculate_differences(r)
    diff_g = calculate_differences(g)
    diff_b = calculate_differences(b)
    return diff_r, diff_g, diff_b


def calculate_differences(image_channel):
    height, width = image_channel.shape
    diff_image = np.zeros_like(image_channel, dtype=np.int16)

    for y in range(height):
        for x in range(1, width):
            diff_image[y, x] = int(image_channel[y, x]) - int(image_channel[y, x - 1])

    return diff_image


# Funkcja do wyświetlania obrazów różnicowych
def display_difference_image(diff_image):
    # Normalizacja różnic do zakresu [0, 255]
    normalized_diff = ((diff_image - diff_image.min()) / (diff_image.max() - diff_image.min()) * 255).astype(np.uint8)
    plt.imshow(normalized_diff, cmap='gray')
    plt.title('Obraz z tablicy różnic')
    plt.show()


# Funkcja do odtwarzania oryginalnego obrazu z tablic różnic
def reconstruct_color_image(diff_r, diff_g, diff_b):
    reconstructed_r = reconstruct_image(diff_r)
    reconstructed_g = reconstruct_image(diff_g)
    reconstructed_b = reconstruct_image(diff_b)

    reconstructed_image = np.stack((reconstructed_r, reconstructed_g, reconstructed_b), axis=-1)
    return reconstructed_image


def reconstruct_image(diff_image):
    height, width = diff_image.shape
    reconstructed_image = np.zeros_like(diff_image, dtype=np.uint8)

    for y in range(height):
        reconstructed_image[y, 0] = diff_image[y, 0]
        for x in range(1, width):
            reconstructed_image[y, x] = (reconstructed_image[y, x - 1] + diff_image[y, x]) % 256

    return reconstructed_image


# Funkcje do kodowania Huffmana
class Node:
    def __init__(self, freq, symbol, left=None, right=None):
        self.freq = freq
        self.symbol = symbol
        self.left = left
        self.right = right
        self.huff = ''

    def __lt__(self, other):
        return self.freq < other.freq


def calculate_probabilities(data):
    total_symbols = len(data)
    symbol_freq = Counter(data)
    probabilities = {symbol: freq / total_symbols for symbol, freq in symbol_freq.items()}
    return probabilities


def huffman_encoding(data):
    symbol_freq = Counter(data)
    heap = [Node(freq, symbol) for symbol, freq in symbol_freq.items()]
    heapq.heapify(heap)

    while len(heap) > 1:
        left = heapq.heappop(heap)
        right = heapq.heappop(heap)

        left.huff = 0
        right.huff = 1

        new_node = Node(left.freq + right.freq, left.symbol + right.symbol, left, right)
        heapq.heappush(heap, new_node)

    huff_codes = {}

    def generate_codes(node, val=''):
        new_val = val + str(node.huff)
        if node.left:
            generate_codes(node.left, new_val)
        if node.right:
            generate_codes(node.right, new_val)
        if not node.left and not node.right:
            huff_codes[node.symbol] = new_val

    generate_codes(heap[0])
    return huff_codes


def encode_data(data, huff_codes):
    return ''.join(huff_codes[symbol] for symbol in data)


def huffman_compress(data):
    probabilities = calculate_probabilities(data)
    huff_codes = huffman_encoding(data)
    compressed_data = encode_data(data, huff_codes)
    return compressed_data, huff_codes


def calculate_compression_ratio(original_data, compressed_data):
    original_size = len(original_data) * 8  # in bits
    compressed_size = len(compressed_data)  # in bits
    return original_size / compressed_size


# Przykładowe użycie
image_path = 'Flower_640x500_8bit_Grayscale.raw'
image_np = display_raw_image(image_path, 640, 500)

# Aby kontynuować zadanie 4, musimy przekonwertować obraz na RGB (potrójny kanał)
# dla kodowania Huffmana, co nie jest standardową operacją dla obrazów w skali szarości.
# Zrobimy sztuczny kanał kolorowy (kopiowanie kanału szarości do R, G, B) do demonstracji.

image_color = np.stack((image_np, image_np, image_np), axis=-1)

# Obliczanie tablic różnic dla R, G i B
diff_r, diff_g, diff_b = calculate_color_differences(image_color)

# Wyświetlanie obrazów różnicowych
display_difference_image(diff_r)
display_difference_image(diff_g)
display_difference_image(diff_b)

# Kodowanie Huffmana i obliczanie stopnia kompresji
original_data = image_color.flatten().tolist()
compressed_data, huff_codes = huffman_compress(original_data)
compression_ratio_original = calculate_compression_ratio(original_data, compressed_data)

diff_data_r = diff_r.flatten().tolist()
diff_data_g = diff_g.flatten().tolist()
diff_data_b = diff_b.flatten().tolist()

compressed_diff_data_r, diff_huff_codes_r = huffman_compress(diff_data_r)
compressed_diff_data_g, diff_huff_codes_g = huffman_compress(diff_data_g)
compressed_diff_data_b, diff_huff_codes_b = huffman_compress(diff_data_b)

compression_ratio_diff_r = calculate_compression_ratio(diff_data_r, compressed_diff_data_r)
compression_ratio_diff_g = calculate_compression_ratio(diff_data_g, compressed_diff_data_g)
compression_ratio_diff_b = calculate_compression_ratio(diff_data_b, compressed_diff_data_b)

print(f'Stopień kompresji oryginalnego obrazu: {compression_ratio_original}')
print(f'Stopień kompresji obrazu po predykcji R: {compression_ratio_diff_r}')
print(f'Stopień kompresji obrazu po predykcji G: {compression_ratio_diff_g}')
print(f'Stopień kompresji obrazu po predykcji B: {compression_ratio_diff_b}')

# Odtwarzanie oryginalnego obrazu z tablic różnic
reconstructed_color_image = reconstruct_color_image(diff_r, diff_g, diff_b)
plt.imshow(reconstructed_color_image)
plt.title('Odtworzony obraz kolorowy')
plt.show()
