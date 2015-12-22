/*
Author: Elliott Ploutz
Email: ploutze@unlv.nevada.edu

This class statically creates a table of colors with limited query functionality. For each color,
a 3D distance is computed relative to a passed color. The red, green, and blue values can be mapped 
to a three dimensional space. By comparing the distance of two points, or two colors, we can say 
that the two colors are in a similar region, thus a similar color. The least distance identifies
that color as most similar.

All rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace synesthesia
{
    public class DRGBNcolors
    {
        public struct DRGBName
        {
            public int red;
            public int green;
            public int blue;
            public string colorName;

            public DRGBName(int r, int g, int b, string name)
            {
                red = r;
                green = g;
                blue = b;
                colorName = name;
            }
        }

        // A modified version of http://cgit.freedesktop.org/xorg/app/rgb/tree/rgb.txt
        public static DRGBName[] colorTable = new DRGBName[603]
        {
            new DRGBName(0, 0, 0, "black"),
            new DRGBName(0, 0, 128, "Navy Blue"),
            new DRGBName(0, 0, 139, "Dark Blue"),
            new DRGBName(0, 0, 205, "Medium Blue"),
            new DRGBName(0, 0, 238, "blue 2"),
            new DRGBName(0, 0, 255, "blue"),
            new DRGBName(0, 100, 0, "Dark Green"),
            new DRGBName(0, 104, 139, "Deep Sky Blue 4"),
            new DRGBName(0, 134, 139, "turquoise 4"),
            new DRGBName(0, 139, 0, "green 4"),
            new DRGBName(0, 139, 139, "Dark Cyan"),
            new DRGBName(0, 139, 69, "Spring Green 4"),
            new DRGBName(0, 154, 205, "Deep Sky Blue 3"),
            new DRGBName(0, 178, 238, "Deep Sky Blue 2"),
            new DRGBName(0, 191, 255, "Deep Sky Blue"),
            new DRGBName(0, 197, 205, "turquoise 3"),
            new DRGBName(0, 205, 0, "green 3"),
            new DRGBName(0, 205, 102, "Spring Green 3"),
            new DRGBName(0, 205, 205, "cyan 3"),
            new DRGBName(0, 206, 209, "Dark Turquoise"),
            new DRGBName(0, 229, 238, "turquoise 2"),
            new DRGBName(0, 238, 0, "green 2"),
            new DRGBName(0, 238, 118, "Spring Green 2"),
            new DRGBName(0, 238, 238, "cyan 2"),
            new DRGBName(0, 245, 255, "turquoise 1"),
            new DRGBName(0, 250, 154, "medium spring green"),
            new DRGBName(0, 255, 0, "green"),
            new DRGBName(0, 255, 127, "spring green"),
            new DRGBName(0, 255, 255, "cyan"),
            new DRGBName(3, 3, 3, "gray 1"),
            new DRGBName(3, 3, 3, "grey 1"),
            new DRGBName(5, 5, 5, "gray 2"),
            new DRGBName(5, 5, 5, "grey 2"),
            new DRGBName(8, 8, 8, "gray 3"),
            new DRGBName(8, 8, 8, "grey 3"),
            new DRGBName(10, 10, 10, "gray 4"),
            new DRGBName(10, 10, 10, "grey 4"),
            new DRGBName(13, 13, 13, "gray 5"),
            new DRGBName(13, 13, 13, "grey 5"),
            new DRGBName(15, 15, 15, "gray 6"),
            new DRGBName(15, 15, 15, "grey 6"),
            new DRGBName(16, 78, 139, "Dodger Blue 4"),
            new DRGBName(18, 18, 18, "gray 7"),
            new DRGBName(18, 18, 18, "grey 7"),
            new DRGBName(20, 20, 20, "gray 8"),
            new DRGBName(20, 20, 20, "grey 8"),
            new DRGBName(23, 23, 23, "gray 9"),
            new DRGBName(23, 23, 23, "grey 9"),
            new DRGBName(24, 116, 205, "Dodger Blue 3"),
            new DRGBName(25, 25, 112, "midnight blue"),
            new DRGBName(26, 26, 26, "gray 10"),
            new DRGBName(26, 26, 26, "grey 10"),
            new DRGBName(28, 134, 238, "Dodger Blue 2"),
            new DRGBName(28, 28, 28, "gray 11"),
            new DRGBName(28, 28, 28, "grey 11"),
            new DRGBName(30, 144, 255, "Dodger Blue"),
            new DRGBName(31, 31, 31, "gray 12"),
            new DRGBName(31, 31, 31, "grey 12"),
            new DRGBName(32, 178, 170, "light sea green"),
            new DRGBName(33, 33, 33, "gray 13"),
            new DRGBName(33, 33, 33, "grey 13"),
            new DRGBName(34, 139, 34, "forest green"),
            new DRGBName(36, 36, 36, "gray 14"),
            new DRGBName(36, 36, 36, "grey 14"),
            new DRGBName(38, 38, 38, "gray 15"),
            new DRGBName(38, 38, 38, "grey 15"),
            new DRGBName(39, 64, 139, "Royal Blue 4"),
            new DRGBName(41, 41, 41, "gray 16"),
            new DRGBName(41, 41, 41, "grey 16"),
            new DRGBName(43, 43, 43, "gray 17"),
            new DRGBName(43, 43, 43, "grey 17"),
            new DRGBName(46, 139, 87, "sea green"),
            new DRGBName(46, 46, 46, "gray 18"),
            new DRGBName(46, 46, 46, "grey 18"),
            new DRGBName(47, 79, 79, "dark slate gray"),
            new DRGBName(48, 48, 48, "gray 19"),
            new DRGBName(48, 48, 48, "grey 19"),
            new DRGBName(50, 205, 50, "lime green"),
            new DRGBName(51, 51, 51, "gray 20"),
            new DRGBName(51, 51, 51, "grey 20"),
            new DRGBName(54, 100, 139, "Steel Blue 4"),
            new DRGBName(54, 54, 54, "gray 21"),
            new DRGBName(54, 54, 54, "grey 21"),
            new DRGBName(56, 56, 56, "gray 22"),
            new DRGBName(56, 56, 56, "grey 22"),
            new DRGBName(58, 95, 205, "Royal Blue 3"),
            new DRGBName(59, 59, 59, "gray 23"),
            new DRGBName(59, 59, 59, "grey 23"),
            new DRGBName(60, 179, 113, "medium sea green"),
            new DRGBName(61, 61, 61, "gray 24"),
            new DRGBName(61, 61, 61, "grey 24"),
            new DRGBName(64, 224, 208, "turquoise"),
            new DRGBName(64, 64, 64, "gray 25"),
            new DRGBName(64, 64, 64, "grey 25"),
            new DRGBName(65, 105, 225, "royal blue"),
            new DRGBName(66, 66, 66, "gray 26"),
            new DRGBName(66, 66, 66, "grey 26"),
            new DRGBName(67, 110, 238, "Royal Blue 2"),
            new DRGBName(67, 205, 128, "Sea Green 3"),
            new DRGBName(69, 139, 0, "chartreuse 4"),
            new DRGBName(69, 139, 116, "aquamarine 4"),
            new DRGBName(69, 69, 69, "gray 27"),
            new DRGBName(69, 69, 69, "grey 27"),
            new DRGBName(70, 130, 180, "steel blue"),
            new DRGBName(71, 71, 71, "gray 28"),
            new DRGBName(71, 71, 71, "grey 28"),
            new DRGBName(72, 118, 255, "Royal Blue 1"),
            new DRGBName(72, 209, 204, "medium turquoise"),
            new DRGBName(72, 61, 139, "dark slate blue"),
            new DRGBName(74, 112, 139, "Sky Blue 4"),
            new DRGBName(74, 74, 74, "gray 29"),
            new DRGBName(74, 74, 74, "grey 29"),
            new DRGBName(77, 77, 77, "gray 30"),
            new DRGBName(77, 77, 77, "grey 30"),
            new DRGBName(78, 238, 148, "Sea Green 2"),
            new DRGBName(79, 148, 205, "Steel Blue 3"),
            new DRGBName(79, 79, 79, "gray 31"),
            new DRGBName(79, 79, 79, "grey 31"),
            new DRGBName(82, 139, 139, "Dark Slate Gray 4"),
            new DRGBName(82, 82, 82, "gray 32"),
            new DRGBName(82, 82, 82, "grey 32"),
            new DRGBName(83, 134, 139, "Cadet Blue 4"),
            new DRGBName(84, 139, 84, "Pale Green 4"),
            new DRGBName(84, 255, 159, "Sea Green 1"),
            new DRGBName(84, 84, 84, "gray 33"),
            new DRGBName(84, 84, 84, "grey 33"),
            new DRGBName(85, 107, 47, "dark olive green"),
            new DRGBName(85, 26, 139, "purple 4"),
            new DRGBName(87, 87, 87, "gray 34"),
            new DRGBName(87, 87, 87, "grey 34"),
            new DRGBName(89, 89, 89, "gray 35"),
            new DRGBName(89, 89, 89, "grey 35"),
            new DRGBName(92, 172, 238, "Steel Blue 2"),
            new DRGBName(92, 92, 92, "gray 36"),
            new DRGBName(92, 92, 92, "grey 36"),
            new DRGBName(93, 71, 139, "Medium Purple 4"),
            new DRGBName(94, 94, 94, "gray 37"),
            new DRGBName(94, 94, 94, "grey 37"),
            new DRGBName(95, 158, 160, "cadet blue"),
            new DRGBName(96, 123, 139, "Light Sky Blue 4"),
            new DRGBName(97, 97, 97, "gray 38"),
            new DRGBName(97, 97, 97, "grey 38"),
            new DRGBName(99, 184, 255, "Steel Blue 1"),
            new DRGBName(99, 99, 99, "gray 39"),
            new DRGBName(99, 99, 99, "grey 39"),
            new DRGBName(100, 149, 237, "cornflower blue"),
            new DRGBName(102, 102, 102, "gray 40"),
            new DRGBName(102, 102, 102, "grey 40"),
            new DRGBName(102, 139, 139, "Pale Turquoise 4"),
            new DRGBName(102, 205, 0, "chartreuse 3"),
            new DRGBName(102, 205, 170, "medium aquamarine"),
            new DRGBName(104, 131, 139, "Light Blue 4"),
            new DRGBName(104, 34, 139, "Dark Orchid 4"),
            new DRGBName(105, 105, 105, "dim gray"),
            new DRGBName(105, 105, 105, "dim grey"),
            new DRGBName(105, 139, 105, "Dark Sea Green 4"),
            new DRGBName(105, 139, 34, "Olive Drab 4"),
            new DRGBName(105, 89, 205, "slate blue 3"),
            new DRGBName(106, 90, 205, "slate blue"),
            new DRGBName(106, 90, 205, "slate blue"),
            new DRGBName(107, 107, 107, "gray 42"),
            new DRGBName(107, 107, 107, "grey 42"),
            new DRGBName(107, 142, 35, "olive drab"),
            new DRGBName(108, 123, 139, "Slate Gray 4"),
            new DRGBName(108, 166, 205, "Sky Blue 3"),
            new DRGBName(110, 110, 110, "gray 43"),
            new DRGBName(110, 110, 110, "grey 43"),
            new DRGBName(110, 123, 139, "Light Steel Blue 4"),
            new DRGBName(110, 139, 61, "Dark Olive Green 4"),
            new DRGBName(112, 112, 112, "gray 44"),
            new DRGBName(112, 112, 112, "grey 44"),
            new DRGBName(112, 128, 144, "slate gray"),
            new DRGBName(115, 115, 115, "gray 45"),
            new DRGBName(115, 115, 115, "grey 45"),
            new DRGBName(117, 117, 117, "gray 46"),
            new DRGBName(117, 117, 117, "grey 46"),
            new DRGBName(118, 238, 0, "chartreuse 2"),
            new DRGBName(118, 238, 198, "aquamarine 2"),
            new DRGBName(119, 136, 153, "light slate gray"),
            new DRGBName(120, 120, 120, "gray 47"),
            new DRGBName(120, 120, 120, "grey 47"),
            new DRGBName(121, 205, 205, "Dark Slate Gray 3"),
            new DRGBName(122, 103, 238, "Slate Blue 2"),
            new DRGBName(122, 122, 122, "gray 48"),
            new DRGBName(122, 122, 122, "grey 48"),
            new DRGBName(122, 139, 139, "Light Cyan 4"),
            new DRGBName(122, 197, 205, "Cadet Blue 3"),
            new DRGBName(122, 55, 139, "Medium Orchid 4"),
            new DRGBName(123, 104, 238, "medium slate blue"),
            new DRGBName(124, 205, 124, "Pale Green 3"),
            new DRGBName(124, 252, 0, "lawn green"),
            new DRGBName(125, 125, 125, "gray 49"),
            new DRGBName(125, 125, 125, "grey 49"),
            new DRGBName(125, 38, 205, "purple 3"),
            new DRGBName(126, 192, 238, "Sky Blue 2"),
            new DRGBName(127, 127, 127, "gray 50"),
            new DRGBName(127, 127, 127, "grey 50"),
            new DRGBName(127, 255, 0, "chartreuse"),
            new DRGBName(127, 255, 212, "aquamarine"),
            new DRGBName(130, 130, 130, "gray 51"),
            new DRGBName(130, 130, 130, "grey 51"),
            new DRGBName(131, 111, 255, "Slate Blue 1"),
            new DRGBName(131, 139, 131, "honeydew 4"),
            new DRGBName(131, 139, 139, "azure 4"),
            new DRGBName(132, 112, 255, "light slate blue"),
            new DRGBName(133, 133, 133, "gray 52"),
            new DRGBName(133, 133, 133, "grey 52"),
            new DRGBName(135, 135, 135, "gray 53"),
            new DRGBName(135, 135, 135, "grey 53"),
            new DRGBName(135, 206, 235, "sky blue"),
            new DRGBName(135, 206, 250, "light sky blue"),
            new DRGBName(135, 206, 255, "Sky Blue 1"),
            new DRGBName(137, 104, 205, "Medium Purple 3"),
            new DRGBName(138, 138, 138, "gray 54"),
            new DRGBName(138, 138, 138, "grey 54"),
            new DRGBName(138, 43, 226, "blue violet"),
            new DRGBName(139, 0, 0, "dark red"),
            new DRGBName(139, 0, 139, "dark magenta"),
            new DRGBName(139, 101, 8, "Dark Goldenrod 4"),
            new DRGBName(139, 102, 139, "plum 4"),
            new DRGBName(139, 105, 105, "Rosy Brown 4"),
            new DRGBName(139, 105, 20, "goldenrod 4"),
            new DRGBName(139, 10, 80, "Deep Pink 4"),
            new DRGBName(139, 115, 85, "burlywood 4"),
            new DRGBName(139, 117, 0, "gold4"),
            new DRGBName(139, 119, 101, "Peach Puff 4"),
            new DRGBName(139, 121, 94, "Navajo White 4"),
            new DRGBName(139, 123, 139, "thistle 4"),
            new DRGBName(139, 125, 107, "bisque 4"),
            new DRGBName(139, 125, 123, "Misty Rose 4"),
            new DRGBName(139, 126, 102, "wheat 4"),
            new DRGBName(139, 129, 76, "Light Goldenrod 4"),
            new DRGBName(139, 131, 120, "Antique White 4"),
            new DRGBName(139, 131, 134, "Lavender Blush 4"),
            new DRGBName(139, 134, 130, "seashell 4"),
            new DRGBName(139, 134, 78, "khaki 4"),
            new DRGBName(139, 136, 120, "cornsilk 4"),
            new DRGBName(139, 137, 112, "Lemon Chiffon 4"),
            new DRGBName(139, 137, 137, "snow 4"),
            new DRGBName(139, 139, 0, "yellow 4"),
            new DRGBName(139, 139, 122, "Light Yellow 4"),
            new DRGBName(139, 139, 131, "ivory 4"),
            new DRGBName(139, 26, 26, "firebrick 4"),
            new DRGBName(139, 28, 98, "maroon 4"),
            new DRGBName(139, 34, 82, "Violet Red 4"),
            new DRGBName(139, 35, 35, "brown 4"),
            new DRGBName(139, 37, 0, "Orange Red 4"),
            new DRGBName(139, 54, 38, "tomato 4"),
            new DRGBName(139, 58, 58, "Indian Red 4"),
            new DRGBName(139, 58, 98, "Hot Pink 4"),
            new DRGBName(139, 62, 47, "coral 4"),
            new DRGBName(139, 69, 0, "Dark Orange 4"),
            new DRGBName(139, 69, 19, "saddle brown"),
            new DRGBName(139, 71, 137, "orchid 4"),
            new DRGBName(139, 71, 38, "sienna 4"),
            new DRGBName(139, 71, 93, "Pale Violet Red 4"),
            new DRGBName(139, 76, 57, "salmon 4"),
            new DRGBName(139, 87, 66, "Light Salmon 4"),
            new DRGBName(139, 90, 0, "orange 4"),
            new DRGBName(139, 90, 43, "tan 4"),
            new DRGBName(139, 95, 101, "Light Pink 4"),
            new DRGBName(139, 99, 108, "pink 4"),
            new DRGBName(140, 140, 140, "gray 55"),
            new DRGBName(140, 140, 140, "grey 55"),
            new DRGBName(141, 182, 205, "Light Sky Blue 3"),
            new DRGBName(141, 238, 238, "Dark Slate Gray 2"),
            new DRGBName(142, 229, 238, "Cadet Blue 2"),
            new DRGBName(143, 143, 143, "gray 56"),
            new DRGBName(143, 143, 143, "grey 56"),
            new DRGBName(143, 188, 143, "dark sea green"),
            new DRGBName(144, 238, 144, "light green"),
            new DRGBName(144, 238, 144, "Pale Green 2"),
            new DRGBName(145, 145, 145, "gray 57"),
            new DRGBName(145, 145, 145, "grey 57"),
            new DRGBName(145, 44, 238, "purple 2"),
            new DRGBName(147, 112, 219, "medium purple"),
            new DRGBName(148, 0, 211, "dark violet"),
            new DRGBName(148, 148, 148, "gray 58"),
            new DRGBName(148, 148, 148, "grey 58"),
            new DRGBName(150, 150, 150, "gray 59"),
            new DRGBName(150, 150, 150, "grey 59"),
            new DRGBName(150, 205, 205, "Pale Turquoise 3"),
            new DRGBName(151, 255, 255, "Dark Slate Gray 1"),
            new DRGBName(152, 245, 255, "Cadet Blue 1"),
            new DRGBName(152, 251, 152, "pale green"),
            new DRGBName(153, 153, 153, "gray 60"),
            new DRGBName(153, 153, 153, "grey 60"),
            new DRGBName(153, 50, 204, "dark orchid"),
            new DRGBName(154, 192, 205, "Light Blue 3"),
            new DRGBName(154, 205, 50, "Olive Drab 3"),
            new DRGBName(154, 205, 50, "yellow green"),
            new DRGBName(154, 255, 154, "Pale Green 1"),
            new DRGBName(154, 50, 205, "Dark Orchid 3"),
            new DRGBName(155, 205, 155, "Dark Sea Green 3"),
            new DRGBName(155, 48, 255, "purple 1"),
            new DRGBName(156, 156, 156, "gray 61"),
            new DRGBName(156, 156, 156, "grey 61"),
            new DRGBName(158, 158, 158, "gray 62"),
            new DRGBName(158, 158, 158, "grey 62"),
            new DRGBName(159, 121, 238, "Medium Purple 2"),
            new DRGBName(159, 182, 205, "Slate Gray 3"),
            new DRGBName(160, 32, 240, "purple"),
            new DRGBName(160, 82, 45, "sienna"),
            new DRGBName(161, 161, 161, "gray 63"),
            new DRGBName(161, 161, 161, "grey 63"),
            new DRGBName(162, 181, 205, "Light Steel Blue 3"),
            new DRGBName(162, 205, 90, "Dark Olive Green 3"),
            new DRGBName(163, 163, 163, "gray 64"),
            new DRGBName(163, 163, 163, "grey 64"),
            new DRGBName(164, 211, 238, "Light Sky Blue 2"),
            new DRGBName(165, 42, 42, "brown"),
            new DRGBName(166, 166, 166, "gray 65"),
            new DRGBName(166, 166, 166, "grey 65"),
            new DRGBName(168, 168, 168, "gray 66"),
            new DRGBName(168, 168, 168, "grey 66"),
            new DRGBName(169, 169, 169, "dark gray"),
            new DRGBName(171, 130, 255, "Medium Purple 1"),
            new DRGBName(171, 171, 171, "gray 67"),
            new DRGBName(171, 171, 171, "grey 67"),
            new DRGBName(173, 173, 173, "gray 68"),
            new DRGBName(173, 173, 173, "grey 68"),
            new DRGBName(173, 216, 230, "light blue"),
            new DRGBName(173, 255, 47, "green yellow"),
            new DRGBName(175, 238, 238, "pale turquoise"),
            new DRGBName(176, 176, 176, "gray 69"),
            new DRGBName(176, 176, 176, "grey 69"),
            new DRGBName(176, 196, 222, "light steel blue"),
            new DRGBName(176, 224, 230, "powder blue"),
            new DRGBName(176, 226, 255, "Light Sky Blue 1"),
            new DRGBName(176, 48, 96, "maroon"),
            new DRGBName(178, 223, 238, "Light Blue 2"),
            new DRGBName(178, 34, 34, "firebrick"),
            new DRGBName(178, 58, 238, "Dark Orchid 2"),
            new DRGBName(179, 179, 179, "gray 70"),
            new DRGBName(179, 179, 179, "grey 70"),
            new DRGBName(179, 238, 58, "Olive Drab 2"),
            new DRGBName(180, 205, 205, "Light Cyan 3"),
            new DRGBName(180, 238, 180, "Dark Sea Green 2"),
            new DRGBName(180, 82, 205, "Medium Orchid 3"),
            new DRGBName(181, 181, 181, "gray 71"),
            new DRGBName(181, 181, 181, "grey 71"),
            new DRGBName(184, 134, 11, "dark goldenrod"),
            new DRGBName(184, 184, 184, "gray 72"),
            new DRGBName(184, 184, 184, "grey 72"),
            new DRGBName(185, 211, 238, "Slate Gray 2"),
            new DRGBName(186, 186, 186, "gray 73"),
            new DRGBName(186, 186, 186, "grey 73"),
            new DRGBName(186, 85, 211, "medium orchid"),
            new DRGBName(187, 255, 255, "Pale Turquoise 1"),
            new DRGBName(188, 143, 143, "rosy brown"),
            new DRGBName(188, 210, 238, "Light Steel Blue 2"),
            new DRGBName(188, 238, 104, "Dark Olive Green 2"),
            new DRGBName(189, 183, 107, "dark khaki"),
            new DRGBName(189, 189, 189, "gray 74"),
            new DRGBName(189, 189, 189, "grey 74"),
            new DRGBName(190, 190, 190, "gray"),
            new DRGBName(190, 190, 190, "grey"),
            new DRGBName(191, 191, 191, "gray 75"),
            new DRGBName(191, 191, 191, "grey 75"),
            new DRGBName(191, 239, 255, "Light Blue 1"),
            new DRGBName(191, 62, 255, "Dark Orchid 1"),
            new DRGBName(192, 255, 62, "Olive Drab 1"),
            new DRGBName(193, 205, 193, "honeydew 3"),
            new DRGBName(193, 205, 205, "azure 3"),
            new DRGBName(193, 255, 193, "Dark Sea Green 1"),
            new DRGBName(194, 194, 194, "gray 76"),
            new DRGBName(194, 194, 194, "grey 76"),
            new DRGBName(196, 196, 196, "gray 77"),
            new DRGBName(196, 196, 196, "grey 77"),
            new DRGBName(198, 226, 255, "Slate Gray 1"),
            new DRGBName(199, 199, 199, "gray 78"),
            new DRGBName(199, 199, 199, "grey 78"),
            new DRGBName(199, 21, 133, "medium violet red"),
            new DRGBName(201, 201, 201, "gray 79"),
            new DRGBName(201, 201, 201, "grey 79"),
            new DRGBName(202, 225, 255, "Light Steel Blue 1"),
            new DRGBName(202, 255, 112, "Dark Olive Green 1"),
            new DRGBName(204, 204, 204, "gray 80"),
            new DRGBName(204, 204, 204, "grey 80"),
            new DRGBName(205, 0, 0, "red 3"),
            new DRGBName(205, 0, 205, "magenta 3"),
            new DRGBName(205, 102, 0, "Dark Orange 3"),
            new DRGBName(205, 102, 29, "chocolate 3"),
            new DRGBName(205, 104, 137, "Pale Violet Red 3"),
            new DRGBName(205, 104, 57, "sienna 3"),
            new DRGBName(205, 105, 201, "orchid 3"),
            new DRGBName(205, 112, 84, "salmon 3"),
            new DRGBName(205, 129, 98, "Light Salmon 3"),
            new DRGBName(205, 133, 0, "orange 3"),
            new DRGBName(205, 133, 63, "peru"),
            new DRGBName(205, 140, 149, "Light Pink 3"),
            new DRGBName(205, 145, 158, "pink 3"),
            new DRGBName(205, 149, 12, "Dark Goldenrod 3"),
            new DRGBName(205, 150, 205, "plum 3"),
            new DRGBName(205, 155, 155, "Rosy Brown 3"),
            new DRGBName(205, 155, 29, "goldenrod 3"),
            new DRGBName(205, 16, 118, "Deep Pink 3"),
            new DRGBName(205, 170, 125, "burlywood 3"),
            new DRGBName(205, 173, 0, "gold 3"),
            new DRGBName(205, 175, 149, "Peach Puff 3"),
            new DRGBName(205, 179, 139, "Navajo White 3"),
            new DRGBName(205, 181, 205, "thistle 3"),
            new DRGBName(205, 183, 158, "bisque 3"),
            new DRGBName(205, 183, 181, "Misty Rose 3"),
            new DRGBName(205, 186, 150, "wheat 3"),
            new DRGBName(205, 190, 112, "Light Goldenrod 3"),
            new DRGBName(205, 192, 176, "Antique White 3"),
            new DRGBName(205, 193, 197, "Lavender Blush 3"),
            new DRGBName(205, 197, 191, "seashell 3"),
            new DRGBName(205, 198, 115, "khaki 3"),
            new DRGBName(205, 200, 177, "cornsilk 3"),
            new DRGBName(205, 201, 165, "Lemon Chiffon 3"),
            new DRGBName(205, 201, 201, "snow 3"),
            new DRGBName(205, 205, 0, "yellow 3"),
            new DRGBName(205, 205, 180, "Light Yellow 3"),
            new DRGBName(205, 205, 193, "ivory 3"),
            new DRGBName(205, 38, 38, "firebrick 3"),
            new DRGBName(205, 41, 144, "maroon 3"),
            new DRGBName(205, 50, 120, "Violet Red 3"),
            new DRGBName(205, 51, 51, "brown 3"),
            new DRGBName(205, 55, 0, "Orange Red 3"),
            new DRGBName(205, 79, 57, "tomato 3"),
            new DRGBName(205, 85, 85, "Indian Red 3"),
            new DRGBName(205, 91, 69, "coral 3"),
            new DRGBName(205, 92, 92, "indian red"),
            new DRGBName(205, 96, 144, "Hot Pink 3"),
            new DRGBName(207, 207, 207, "gray 81"),
            new DRGBName(207, 207, 207, "grey 81"),
            new DRGBName(208, 32, 144, "violet red"),
            new DRGBName(209, 209, 209, "gray 82"),
            new DRGBName(209, 209, 209, "grey 82"),
            new DRGBName(209, 238, 238, "Light Cyan 2"),
            new DRGBName(209, 95, 238, "Medium Orchid 2"),
            new DRGBName(210, 105, 30, "chocolate"),
            new DRGBName(210, 180, 140, "tan"),
            new DRGBName(211, 211, 211, "light grey"),
            new DRGBName(212, 212, 212, "gray 83"),
            new DRGBName(212, 212, 212, "grey 83"),
            new DRGBName(214, 214, 214, "gray 84"),
            new DRGBName(214, 214, 214, "grey 84"),
            new DRGBName(216, 191, 216, "thistle"),
            new DRGBName(217, 217, 217, "gray 85"),
            new DRGBName(217, 217, 217, "grey 85"),
            new DRGBName(218, 112, 214, "orchid"),
            new DRGBName(218, 165, 32, "goldenrod"),
            new DRGBName(219, 112, 147, "pale violet red"),
            new DRGBName(219, 219, 219, "gray 86"),
            new DRGBName(219, 219, 219, "grey 86"),
            new DRGBName(220, 220, 220, "gainsboro"),
            new DRGBName(221, 160, 221, "plum"),
            new DRGBName(222, 184, 135, "burlywood"),
            new DRGBName(222, 222, 222, "gray 87"),
            new DRGBName(222, 222, 222, "grey 87"),
            new DRGBName(224, 102, 255, "Medium Orchid 1"),
            new DRGBName(224, 224, 224, "gray 88"),
            new DRGBName(224, 224, 224, "grey 88"),
            new DRGBName(224, 238, 224, "honeydew 2"),
            new DRGBName(224, 238, 238, "azure 2"),
            new DRGBName(224, 255, 255, "light cyan"),
            new DRGBName(227, 227, 227, "gray 89"),
            new DRGBName(227, 227, 227, "grey 89"),
            new DRGBName(229, 229, 229, "gray 90"),
            new DRGBName(229, 229, 229, "grey 90"),
            new DRGBName(230, 230, 250, "lavender"),
            new DRGBName(232, 232, 232, "gray 91"),
            new DRGBName(232, 232, 232, "grey 91"),
            new DRGBName(233, 150, 122, "dark salmon"),
            new DRGBName(235, 235, 235, "gray 92"),
            new DRGBName(235, 235, 235, "grey 92"),
            new DRGBName(237, 237, 237, "gray 93"),
            new DRGBName(237, 237, 237, "grey 93"),
            new DRGBName(238, 0, 0, "red 2"),
            new DRGBName(238, 0, 238, "magenta 2"),
            new DRGBName(238, 106, 167, "Hot Pink 2"),
            new DRGBName(238, 106, 80, "coral 2"),
            new DRGBName(238, 118, 0, "Dark Orange 2"),
            new DRGBName(238, 118, 33, "chocolate 2"),
            new DRGBName(238, 121, 159, "Pale Violet Red 2"),
            new DRGBName(238, 121, 66, "sienna 2"),
            new DRGBName(238, 122, 233, "orchid 2"),
            new DRGBName(238, 130, 238, "violet"),
            new DRGBName(238, 130, 98, "salmon 2"),
            new DRGBName(238, 149, 114, "Light Salmon 2"),
            new DRGBName(238, 154, 0, "orange 2"),
            new DRGBName(238, 154, 73, "tan 2"),
            new DRGBName(238, 162, 173, "Light Pink 2"),
            new DRGBName(238, 169, 184, "pink 2"),
            new DRGBName(238, 173, 14, "Dark Goldenrod 2"),
            new DRGBName(238, 174, 238, "plum 2"),
            new DRGBName(238, 180, 180, "Rosy Brown 2"),
            new DRGBName(238, 180, 34, "goldenrod 2"),
            new DRGBName(238, 18, 137, "Deep Pink 2"),
            new DRGBName(238, 197, 145, "burlywood 2"),
            new DRGBName(238, 201, 0, "gold 2"),
            new DRGBName(238, 203, 173, "Peach Puff 2"),
            new DRGBName(238, 207, 161, "Navajo White 2"),
            new DRGBName(238, 210, 238, "thistle 2"),
            new DRGBName(238, 213, 183, "bisque 2"),
            new DRGBName(238, 213, 210, "Misty Rose 2"),
            new DRGBName(238, 216, 174, "wheat 2"),
            new DRGBName(238, 221, 130, "light goldenrod"),
            new DRGBName(238, 223, 204, "Antique White 2"),
            new DRGBName(238, 224, 229, "Lavender Blush 2"),
            new DRGBName(238, 229, 222, "seashell 2"),
            new DRGBName(238, 230, 133, "khaki 2"),
            new DRGBName(238, 232, 170, "pale goldenrod"),
            new DRGBName(238, 232, 205, "cornsilk 2"),
            new DRGBName(238, 233, 191, "Lemon Chiffon 2"),
            new DRGBName(238, 233, 233, "snow 2"),
            new DRGBName(238, 238, 0, "yellow 2"),
            new DRGBName(238, 238, 209, "Light Yellow 2"),
            new DRGBName(238, 238, 224, "ivory 2"),
            new DRGBName(238, 44, 44, "firebrick 2"),
            new DRGBName(238, 48, 167, "maroon 2"),
            new DRGBName(238, 58, 140, "Violet Red 2"),
            new DRGBName(238, 59, 59, "brown 2"),
            new DRGBName(238, 64, 0, "Orange Red 2"),
            new DRGBName(238, 92, 66, "tomato 2"),
            new DRGBName(238, 99, 99, "Indian Red 2"),
            new DRGBName(240, 128, 128, "light coral"),
            new DRGBName(240, 230, 140, "khaki"),
            new DRGBName(240, 240, 240, "gray 94"),
            new DRGBName(240, 240, 240, "grey 94"),
            new DRGBName(240, 248, 255, "alice blue"),
            new DRGBName(240, 255, 240, "honeydew"),
            new DRGBName(240, 255, 255, "azure"),
            new DRGBName(242, 242, 242, "gray 95"),
            new DRGBName(242, 242, 242, "grey 95"),
            new DRGBName(244, 164, 96, "sandy brown"),
            new DRGBName(245, 222, 179, "wheat"),
            new DRGBName(245, 245, 220, "beige"),
            new DRGBName(245, 245, 245, "gray 96"),
            new DRGBName(245, 245, 245, "grey 96"),
            new DRGBName(245, 245, 245, "white smoke"),
            new DRGBName(245, 255, 250, "mint cream"),
            new DRGBName(247, 247, 247, "gray 97"),
            new DRGBName(247, 247, 247, "grey 97"),
            new DRGBName(248, 248, 255, "ghost white"),
            new DRGBName(250, 128, 114, "salmon"),
            new DRGBName(250, 235, 215, "antique white"),
            new DRGBName(250, 240, 230, "linen"),
            new DRGBName(250, 250, 210, "light goldenrod yellow"),
            new DRGBName(250, 250, 250, "gray 98"),
            new DRGBName(250, 250, 250, "grey 98"),
            new DRGBName(252, 252, 252, "gray 99"),
            new DRGBName(252, 252, 252, "grey 99"),
            new DRGBName(253, 245, 230, "old lace"),
            new DRGBName(255, 0, 0, "red"),
            new DRGBName(255, 0, 255, "magenta"),
            new DRGBName(255, 105, 180, "hot pink"),
            new DRGBName(255, 106, 106, "Indian Red 1"),
            new DRGBName(255, 110, 180, "Hot Pink 1"),
            new DRGBName(255, 114, 86, "coral1"),
            new DRGBName(255, 127, 0, "Dark Orange 1"),
            new DRGBName(255, 127, 36, "chocolate 1"),
            new DRGBName(255, 127, 80, "coral"),
            new DRGBName(255, 130, 171, "Pale Violet Red 1"),
            new DRGBName(255, 130, 71, "sienna 1"),
            new DRGBName(255, 131, 250, "orchid 1"),
            new DRGBName(255, 140, 0, "dark orange"),
            new DRGBName(255, 140, 105, "salmon 1"),
            new DRGBName(255, 160, 122, "light salmon"),
            new DRGBName(255, 165, 0, "orange"),
            new DRGBName(255, 165, 79, "tan 1"),
            new DRGBName(255, 174, 185, "Light Pink 1"),
            new DRGBName(255, 181, 197, "pink 1"),
            new DRGBName(255, 182, 193, "light pink"),
            new DRGBName(255, 185, 15, "Dark Goldenrod 1"),
            new DRGBName(255, 187, 255, "plum 1"),
            new DRGBName(255, 192, 203, "pink"),
            new DRGBName(255, 193, 193, "Rosy Brown 1"),
            new DRGBName(255, 193, 37, "goldenrod 1"),
            new DRGBName(255, 20, 147, "deep pink"),
            new DRGBName(255, 211, 155, "burlywood 1"),
            new DRGBName(255, 215, 0, "gold"),
            new DRGBName(255, 218, 185, "peach puff"),
            new DRGBName(255, 222, 173, "navajo white"),
            new DRGBName(255, 225, 255, "thistle 1"),
            new DRGBName(255, 228, 181, "moccasin"),
            new DRGBName(255, 228, 196, "bisque"),
            new DRGBName(255, 228, 225, "misty rose"),
            new DRGBName(255, 231, 186, "wheat 1"),
            new DRGBName(255, 235, 205, "blanched almond"),
            new DRGBName(255, 236, 139, "Light Goldenrod 1"),
            new DRGBName(255, 239, 213, "papaya whip"),
            new DRGBName(255, 239, 219, "Antique White 1"),
            new DRGBName(255, 240, 245, "lavender blush"),
            new DRGBName(255, 245, 238, "seashell"),
            new DRGBName(255, 246, 143, "khaki1"),
            new DRGBName(255, 248, 220, "cornsilk"),
            new DRGBName(255, 250, 205, "lemon chiffon"),
            new DRGBName(255, 250, 240, "floral white"),
            new DRGBName(255, 250, 250, "snow"),
            new DRGBName(255, 255, 0, "yellow"),
            new DRGBName(255, 255, 224, "light yellow"),
            new DRGBName(255, 255, 240, "ivory"),
            new DRGBName(255, 255, 255, "white"),
            new DRGBName(255, 48, 48, "firebrick 1"),
            new DRGBName(255, 52, 179, "maroon 1"),
            new DRGBName(255, 62, 150, "Violet Red 1"),
            new DRGBName(255, 64, 64, "brown 1"),
            new DRGBName(255, 69, 0, "orange red"),
            new DRGBName(255, 99, 71, "tomato")
        };

        public void findColor(int R, int G, int B, int formX, int formY)
        {
            string region;
            string colorName;

            // Determine the color region among ROYGBIV + White and Black
            // Evenly divided into 8 smaller cubes.
            if (R <= 128)
            {   // Lower half of the color cube.
                if (G <= 128)
                {
                    if (B <= 128)
                    {
                        region = "Black region";
                    }
                    else
                    {
                        region = "Blue region";
                    }
                }
                else
                {
                    if (B <= 128)
                    {
                        region = "Green region";
                    }
                    else
                    {
                        region = "Cyan region";
                    }
                }
            }
            else
            {   // Higher half of the color cube.
                if (G <= 128)
                {
                    if (B <= 128)
                    {
                        region = "Red region";
                    }
                    else
                    {
                        region = "Magenta region";
                    }
                }
                else
                {
                    if (B <= 128)
                    {
                        region = "Yellow region";
                    }
                    else
                    {
                        region = "White region";
                    }
                }
            }

            Color original = Color.FromArgb(R, G, B);

            // Calculate the distance from the given color to every other color in the table. 
            double minDistance = 1;
            double cDistance;
            int index = 0;

            for (int i = 0; i < colorTable.Length; i++)
            {
                cDistance = Math.Sqrt(Math.Pow((R - colorTable[i].red), 2) + Math.Pow((G - colorTable[i].green), 2)
                    + Math.Pow((B - colorTable[i].blue), 2));

                if (0.0 == cDistance)
                {   // Color found! The two points match!
                    colorName = colorTable[i].colorName;
                    Form colorFormExact = new color(true, original, original, region, colorName);
                    colorFormExact.Load += delegate
                    {
                        colorFormExact.Location = new Point(formX, formY);
                    };
                    colorFormExact.Show();
                    return;
                }

                if (0 == i)
                { // Initialize minDistance
                    minDistance = cDistance;
                }

                if (cDistance < minDistance)
                {   // New minimum.
                    minDistance = cDistance;
                    index = i;
                }
            }

            // Found closest, most similar color.
            Color similar = Color.FromArgb(colorTable[index].red, colorTable[index].green, colorTable[index].blue);
            colorName = colorTable[index].colorName;

            Form colorFormSimilar = new color(false, original, similar, region, colorName);
            colorFormSimilar.Load += delegate
            {
                colorFormSimilar.Location = new Point(formX, formY);
            };
            colorFormSimilar.Show();
        }
    }
}
