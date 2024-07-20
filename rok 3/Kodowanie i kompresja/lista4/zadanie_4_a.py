from collections import defaultdict


def calculate_probabilities(data):
    total_symbols = len(data)
    symbol_freq = defaultdict(int)

    for symbol in data:
        symbol_freq[symbol] += 1

    probabilities = {symbol: freq / total_symbols for symbol, freq in symbol_freq.items()}
    return probabilities


def encode_arithmetic(data, probabilities):
    low = 0.0
    high = 1.0

    for symbol in data:
        current_range = high - low
        high = low + current_range * sum(probabilities[s] for s in probabilities if s <= symbol)
        low = low + current_range * sum(probabilities[s] for s in probabilities if s < symbol)

    return (low + high) / 2


def decode_arithmetic(encoded_value, probabilities, length):
    decoded_output = ''
    low = 0.0
    high = 1.0

    for _ in range(length):
        current_range = high - low
        value = (encoded_value - low) / current_range

        for symbol, prob in probabilities.items():
            high_range = low + current_range * sum(probabilities[s] for s in probabilities if s <= symbol)
            low_range = low + current_range * sum(probabilities[s] for s in probabilities if s < symbol)

            if low_range <= encoded_value < high_range:
                decoded_output += symbol
                low = low_range
                high = high_range
                break

    return decoded_output


data = "ccabbccaabbaacc"
probabilities = calculate_probabilities(data)
encoded_value = encode_arithmetic(data, probabilities)
decoded_data = decode_arithmetic(encoded_value, probabilities, len(data))

print(f"Zakodowana wartość: {encoded_value}")
print(f"Odkodowana wartość: {decoded_data}")
