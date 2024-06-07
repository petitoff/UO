import tkinter as tk
from PIL import Image, ImageTk
import numpy as np


class ProgressiveImage:
    def __init__(self, root, image_path, num_approximations):
        self.root = root
        self.image = Image.open(image_path)
        self.image_array = np.array(self.image)
        self.num_approximations = num_approximations
        self.current_approximation = 0
        self.label = tk.Label(root)
        self.label.pack()
        self.button = tk.Button(root, text="Show next approximation", command=self.show_next_approximation)
        self.button.pack()

    def show_next_approximation(self):
        if self.current_approximation < self.num_approximations:
            approx_image = self.approximate_image(self.current_approximation)
            self.display_image(approx_image)
            self.current_approximation += 1

    def approximate_image(self, level):
        factor = 2 ** (self.num_approximations - level - 1)
        small_image = self.image.resize((self.image.width // factor, self.image.height // factor), Image.LANCZOS)
        return small_image.resize(self.image.size, Image.NEAREST)

    def display_image(self, image):
        tk_image = ImageTk.PhotoImage(image)
        self.label.config(image=tk_image)
        self.label.image = tk_image


if __name__ == "__main__":
    root = tk.Tk()
    root.title("Progressive Image Display")
    image_path = "image.jpg"  # Ścieżka do twojego obrazu
    num_approximations = 5  # Liczba aproksymacji
    app = ProgressiveImage(root, image_path, num_approximations)
    root.mainloop()
