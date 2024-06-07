import heapq
from collections import defaultdict, Counter
import os

os.chdir('lista3')


class Node:
    def __init__(self, freq, symbol, left=None, right=None):
        self.freq = freq
        self.symbol = symbol
        self.left = left
        self.right = right
        self.huff = ''

    def __lt__(self, other):
        return self.freq < other.freq


def calculate_entropy(freq_dict, total_symbols):
    import math
    entropy = 0
    for freq in freq_dict.values():
        probability = freq / total_symbols
        entropy -= probability * math.log2(probability)
    return entropy


def calculate_average_code_length(codes, freq_dict, total_symbols):
    avg_length = 0
    for symbol in codes:
        avg_length += len(codes[symbol]) * (freq_dict[symbol] / total_symbols)
    return avg_length


def print_codes(node, val=''):
    huff_codes = {}
    new_val = val + str(node.huff)

    if node.left:
        huff_codes.update(print_codes(node.left, new_val))
    if node.right:
        huff_codes.update(print_codes(node.right, new_val))

    if not node.left and not node.right:
        huff_codes[node.symbol] = new_val

    return huff_codes


def huffman_encoding(data):
    symbol_freq = Counter(data)
    total_symbols = len(data)
    entropy = calculate_entropy(symbol_freq, total_symbols)

    heap = [Node(freq, symbol) for symbol, freq in symbol_freq.items()]
    heapq.heapify(heap)

    while len(heap) > 1:
        left = heapq.heappop(heap)
        right = heapq.heappop(heap)

        left.huff = 0
        right.huff = 1

        new_node = Node(left.freq + right.freq, left.symbol + right.symbol, left, right)
        heapq.heappush(heap, new_node)

    huff_codes = print_codes(heap[0])
    avg_code_length = calculate_average_code_length(huff_codes, symbol_freq, total_symbols)
    redundancy = avg_code_length - entropy

    return huff_codes, avg_code_length, entropy, redundancy


def huffman_compress(file_path):
    with open(file_path, 'r') as file:
        data = file.read()

    huff_codes, avg_length, entropy, redundancy = huffman_encoding(data)

    compressed_data = ''.join(huff_codes[symbol] for symbol in data)

    with open(file_path + '.huff', 'w') as compressed_file:
        compressed_file.write(compressed_data)

    with open(file_path + '_codes.huff', 'w') as code_file:
        code_file.write(str(huff_codes))

    print(f'Średnia długość kodu: {avg_length}')
    print(f'Entropia: {entropy}')
    print(f'Redundancja: {redundancy}')


def huffman_decompress(compressed_file_path, code_file_path):
    with open(code_file_path, 'r') as code_file:
        huff_codes = eval(code_file.read())

    reverse_huff_codes = {v: k for k, v in huff_codes.items()}

    with open(compressed_file_path, 'r') as compressed_file:
        compressed_data = compressed_file.read()

    current_code = ''
    decompressed_data = ''

    for bit in compressed_data:
        current_code += bit
        if current_code in reverse_huff_codes:
            decompressed_data += reverse_huff_codes[current_code]
            current_code = ''

    decompressed_file_path = compressed_file_path.replace('.huff', '_decompressed.txt')

    with open(decompressed_file_path, 'w') as decompressed_file:
        decompressed_file.write(decompressed_data)


# Przykładowe użycie:
# Zakładając, że mamy plik 'example.txt' do skompresowania
huffman_compress('example.txt')
# A następnie zdekompresowanie tego samego pliku
huffman_decompress('example.txt.huff', 'example.txt_codes.huff')
