from PIL import Image, ImageFilter
import numpy as np
from matplotlib import pyplot as plt
import skimage

frames = []

for i in range(0, 15):
    im = Image.open(str(i) + ".png").convert('L')
    im = im.filter(ImageFilter.GaussianBlur(radius=3))
    imdata = np.asarray(im.getdata()).reshape((im.height, im.width)) 

    c = 1
    plt.subplot(3, 4, c)
    plt.title("original")
    plt.imshow(im)
    
    for r in range(0, 100, 10):
        c = c + 1
        backgroundlight = im.filter(ImageFilter.GaussianBlur(radius=r))
        bglightdata = np.asarray(backgroundlight.getdata()).reshape((im.height, im.width)) 

        rectifiedIm = bglightdata - imdata 

        rectifiedIm = rectifiedIm * (rectifiedIm > 0)  
    #normFactor = 1/np.max(rectifiedIm)
    #rectifiedIm = rectifiedIm * normFactor

        plt.subplot(3, 4, c)
        plt.title(r)
        plt.imshow(rectifiedIm)


    plt.show()

    newIm = Image.fromarray(rectifiedIm)
    


    frames.append(newIm.convert('P'))

frames[0].save("out.gif", save_all=True, append_images=frames[1:], duration = 200, loop=0)
