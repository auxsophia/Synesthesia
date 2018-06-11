# Synesthesia
Created in fulfillment of the fall 2015 senior design course.

Author: **Elliott Ploutz**

Developed using Windows 10 and Microsoft Visual Studio 2015.

This software is licensed under the **GNU GPLv3** (free software license).

The software has two major components: *Soundage* and *ColorFull*.

## Soundage:
The user uploads an image, .jpg, .png, .bmp, and a .wav file. The wave file can be of 16 bit or 8 bit depth, but must have a PCM format (format code 1) and 1 channel (mono). The necessary header information and audio data is encoded in the least significant bits of the image. In more detail, each pixel has a red, green, and blue byte value to represent color. Bitwise operators are used to get the individual bits making up an audio file. These bits are compared to the least significant bit of the RGB values of the pixel and adjusted if needed. Once the image is encrypted, we can extract the least significant bits of the image and reconstruct the data. The audio file is thus recovered.

## ColorFull:
The user uploads an image and clicks on a pixel. The program computes what the name of the color is. The way to think about this is to make the red, green, and blue values into a 3 dimensional cube. That pixel can then be placed as a point in the cube. There are several hundred named colors, but in terms of possible colors, this is only 0.00004%. The program finds the distance of the selected point against all other named points. The least distance to a named point is the color it is most similar too. Of course, 0 distance implies that is the precise color. 

## Audio files:
This program works well with Audacity. A user can record audio and export the audio file as a .wav file. The information bar should be set to 
Windows WASAPI, Mono Recording Channel.
The audio type should be 16-bit PCM. This can be specified from the drop down menu when exporting/saving.

The project rate/sample rate tends to be lower as the data is smaller and can be more easily stored in small images.

To get .wav files at a smaller (but less quality) rate, record in the above. The sample rate should be set to 11,025. When exporting:
File > Export > Other Uncompressed Files > Options > WAV Microsoft > Encoding > Unsigned 8 bit PCM.

## Below is the information shown on the poster for the project:

https://raw.githubusercontent.com/auxsophia/Synesthesia/master/poster.PNG

## Visual-Audio Synesthesia

A large part of computer interaction can easily be made accessible for people with visual disabilities. One instance is dealing with images. The current way many blind users interact with images on the web is through the alt-attribute defined in the surrounding text. Screen readers will read the alt-attribute to give the user the semantic content of the image. However, these alt-attributes are webpage dependent and vary greatly between websites. 

What this program does is store the binary data of an audio file directly in an image. The encoded data is stored in the least significant bit of each pixel's red, green, and blue values. When the image is loaded, the program extracts the data from each pixel and reconstructs the original audio file which is then played. Ideally, the audio file would be a short and accurate description of the image or a personal message. The image is not noticeably distorted and the message is available offline, even when saved in an album. This accessibility can be added to current image file types without the need of creating something entirely new.

## ColorFull

Approximately 8% of men and 0.5% of women are colorblind in some way (1). The most common color blindness is a reduced sensitivity to one of the three primary colors of light, red, green, or blue. In very rare cases, a person can be a monochromat, who sees the world in shades of grey. In cases of confusion, the user can load an image and click on a troublesome spot; ColorFull finds the name of a color in question. 

## The Algorithm

The algorithm assumes the RGB color model for a given image. The red, green, and blue values of a pixel can be mixed to form 16,777,216 unique colors. Humans have named a mere several hundred colors. My color table consists of almost 600 named colors, which is only 0.00004% of colors. Few colors in an image will have a specific name attached. However, giving the red, green, and blue values of a pixel will be meaningless to the average person. The solution is to view the red, green, and blue values as a three dimensional cube with the three axes corresponding to the colors. When a pixel is clicked, the values of that pixel are "placed" in the cube by computing the three dimensional distance to all colors in the color table. The nearest named color point is the most similar. Because some named colors are obscure, the cube is also broken into eight regions: white, black, red, green, blue, cyan, magenta, and yellow. The region is given along with the specific color name.

## Further Implementation

The audio encoding can be expanded to audio file types beyond wav files. The decoder can be installed alongside a web browser. In a phone app, a picture can be taken and immediately encoded with audio using the built in recorder functionality.

Current plans are to build ColorFull as a Chrome-Extension (or would it be a *Chroma*-Extension?) which anyone with a Chrome browser could download and use. 

1) http://www.colourblindawareness.org/colour-blindness/types-of-colour-blindness/
