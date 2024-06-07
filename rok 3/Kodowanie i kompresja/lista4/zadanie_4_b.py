def float_to_binary(value, precision=32):
    binary = ""
    while value > 0 and len(binary) < precision:
        value *= 2
        if value >= 1:
            binary += '1'
            value -= 1
        else:
            binary += '0'
    return binary

def binary_to_float(binary):
    value = 0.0
    for i, bit in enumerate(binary):
        if bit == '1':
            value += 2 ** -(i + 1)
    return value

def encode_arithmetic_binary(data, probabilities):
    encoded_value = encode_arithmetic(data, probabilities)
    binary_code = float_to_binary(encoded_value)
    return binary_code

def decode_arithmetic_binary(binary_code, probabilities, length):
    encoded_value = binary_to_float(binary_code)
    decoded_data = decode_arithmetic(encoded_value, probabilities, length)
    return decoded_data

# Przykładowe użycie:
from zadanie_4_a import calculate_probabilities, encode_arithmetic, decode_arithmetic

data = "hello"
probabilities = calculate_probabilities(data)

binary_code = encode_arithmetic_binary(data, probabilities)
decoded_data_binary = decode_arithmetic_binary(binary_code, probabilities, len(data))

print(f"Kod binarny: {binary_code}")
print(f"Odkodowana wartość (z binarnego): {decoded_data_binary}")
