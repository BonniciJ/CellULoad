from PIL import Image, ImageFilter
import numpy as np
from matplotlib import pyplot as plt
import skimage

frames = []

for i in range(0, 15):
    im = Image.open(str(i) + ".png")


    frames.append(im)

frames[0].save("original.gif", save_all=True, append_images=frames[1:], duration = 200, loop=0)
