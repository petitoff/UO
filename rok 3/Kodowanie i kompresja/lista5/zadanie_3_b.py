import numpy as np
from zadanie_3_a import display_image


def calculate_differences(image):
    height, width = image.shape
    diff_image = np.zeros_like(image, dtype=np.int16)
    
    for y in range(height):
        for x in range(1, width):
            diff_image[y, x] = int(image[y, x]) - int(image[y, x-1])
    
    return diff_image

# Przykładowe użycie
img = display_image('Flower_640x500_8bit_Grayscale.raw', 640, 500)
diff_image = calculate_differences(img)
