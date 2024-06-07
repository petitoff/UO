import numpy as np
import matplotlib.pyplot as plt
from zadanie_3_b import diff_image

def display_difference_image(diff_image):
    # Normalizacja różnic do zakresu [0, 255]
    normalized_diff = ((diff_image - diff_image.min()) / (diff_image.max() - diff_image.min()) * 255).astype(np.uint8)
    plt.imshow(normalized_diff, cmap='gray')
    plt.title('Obraz z tablicy różnic')
    plt.show()

# Przykładowe użycie
display_difference_image(diff_image)
