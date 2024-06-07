import heapq
from collections import Counter

from lista5.zadanie_3_b import diff_image, img


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
original_data = img.flatten().tolist()
compressed_data, huff_codes = huffman_compress(original_data)
compression_ratio_original = calculate_compression_ratio(original_data, compressed_data)

diff_data = diff_image.flatten().tolist()
compressed_diff_data, diff_huff_codes = huffman_compress(diff_data)
compression_ratio_diff = calculate_compression_ratio(diff_data, compressed_diff_data)

print(f'Stopień kompresji oryginalnego obrazu: {compression_ratio_original}')
print(f'Stopień kompresji obrazu po predykcji: {compression_ratio_diff}')
