from PIL import Image, ImageFilter
import numpy as np
from matplotlib import pyplot as plt
import skimage

frames = []

for i in range(0, 15):
    im = Image.open(str(i) + ".png").convert('L')
    im = im.filter(ImageFilter.GaussianBlur(radius=3))
    backgroundlight = im.filter(ImageFilter.GaussianBlur(radius=50))

    imdata = np.asarray(im.getdata()).reshape((im.height, im.width)) 
    bglightdata = np.asarray(backgroundlight.getdata()).reshape((im.height, im.width)) 

    rectifiedIm = bglightdata - imdata 

    rectifiedIm = rectifiedIm * (rectifiedIm > 0)  
    normFactor = 1/np.max(rectifiedIm)
    rectifiedIm = rectifiedIm * normFactor

    plt.subplot(1, 2, 1)
    plt.imshow(rectifiedIm)

    rectifiedIm = skimage.feature.canny(rectifiedIm, sigma=3)
    plt.subplot(1, 2, 2)
    plt.imshow(rectifiedIm)
    plt.show()

    newIm = Image.fromarray(rectifiedIm)
    


    frames.append(newIm.convert('P'))

frames[0].save("out.gif", save_all=True, append_images=frames[1:], duration = 200, loop=0)
