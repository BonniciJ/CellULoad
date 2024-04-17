from PIL import Image, ImageFilter
import numpy as np
from matplotlib import pyplot as plt
import skimage
import os



def findClosest(regions, targetLoc):
    #Finds the closest region in 'regions' to 'targetLoc'
    #'targetLoc' is a tuple with (x, y)
    minDist = np.inf
    closestIndex = -1
    closest = 0
    
    for i in range(len(regions)):
        r = regions[i].centroid
        xdiff = targetLoc[0] - r[0]
        ydiff = targetLoc[1] - r[1]
        dist = xdiff**2 + ydiff**2
        if dist < minDist:
            minDist = dist
            closestIndex = i
            closest = regions[i]

    return closest, closestIndex


def isolatePores(im):
     im = im.filter(ImageFilter.GaussianBlur(radius=3))
     backgroundlight = im.filter(ImageFilter.GaussianBlur(radius=50))
     imdata = np.asarray(im.getdata()).reshape((im.height, im.width)) 
     bglightdata = np.asarray(backgroundlight.getdata()).reshape((im.height, im.width)) 

     rectifiedIm = bglightdata - imdata 
     rectifiedIm = rectifiedIm * (rectifiedIm > 0) 
     rectifiedIm = (rectifiedIm > 8) 
     rectifiedIm = skimage.morphology.opening(rectifiedIm)

     labeled = skimage.measure.label(rectifiedIm)
     regions = skimage.measure.regionprops(labeled)

     return regions, labeled


#find the file names in the given directory and sort them into alphabetical order, these will be loaded
directory = "Images"
files = sorted(os.listdir(directory))

try:
     ims = [Image.open(directory + "\\" + f).convert('L') for f in files]
     print(f"{len(ims)} Files Loaded")
except Exception as e:
     print("Files failed to load")
     print(e)
     #add something in to handle this error




#select the pore to track in the first image
regions, _ = isolatePores(ims[0])
#Find the region with the largest area
areas = [r.area for r in regions]
sortedAreasIndexs = np.argsort(areas)[::-1]
selectedPore = sortedAreasIndexs[1]
targetPore = regions[selectedPore]


frames = []

width = []
height = []

bbox = targetPore.bbox
height.append(bbox[2] - bbox[0])
width.append(bbox[3] - bbox[1])

for i in range(1, len(ims)):
     regions, labeled = isolatePores(ims[i])

     targetPore, closestIndex = findClosest(regions, targetPore.centroid)

     #add the selected pore image onto the background image
     binaryImage = labeled == closestIndex + 1
     #save the pore images
     bbox = targetPore.bbox
     Image.fromarray(binaryImage[bbox[0]:bbox[2], bbox[1]:bbox[3]]).save(f'{i}.gif')

     outImage = np.where(binaryImage, 1, ims[i])

     newIm = Image.fromarray(outImage)

     #track width and height of box
     bbox = targetPore.bbox
     height.append(bbox[2] - bbox[0])
     width.append(bbox[3] - bbox[1])


     frames.append(newIm.convert('P'))


frames[0].save("130424.gif", save_all=True, append_images=frames[1:], duration = 200, loop=0)


# #convert pixel height and width to mm units
# scaledHeight = []
# for h in height:
#      scaledHeight.append(h * (5/484))

# scaledWidth = []
# for w in width:
#      scaledWidth.append(w * (6/648))

# #plot the change in height and width vs time
# plt.plot(scaledHeight, label='Height')
# plt.plot(scaledWidth, label='width')
# plt.legend()
# plt.title("Width and Height of pore vs time")
# plt.ylabel("Size (mm)")
# plt.xlabel("Time (number of frames)")
# plt.show()
     
     
# #Calculate strain in X and Y as change over original
# strainH = []
# for h in scaledHeight:
#      strainH.append((h - scaledHeight[0] ) / scaledHeight[0])

# strainW = []
# for w in scaledWidth:
#      strainW.append((w - scaledWidth[0]) / scaledWidth[0])

# #plot strain
# plt.plot(strainH, label='Strain in Y')
# plt.plot(strainW, label='Strain in X')
# plt.legend()
# plt.title("Strain in X and Y vs time")
# plt.ylabel("Strain")
# plt.xlabel("Time (number of frames)")
# plt.show()
