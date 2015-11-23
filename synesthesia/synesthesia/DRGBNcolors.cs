﻿/*
Author: Elliott Ploutz
Email: ploutze@unlv.nevada.edu

This class statically creates a table of colors with limited query functionality. For each color,
a 3D distance is computed. The red, green, and blue values can be mapped to a three dimensional 
space. By comparing the distance of two points, or two colors, we can say that the two colors
are in a similar region, thus a similar color.

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

        // Sorted by distance from the origin.
        public static DRGBName[] colorTable = new DRGBName[608]
        {
            new DRGBName(0, 0, 0, "black"),
            new DRGBName(0, 0, 128, "Navy Blue"),
            new DRGBName(0, 0, 139, "Dark Blue"),
            new DRGBName(0, 0, 205, "Medium Blue"),
            new DRGBName(0, 0, 238, "blue 2"),
            new DRGBName(0, 0, 255, "blue"),
            new DRGBName(0, 100, 0, "Dark Green"),
            new DRGBName(0, 104, 139, "DeepSkyBlue 4"),
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
            new DRGBName(0, 229, 238, "turquoise2"),
            new DRGBName(0, 238, 0, "green2"),
            new DRGBName(0, 238, 118, "SpringGreen2"),
            new DRGBName(0, 238, 238, "cyan2"),
            new DRGBName(0, 245, 255, "turquoise1"),
            new DRGBName(0, 250, 154, "medium spring green"),
            new DRGBName(0, 255, 0, "green"),
            new DRGBName(0, 255, 127, "spring green"),
            new DRGBName(0, 255, 255, "cyan"),
            new DRGBName(3, 3, 3, "gray1"),
            new DRGBName(3, 3, 3, "grey1"),
            new DRGBName(5, 5, 5, "gray2"),
            new DRGBName(5, 5, 5, "grey2"),
            new DRGBName(8, 8, 8, "gray3"),
            new DRGBName(8, 8, 8, "grey3"),
            new DRGBName(10, 10, 10, "gray4"),
            new DRGBName(10, 10, 10, "grey4"),
            new DRGBName(13, 13, 13, "gray5"),
            new DRGBName(13, 13, 13, "grey5"),
            new DRGBName(15, 15, 15, "gray6"),
            new DRGBName(15, 15, 15, "grey6"),
            new DRGBName(16, 78, 139, "DodgerBlue4"),
            new DRGBName(18, 18, 18, "gray7"),
            new DRGBName(18, 18, 18, "grey7"),
            new DRGBName(20, 20, 20, "gray8"),
            new DRGBName(20, 20, 20, "grey8"),
            new DRGBName(23, 23, 23, "gray9"),
            new DRGBName(23, 23, 23, "grey9"),
            new DRGBName(24, 116, 205, "DodgerBlue3"),
            new DRGBName(25, 25, 112, "midnight blue"),
            new DRGBName(26, 26, 26, "gray10"),
            new DRGBName(26, 26, 26, "grey10"),
            new DRGBName(28, 134, 238, "DodgerBlue2"),
            new DRGBName(28, 28, 28, "gray11"),
            new DRGBName(28, 28, 28, "grey11"),
            new DRGBName(30, 144, 255, "DodgerBlue"),
            new DRGBName(31, 31, 31, "gray12"),
            new DRGBName(31, 31, 31, "grey12"),
            new DRGBName(32, 178, 170, "light sea green"),
            new DRGBName(33, 33, 33, "gray13"),
            new DRGBName(33, 33, 33, "grey13"),
            new DRGBName(34, 139, 34, "forest green"),
            new DRGBName(36, 36, 36, "gray14"),
            new DRGBName(36, 36, 36, "grey14"),
            new DRGBName(38, 38, 38, "gray15"),
            new DRGBName(38, 38, 38, "grey15"),
            new DRGBName(39, 64, 139, "RoyalBlue4"),
            new DRGBName(41, 41, 41, "gray16"),
            new DRGBName(41, 41, 41, "grey16"),
            new DRGBName(43, 43, 43, "gray17"),
            new DRGBName(43, 43, 43, "grey17"),
            new DRGBName(46, 139, 87, "sea green"),
            new DRGBName(46, 46, 46, "gray18"),
            new DRGBName(46, 46, 46, "grey18"),
            new DRGBName(47, 79, 79, "dark slate gray"),
            new DRGBName(48, 48, 48, "gray19"),
            new DRGBName(48, 48, 48, "grey19"),
            new DRGBName(50, 205, 50, "lime green"),
            new DRGBName(51, 51, 51, "gray20"),
            new DRGBName(51, 51, 51, "grey20"),
            new DRGBName(54, 100, 139, "SteelBlue4"),
            new DRGBName(54, 54, 54, "gray21"),
            new DRGBName(54, 54, 54, "grey21"),
            new DRGBName(56, 56, 56, "gray22"),
            new DRGBName(56, 56, 56, "grey22"),
            new DRGBName(58, 95, 205, "RoyalBlue3"),
            new DRGBName(59, 59, 59, "gray23"),
            new DRGBName(59, 59, 59, "grey23"),
            new DRGBName(60, 179, 113, "medium sea green"),
            new DRGBName(61, 61, 61, "gray24"),
            new DRGBName(61, 61, 61, "grey24"),
            new DRGBName(64, 224, 208, "turquoise"),
            new DRGBName(64, 64, 64, "gray25"),
            new DRGBName(64, 64, 64, "grey25"),
            new DRGBName(65, 105, 225, "royal blue"),
            new DRGBName(66, 66, 66, "gray26"),
            new DRGBName(66, 66, 66, "grey26"),
            new DRGBName(67, 110, 238, "RoyalBlue2"),
            new DRGBName(67, 205, 128, "SeaGreen3"),
            new DRGBName(69, 139, 0, "chartreuse4"),
            new DRGBName(69, 139, 116, "aquamarine4"),
            new DRGBName(69, 69, 69, "gray27"),
            new DRGBName(69, 69, 69, "grey27"),
            new DRGBName(70, 130, 180, "steel blue"),
            new DRGBName(70, 130, 180, "SteelBlue"),
            new DRGBName(71, 71, 71, "gray28"),
            new DRGBName(71, 71, 71, "grey28"),
            new DRGBName(72, 118, 255, "RoyalBlue1"),
            new DRGBName(72, 209, 204, "medium turquoise"),
            new DRGBName(72, 61, 139, "dark slate blue"),
            new DRGBName(74, 112, 139, "SkyBlue4"),
            new DRGBName(74, 74, 74, "gray29"),
            new DRGBName(74, 74, 74, "grey29"),
            new DRGBName(77, 77, 77, "gray30"),
            new DRGBName(77, 77, 77, "grey30"),
            new DRGBName(78, 238, 148, "SeaGreen2"),
            new DRGBName(79, 148, 205, "SteelBlue3"),
            new DRGBName(79, 79, 79, "gray31"),
            new DRGBName(79, 79, 79, "grey31"),
            new DRGBName(82, 139, 139, "DarkSlateGray4"),
            new DRGBName(82, 82, 82, "gray32"),
            new DRGBName(82, 82, 82, "grey32"),
            new DRGBName(83, 134, 139, "CadetBlue4"),
            new DRGBName(84, 139, 84, "PaleGreen4"),
            new DRGBName(84, 255, 159, "SeaGreen1"),
            new DRGBName(84, 84, 84, "gray33"),
            new DRGBName(84, 84, 84, "grey33"),
            new DRGBName(85, 107, 47, "dark olive green"),
            new DRGBName(85, 26, 139, "purple4"),
            new DRGBName(87, 87, 87, "gray34"),
            new DRGBName(87, 87, 87, "grey34"),
            new DRGBName(89, 89, 89, "gray35"),
            new DRGBName(89, 89, 89, "grey35"),
            new DRGBName(92, 172, 238, "SteelBlue2"),
            new DRGBName(92, 92, 92, "gray36"),
            new DRGBName(92, 92, 92, "grey36"),
            new DRGBName(93, 71, 139, "MediumPurple4"),
            new DRGBName(94, 94, 94, "gray37"),
            new DRGBName(94, 94, 94, "grey37"),
            new DRGBName(95, 158, 160, "cadet blue"),
            new DRGBName(96, 123, 139, "LightSkyBlue4"),
            new DRGBName(97, 97, 97, "gray38"),
            new DRGBName(97, 97, 97, "grey38"),
            new DRGBName(99, 184, 255, "SteelBlue1"),
            new DRGBName(99, 99, 99, "gray39"),
            new DRGBName(99, 99, 99, "grey39"),
            new DRGBName(100, 149, 237, "cornflower blue"),
            new DRGBName(102, 102, 102, "gray40"),
            new DRGBName(102, 102, 102, "grey40"),
            new DRGBName(102, 139, 139, "PaleTurquoise4"),
            new DRGBName(102, 205, 0, "chartreuse3"),
            new DRGBName(102, 205, 170, "medium aquamarine"),
            new DRGBName(104, 131, 139, "LightBlue4"),
            new DRGBName(104, 34, 139, "DarkOrchid4"),
            new DRGBName(105, 105, 105, "dim gray"),
            new DRGBName(105, 105, 105, "dim grey"),
            new DRGBName(105, 139, 105, "DarkSeaGreen4"),
            new DRGBName(105, 139, 34, "OliveDrab4"),
            new DRGBName(105, 89, 205, "slate blue 3"),
            new DRGBName(106, 90, 205, "slate blue"),
            new DRGBName(106, 90, 205, "slate blue"),
            new DRGBName(107, 107, 107, "gray42"),
            new DRGBName(107, 107, 107, "grey42"),
            new DRGBName(107, 142, 35, "olive drab"),
            new DRGBName(108, 123, 139, "SlateGray4"),
            new DRGBName(108, 166, 205, "SkyBlue3"),
            new DRGBName(110, 110, 110, "gray43"),
            new DRGBName(110, 110, 110, "grey43"),
            new DRGBName(110, 123, 139, "LightSteelBlue4"),
            new DRGBName(110, 139, 61, "DarkOliveGreen4"),
            new DRGBName(112, 112, 112, "gray44"),
            new DRGBName(112, 112, 112, "grey44"),
            new DRGBName(112, 128, 144, "slate gray"),
            new DRGBName(115, 115, 115, "gray45"),
            new DRGBName(115, 115, 115, "grey45"),
            new DRGBName(117, 117, 117, "gray46"),
            new DRGBName(117, 117, 117, "grey46"),
            new DRGBName(118, 238, 0, "chartreuse2"),
            new DRGBName(118, 238, 198, "aquamarine2"),
            new DRGBName(119, 136, 153, "light slate gray"),
            new DRGBName(120, 120, 120, "gray47"),
            new DRGBName(120, 120, 120, "grey47"),
            new DRGBName(121, 205, 205, "DarkSlateGray3"),
            new DRGBName(122, 103, 238, "SlateBlue2"),
            new DRGBName(122, 122, 122, "gray48"),
            new DRGBName(122, 122, 122, "grey48"),
            new DRGBName(122, 139, 139, "LightCyan4"),
            new DRGBName(122, 197, 205, "CadetBlue3"),
            new DRGBName(122, 55, 139, "MediumOrchid4"),
            new DRGBName(123, 104, 238, "medium slate blue"),
            new DRGBName(123, 104, 238, "MediumSlateBlue"),
            new DRGBName(124, 205, 124, "PaleGreen3"),
            new DRGBName(124, 252, 0, "lawn green"),
            new DRGBName(125, 125, 125, "gray49"),
            new DRGBName(125, 125, 125, "grey49"),
            new DRGBName(125, 38, 205, "purple3"),
            new DRGBName(126, 192, 238, "SkyBlue2"),
            new DRGBName(127, 127, 127, "gray50"),
            new DRGBName(127, 127, 127, "grey50"),
            new DRGBName(127, 255, 0, "chartreuse"),
            new DRGBName(127, 255, 212, "aquamarine"),
            new DRGBName(130, 130, 130, "gray51"),
            new DRGBName(130, 130, 130, "grey51"),
            new DRGBName(131, 111, 255, "SlateBlue1"),
            new DRGBName(131, 139, 131, "honeydew4"),
            new DRGBName(131, 139, 139, "azure4"),
            new DRGBName(132, 112, 255, "light slate blue"),
            new DRGBName(133, 133, 133, "gray52"),
            new DRGBName(133, 133, 133, "grey52"),
            new DRGBName(135, 135, 135, "gray53"),
            new DRGBName(135, 135, 135, "grey53"),
            new DRGBName(135, 206, 235, "sky blue"),
            new DRGBName(135, 206, 250, "light sky blue"),
            new DRGBName(135, 206, 255, "SkyBlue1"),
            new DRGBName(137, 104, 205, "MediumPurple3"),
            new DRGBName(138, 138, 138, "gray54"),
            new DRGBName(138, 138, 138, "grey54"),
            new DRGBName(138, 43, 226, "blue violet"),
            new DRGBName(139, 0, 0, "dark red"),
            new DRGBName(139, 0, 139, "dark magenta"),
            new DRGBName(139, 101, 8, "DarkGoldenrod4"),
            new DRGBName(139, 102, 139, "plum4"),
            new DRGBName(139, 105, 105, "RosyBrown4"),
            new DRGBName(139, 105, 20, "goldenrod4"),
            new DRGBName(139, 10, 80, "DeepPink4"),
            new DRGBName(139, 115, 85, "burlywood4"),
            new DRGBName(139, 117, 0, "gold4"),
            new DRGBName(139, 119, 101, "PeachPuff4"),
            new DRGBName(139, 121, 94, "NavajoWhite4"),
            new DRGBName(139, 123, 139, "thistle4"),
            new DRGBName(139, 125, 107, "bisque4"),
            new DRGBName(139, 125, 123, "MistyRose4"),
            new DRGBName(139, 126, 102, "wheat4"),
            new DRGBName(139, 129, 76, "LightGoldenrod4"),
            new DRGBName(139, 131, 120, "AntiqueWhite4"),
            new DRGBName(139, 131, 134, "LavenderBlush4"),
            new DRGBName(139, 134, 130, "seashell4"),
            new DRGBName(139, 134, 78, "khaki4"),
            new DRGBName(139, 136, 120, "cornsilk4"),
            new DRGBName(139, 137, 112, "LemonChiffon4"),
            new DRGBName(139, 137, 137, "snow4"),
            new DRGBName(139, 139, 0, "yellow4"),
            new DRGBName(139, 139, 122, "LightYellow4"),
            new DRGBName(139, 139, 131, "ivory4"),
            new DRGBName(139, 26, 26, "firebrick4"),
            new DRGBName(139, 28, 98, "maroon4"),
            new DRGBName(139, 34, 82, "VioletRed4"),
            new DRGBName(139, 35, 35, "brown4"),
            new DRGBName(139, 37, 0, "OrangeRed4"),
            new DRGBName(139, 54, 38, "tomato4"),
            new DRGBName(139, 58, 58, "IndianRed4"),
            new DRGBName(139, 58, 98, "HotPink4"),
            new DRGBName(139, 62, 47, "coral4"),
            new DRGBName(139, 69, 0, "DarkOrange4"),
            new DRGBName(139, 69, 19, "saddle brown"),
            new DRGBName(139, 71, 137, "orchid4"),
            new DRGBName(139, 71, 38, "sienna4"),
            new DRGBName(139, 71, 93, "PaleVioletRed4"),
            new DRGBName(139, 76, 57, "salmon4"),
            new DRGBName(139, 87, 66, "LightSalmon4"),
            new DRGBName(139, 90, 0, "orange4"),
            new DRGBName(139, 90, 43, "tan4"),
            new DRGBName(139, 95, 101, "LightPink4"),
            new DRGBName(139, 99, 108, "pink4"),
            new DRGBName(140, 140, 140, "gray55"),
            new DRGBName(140, 140, 140, "grey55"),
            new DRGBName(141, 182, 205, "LightSkyBlue3"),
            new DRGBName(141, 238, 238, "DarkSlateGray2"),
            new DRGBName(142, 229, 238, "CadetBlue2"),
            new DRGBName(143, 143, 143, "gray56"),
            new DRGBName(143, 143, 143, "grey56"),
            new DRGBName(143, 188, 143, "dark sea green"),
            new DRGBName(144, 238, 144, "light green"),
            new DRGBName(144, 238, 144, "PaleGreen2"),
            new DRGBName(145, 145, 145, "gray57"),
            new DRGBName(145, 145, 145, "grey57"),
            new DRGBName(145, 44, 238, "purple2"),
            new DRGBName(147, 112, 219, "medium purple"),
            new DRGBName(148, 0, 211, "dark violet"),
            new DRGBName(148, 148, 148, "gray58"),
            new DRGBName(148, 148, 148, "grey58"),
            new DRGBName(150, 150, 150, "gray59"),
            new DRGBName(150, 150, 150, "grey59"),
            new DRGBName(150, 205, 205, "PaleTurquoise3"),
            new DRGBName(151, 255, 255, "DarkSlateGray1"),
            new DRGBName(152, 245, 255, "CadetBlue1"),
            new DRGBName(152, 251, 152, "pale green"),
            new DRGBName(153, 153, 153, "gray60"),
            new DRGBName(153, 153, 153, "grey60"),
            new DRGBName(153, 50, 204, "dark orchid"),
            new DRGBName(154, 192, 205, "LightBlue3"),
            new DRGBName(154, 205, 50, "OliveDrab3"),
            new DRGBName(154, 205, 50, "yellow green"),
            new DRGBName(154, 255, 154, "PaleGreen1"),
            new DRGBName(154, 50, 205, "DarkOrchid3"),
            new DRGBName(155, 205, 155, "DarkSeaGreen3"),
            new DRGBName(155, 48, 255, "purple1"),
            new DRGBName(156, 156, 156, "gray61"),
            new DRGBName(156, 156, 156, "grey61"),
            new DRGBName(158, 158, 158, "gray62"),
            new DRGBName(158, 158, 158, "grey62"),
            new DRGBName(159, 121, 238, "MediumPurple2"),
            new DRGBName(159, 182, 205, "SlateGray3"),
            new DRGBName(160, 32, 240, "purple"),
            new DRGBName(160, 82, 45, "sienna"),
            new DRGBName(161, 161, 161, "gray63"),
            new DRGBName(161, 161, 161, "grey63"),
            new DRGBName(162, 181, 205, "LightSteelBlue3"),
            new DRGBName(162, 205, 90, "DarkOliveGreen3"),
            new DRGBName(163, 163, 163, "gray64"),
            new DRGBName(163, 163, 163, "grey64"),
            new DRGBName(164, 211, 238, "LightSkyBlue2"),
            new DRGBName(165, 42, 42, "brown"),
            new DRGBName(166, 166, 166, "gray65"),
            new DRGBName(166, 166, 166, "grey65"),
            new DRGBName(168, 168, 168, "gray66"),
            new DRGBName(168, 168, 168, "grey66"),
            new DRGBName(169, 169, 169, "dark gray"),
            new DRGBName(169, 169, 169, "DarkGray"),
            new DRGBName(169, 169, 169, "dark grey"),
            new DRGBName(169, 169, 169, "DarkGrey"),
            new DRGBName(171, 130, 255, "MediumPurple1"),
            new DRGBName(171, 171, 171, "gray67"),
            new DRGBName(171, 171, 171, "grey67"),
            new DRGBName(173, 173, 173, "gray68"),
            new DRGBName(173, 173, 173, "grey68"),
            new DRGBName(173, 216, 230, "light blue"),
            new DRGBName(173, 255, 47, "green yellow"),
            new DRGBName(175, 238, 238, "pale turquoise"),
            new DRGBName(176, 176, 176, "gray69"),
            new DRGBName(176, 176, 176, "grey69"),
            new DRGBName(176, 196, 222, "light steel blue"),
            new DRGBName(176, 224, 230, "powder blue"),
            new DRGBName(176, 226, 255, "LightSkyBlue1"),
            new DRGBName(176, 48, 96, "maroon"),
            new DRGBName(178, 223, 238, "LightBlue2"),
            new DRGBName(178, 34, 34, "firebrick"),
            new DRGBName(178, 58, 238, "DarkOrchid2"),
            new DRGBName(179, 179, 179, "gray70"),
            new DRGBName(179, 179, 179, "grey70"),
            new DRGBName(179, 238, 58, "OliveDrab2"),
            new DRGBName(180, 205, 205, "LightCyan3"),
            new DRGBName(180, 238, 180, "DarkSeaGreen2"),
            new DRGBName(180, 82, 205, "MediumOrchid3"),
            new DRGBName(181, 181, 181, "gray71"),
            new DRGBName(181, 181, 181, "grey71"),
            new DRGBName(184, 134, 11, "dark goldenrod"),
            new DRGBName(184, 184, 184, "gray72"),
            new DRGBName(184, 184, 184, "grey72"),
            new DRGBName(185, 211, 238, "SlateGray2"),
            new DRGBName(186, 186, 186, "gray73"),
            new DRGBName(186, 186, 186, "grey73"),
            new DRGBName(186, 85, 211, "medium orchid"),
            new DRGBName(187, 255, 255, "PaleTurquoise1"),
            new DRGBName(188, 143, 143, "rosy brown"),
            new DRGBName(188, 210, 238, "LightSteelBlue2"),
            new DRGBName(188, 238, 104, "DarkOliveGreen2"),
            new DRGBName(189, 183, 107, "dark khaki"),
            new DRGBName(189, 189, 189, "gray74"),
            new DRGBName(189, 189, 189, "grey74"),
            new DRGBName(190, 190, 190, "gray"),
            new DRGBName(190, 190, 190, "grey"),
            new DRGBName(191, 191, 191, "gray75"),
            new DRGBName(191, 191, 191, "grey75"),
            new DRGBName(191, 239, 255, "LightBlue1"),
            new DRGBName(191, 62, 255, "DarkOrchid1"),
            new DRGBName(192, 255, 62, "OliveDrab1"),
            new DRGBName(193, 205, 193, "honeydew3"),
            new DRGBName(193, 205, 205, "azure3"),
            new DRGBName(193, 255, 193, "DarkSeaGreen1"),
            new DRGBName(194, 194, 194, "gray76"),
            new DRGBName(194, 194, 194, "grey76"),
            new DRGBName(196, 196, 196, "gray77"),
            new DRGBName(196, 196, 196, "grey77"),
            new DRGBName(198, 226, 255, "SlateGray1"),
            new DRGBName(199, 199, 199, "gray78"),
            new DRGBName(199, 199, 199, "grey78"),
            new DRGBName(199, 21, 133, "medium violet red"),
            new DRGBName(201, 201, 201, "gray79"),
            new DRGBName(201, 201, 201, "grey79"),
            new DRGBName(202, 225, 255, "LightSteelBlue1"),
            new DRGBName(202, 255, 112, "DarkOliveGreen1"),
            new DRGBName(204, 204, 204, "gray80"),
            new DRGBName(204, 204, 204, "grey80"),
            new DRGBName(205, 0, 0, "red3"),
            new DRGBName(205, 0, 205, "magenta3"),
            new DRGBName(205, 102, 0, "DarkOrange3"),
            new DRGBName(205, 102, 29, "chocolate3"),
            new DRGBName(205, 104, 137, "PaleVioletRed3"),
            new DRGBName(205, 104, 57, "sienna3"),
            new DRGBName(205, 105, 201, "orchid3"),
            new DRGBName(205, 112, 84, "salmon3"),
            new DRGBName(205, 129, 98, "LightSalmon3"),
            new DRGBName(205, 133, 0, "orange3"),
            new DRGBName(205, 133, 63, "peru"),
            new DRGBName(205, 140, 149, "LightPink3"),
            new DRGBName(205, 145, 158, "pink3"),
            new DRGBName(205, 149, 12, "DarkGoldenrod3"),
            new DRGBName(205, 150, 205, "plum3"),
            new DRGBName(205, 155, 155, "RosyBrown3"),
            new DRGBName(205, 155, 29, "goldenrod3"),
            new DRGBName(205, 16, 118, "DeepPink3"),
            new DRGBName(205, 170, 125, "burlywood3"),
            new DRGBName(205, 173, 0, "gold3"),
            new DRGBName(205, 175, 149, "PeachPuff3"),
            new DRGBName(205, 179, 139, "NavajoWhite3"),
            new DRGBName(205, 181, 205, "thistle3"),
            new DRGBName(205, 183, 158, "bisque3"),
            new DRGBName(205, 183, 181, "MistyRose3"),
            new DRGBName(205, 186, 150, "wheat3"),
            new DRGBName(205, 190, 112, "LightGoldenrod3"),
            new DRGBName(205, 192, 176, "AntiqueWhite3"),
            new DRGBName(205, 193, 197, "LavenderBlush3"),
            new DRGBName(205, 197, 191, "seashell3"),
            new DRGBName(205, 198, 115, "khaki3"),
            new DRGBName(205, 200, 177, "cornsilk3"),
            new DRGBName(205, 201, 165, "LemonChiffon3"),
            new DRGBName(205, 201, 201, "snow3"),
            new DRGBName(205, 205, 0, "yellow3"),
            new DRGBName(205, 205, 180, "LightYellow3"),
            new DRGBName(205, 205, 193, "ivory3"),
            new DRGBName(205, 38, 38, "firebrick3"),
            new DRGBName(205, 41, 144, "maroon3"),
            new DRGBName(205, 50, 120, "VioletRed3"),
            new DRGBName(205, 51, 51, "brown3"),
            new DRGBName(205, 55, 0, "OrangeRed3"),
            new DRGBName(205, 79, 57, "tomato3"),
            new DRGBName(205, 85, 85, "IndianRed3"),
            new DRGBName(205, 91, 69, "coral3"),
            new DRGBName(205, 92, 92, "indian red"),
            new DRGBName(205, 96, 144, "HotPink3"),
            new DRGBName(207, 207, 207, "gray81"),
            new DRGBName(207, 207, 207, "grey81"),
            new DRGBName(208, 32, 144, "violet red"),
            new DRGBName(209, 209, 209, "gray82"),
            new DRGBName(209, 209, 209, "grey82"),
            new DRGBName(209, 238, 238, "LightCyan2"),
            new DRGBName(209, 95, 238, "MediumOrchid2"),
            new DRGBName(210, 105, 30, "chocolate"),
            new DRGBName(210, 180, 140, "tan"),
            new DRGBName(211, 211, 211, "light grey"),
            new DRGBName(212, 212, 212, "gray83"),
            new DRGBName(212, 212, 212, "grey83"),
            new DRGBName(214, 214, 214, "gray84"),
            new DRGBName(214, 214, 214, "grey84"),
            new DRGBName(216, 191, 216, "thistle"),
            new DRGBName(217, 217, 217, "gray85"),
            new DRGBName(217, 217, 217, "grey85"),
            new DRGBName(218, 112, 214, "orchid"),
            new DRGBName(218, 165, 32, "goldenrod"),
            new DRGBName(219, 112, 147, "pale violet red"),
            new DRGBName(219, 219, 219, "gray86"),
            new DRGBName(219, 219, 219, "grey86"),
            new DRGBName(220, 220, 220, "gainsboro"),
            new DRGBName(221, 160, 221, "plum"),
            new DRGBName(222, 184, 135, "burlywood"),
            new DRGBName(222, 222, 222, "gray87"),
            new DRGBName(222, 222, 222, "grey87"),
            new DRGBName(224, 102, 255, "MediumOrchid1"),
            new DRGBName(224, 224, 224, "gray88"),
            new DRGBName(224, 224, 224, "grey88"),
            new DRGBName(224, 238, 224, "honeydew2"),
            new DRGBName(224, 238, 238, "azure2"),
            new DRGBName(224, 255, 255, "light cyan"),
            new DRGBName(227, 227, 227, "gray89"),
            new DRGBName(227, 227, 227, "grey89"),
            new DRGBName(229, 229, 229, "gray90"),
            new DRGBName(229, 229, 229, "grey90"),
            new DRGBName(230, 230, 250, "lavender"),
            new DRGBName(232, 232, 232, "gray91"),
            new DRGBName(232, 232, 232, "grey91"),
            new DRGBName(233, 150, 122, "dark salmon"),
            new DRGBName(235, 235, 235, "gray92"),
            new DRGBName(235, 235, 235, "grey92"),
            new DRGBName(237, 237, 237, "gray93"),
            new DRGBName(237, 237, 237, "grey93"),
            new DRGBName(238, 0, 0, "red2"),
            new DRGBName(238, 0, 238, "magenta2"),
            new DRGBName(238, 106, 167, "HotPink2"),
            new DRGBName(238, 106, 80, "coral2"),
            new DRGBName(238, 118, 0, "DarkOrange2"),
            new DRGBName(238, 118, 33, "chocolate2"),
            new DRGBName(238, 121, 159, "PaleVioletRed2"),
            new DRGBName(238, 121, 66, "sienna2"),
            new DRGBName(238, 122, 233, "orchid2"),
            new DRGBName(238, 130, 238, "violet"),
            new DRGBName(238, 130, 98, "salmon2"),
            new DRGBName(238, 149, 114, "LightSalmon2"),
            new DRGBName(238, 154, 0, "orange2"),
            new DRGBName(238, 154, 73, "tan2"),
            new DRGBName(238, 162, 173, "LightPink2"),
            new DRGBName(238, 169, 184, "pink2"),
            new DRGBName(238, 173, 14, "DarkGoldenrod2"),
            new DRGBName(238, 174, 238, "plum2"),
            new DRGBName(238, 180, 180, "RosyBrown2"),
            new DRGBName(238, 180, 34, "goldenrod2"),
            new DRGBName(238, 18, 137, "DeepPink2"),
            new DRGBName(238, 197, 145, "burlywood2"),
            new DRGBName(238, 201, 0, "gold2"),
            new DRGBName(238, 203, 173, "PeachPuff2"),
            new DRGBName(238, 207, 161, "NavajoWhite2"),
            new DRGBName(238, 210, 238, "thistle2"),
            new DRGBName(238, 213, 183, "bisque2"),
            new DRGBName(238, 213, 210, "MistyRose2"),
            new DRGBName(238, 216, 174, "wheat2"),
            new DRGBName(238, 221, 130, "light goldenrod"),
            new DRGBName(238, 223, 204, "AntiqueWhite2"),
            new DRGBName(238, 224, 229, "LavenderBlush2"),
            new DRGBName(238, 229, 222, "seashell2"),
            new DRGBName(238, 230, 133, "khaki2"),
            new DRGBName(238, 232, 170, "pale goldenrod"),
            new DRGBName(238, 232, 205, "cornsilk2"),
            new DRGBName(238, 233, 191, "LemonChiffon2"),
            new DRGBName(238, 233, 233, "snow2"),
            new DRGBName(238, 238, 0, "yellow2"),
            new DRGBName(238, 238, 209, "LightYellow2"),
            new DRGBName(238, 238, 224, "ivory2"),
            new DRGBName(238, 44, 44, "firebrick2"),
            new DRGBName(238, 48, 167, "maroon2"),
            new DRGBName(238, 58, 140, "VioletRed2"),
            new DRGBName(238, 59, 59, "brown2"),
            new DRGBName(238, 64, 0, "OrangeRed2"),
            new DRGBName(238, 92, 66, "tomato2"),
            new DRGBName(238, 99, 99, "IndianRed2"),
            new DRGBName(240, 128, 128, "light coral"),
            new DRGBName(240, 230, 140, "khaki"),
            new DRGBName(240, 240, 240, "gray94"),
            new DRGBName(240, 240, 240, "grey94"),
            new DRGBName(240, 248, 255, "alice blue"),
            new DRGBName(240, 255, 240, "honeydew"),
            new DRGBName(240, 255, 255, "azure"),
            new DRGBName(242, 242, 242, "gray95"),
            new DRGBName(242, 242, 242, "grey95"),
            new DRGBName(244, 164, 96, "sandy brown"),
            new DRGBName(245, 222, 179, "wheat"),
            new DRGBName(245, 245, 220, "beige"),
            new DRGBName(245, 245, 245, "gray96"),
            new DRGBName(245, 245, 245, "grey96"),
            new DRGBName(245, 245, 245, "white smoke"),
            new DRGBName(245, 255, 250, "mint cream"),
            new DRGBName(247, 247, 247, "gray97"),
            new DRGBName(247, 247, 247, "grey97"),
            new DRGBName(248, 248, 255, "ghost white"),
            new DRGBName(250, 128, 114, "salmon"),
            new DRGBName(250, 235, 215, "antique white"),
            new DRGBName(250, 240, 230, "linen"),
            new DRGBName(250, 250, 210, "light goldenrod yellow"),
            new DRGBName(250, 250, 250, "gray98"),
            new DRGBName(250, 250, 250, "grey98"),
            new DRGBName(252, 252, 252, "gray99"),
            new DRGBName(252, 252, 252, "grey99"),
            new DRGBName(253, 245, 230, "old lace"),
            new DRGBName(255, 0, 0, "red"),
            new DRGBName(255, 0, 255, "magenta"),
            new DRGBName(255, 105, 180, "hot pink"),
            new DRGBName(255, 106, 106, "IndianRed1"),
            new DRGBName(255, 110, 180, "HotPink1"),
            new DRGBName(255, 114, 86, "coral1"),
            new DRGBName(255, 127, 0, "DarkOrange1"),
            new DRGBName(255, 127, 36, "chocolate1"),
            new DRGBName(255, 127, 80, "coral"),
            new DRGBName(255, 130, 171, "PaleVioletRed1"),
            new DRGBName(255, 130, 71, "sienna1"),
            new DRGBName(255, 131, 250, "orchid1"),
            new DRGBName(255, 140, 0, "dark orange"),
            new DRGBName(255, 140, 105, "salmon1"),
            new DRGBName(255, 160, 122, "light salmon"),
            new DRGBName(255, 165, 0, "orange"),
            new DRGBName(255, 165, 79, "tan1"),
            new DRGBName(255, 174, 185, "LightPink1"),
            new DRGBName(255, 181, 197, "pink1"),
            new DRGBName(255, 182, 193, "light pink"),
            new DRGBName(255, 185, 15, "DarkGoldenrod1"),
            new DRGBName(255, 187, 255, "plum1"),
            new DRGBName(255, 192, 203, "pink"),
            new DRGBName(255, 193, 193, "RosyBrown1"),
            new DRGBName(255, 193, 37, "goldenrod1"),
            new DRGBName(255, 20, 147, "deep pink"),
            new DRGBName(255, 211, 155, "burlywood1"),
            new DRGBName(255, 215, 0, "gold"),
            new DRGBName(255, 218, 185, "peach puff"),
            new DRGBName(255, 222, 173, "navajo white"),
            new DRGBName(255, 225, 255, "thistle1"),
            new DRGBName(255, 228, 181, "moccasin"),
            new DRGBName(255, 228, 196, "bisque"),
            new DRGBName(255, 228, 225, "misty rose"),
            new DRGBName(255, 231, 186, "wheat1"),
            new DRGBName(255, 235, 205, "blanched almond"),
            new DRGBName(255, 236, 139, "LightGoldenrod1"),
            new DRGBName(255, 239, 213, "papaya whip"),
            new DRGBName(255, 239, 219, "AntiqueWhite1"),
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
            new DRGBName(255, 48, 48, "firebrick1"),
            new DRGBName(255, 52, 179, "maroon1"),
            new DRGBName(255, 62, 150, "VioletRed1"),
            new DRGBName(255, 64, 64, "brown1"),
            new DRGBName(255, 69, 0, "orange red"),
            new DRGBName(255, 99, 71, "tomato")
        };

        public void findColor(int R, int G, int B, int formX, int formY)
        {
            string region;
            string colorName;

            // Determine the color region among ROYGBIV + WB
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

            // Calculate the distance from two points. 
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

            cDistance = Math.Sqrt(Math.Pow((0), 2) + Math.Pow((0), 2)
                    + Math.Pow((0), 2));

            if (0.0 == cDistance) { MessageBox.Show("here!"); }

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
