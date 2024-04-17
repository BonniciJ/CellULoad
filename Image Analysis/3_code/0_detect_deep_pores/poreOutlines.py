from PIL import Image
import numpy as np
from matplotlib import pyplot as plt
import skimage

im = Image.open("start.png").convert('L') #open the image as greyscale

imdata = im.getdata()

#store the image data in a np array
imdata = np.asarray(imdata)
imdata = imdata.reshape((im.height, im.width))

#show the initial image as greyscale
plt.subplot(1, 2, 1)
plt.axis('off')
plt.imshow(imdata, cmap='gray')


imdata = (imdata < 90) #arbitary thresholding - todo find the right threshold



imdata = skimage.morphology.opening(imdata) #binary opening 



imdata = skimage.morphology.closing(imdata) #binary closing 
plt.subplot(1, 2, 2)
plt.axis('off')
plt.imshow(imdata, cmap='gray')

plt.show()
