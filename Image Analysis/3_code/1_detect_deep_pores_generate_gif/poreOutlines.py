from PIL import Image, ImageFilter
import numpy as np
from matplotlib import pyplot as plt
import skimage

frames = []

for i in range(0, 15):
    im = Image.open(str(i) + ".png").convert('L')
    im = im.filter(ImageFilter.GaussianBlur(radius=3))
    imdata = im.getdata()
    

    #store the image data in a np array
    imdata = np.asarray(imdata).reshape((im.height, im.width))

    imdata = (imdata < 100) #arbitary thresholding - todo find the right threshold
    
    frames.append(Image.fromarray(imdata).convert('P'))

frames[0].save("out.gif", save_all=True, append_images=frames[1:], duration = 100, loop=0)
