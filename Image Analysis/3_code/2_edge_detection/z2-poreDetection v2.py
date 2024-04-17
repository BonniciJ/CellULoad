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

    

    rectifiedIm = (rectifiedIm > 10)  
    

    

    newIm = Image.fromarray(rectifiedIm)
    
    


    frames.append(newIm.convert('P'))

frames[0].save("out2.gif", save_all=True, append_images=frames[1:], duration = 200, loop=0)

for i in range(1, 14):
    im1 = np.asarray(frames[i - 1].getdata()).reshape((im.height, im.width))
    im2 = np.asarray(frames[i].getdata()).reshape((im.height, im.width))
    difference = im2 - im1 
    plt.subplot(4, 4, i)
    plt.title(i)
    plt.imshow(difference, cmap='gray')
plt.show()