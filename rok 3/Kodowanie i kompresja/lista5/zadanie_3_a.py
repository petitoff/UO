import numpy as np
import matplotlib.pyplot as plt


def display_image(filename, width, height):
    with open(filename, 'rb') as file:
        img = np.frombuffer(file.read(), dtype=np.uint8).reshape((height, width))
    plt.imshow(img, cmap='gray')
    plt.title('Oryginalny obraz')
    plt.show()
    return img


# Przykładowe użycie
img = display_image('Flower_640x500_8bit_Grayscale.raw', 640, 500)
