import os

for i in range(125, 140):
    os.rename(str(i - 110) + ".png", str(i - 125) + ".png")