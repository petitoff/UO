import numpy as np
import matplotlib.pyplot as plt

from lista5.zadanie_3_b import diff_image

def reconstruct_image(diff_image):
    height, width = diff_image.shape
    reconstructed_image = np.zeros_like(diff_image, dtype=np.uint8)

    for y in range(height):
        reconstructed_image[y, 0] = diff_image[y, 0]
        for x in range(1, width):
            reconstructed_image[y, x] = (reconstructed_image[y, x - 1] + diff_image[y, x]) % 256

    return reconstructed_image


# Przykładowe użycie
reconstructed_image = reconstruct_image(diff_image)
plt.imshow(reconstructed_image, cmap='gray')
plt.title('Odtworzony obraz')
plt.show()
