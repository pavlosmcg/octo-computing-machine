using System;
using System.Drawing;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BitmapToJack
{
    class Program
    {
        const int WidthInPixels = 512;
        const int HeightInPixels = 256;
        const int WordLength = 16;
        const int ScreenMemoryMap = 16384;

        static void Main(string[] args)
        {
            // check for correct command line args
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please specifiy a file path");
                return;
            }

            // do the conversion
            var bmp = new Bitmap(args[0], true);

            // create a dictionary of 16 bit numbers that representing pixels,
            // keyed by the memory map location that we 
            IEnumerable<KeyValuePair<int, int>> data = BmpToData(bmp);

            foreach (KeyValuePair<int, int> keyValuePair in data)
            {
                Console.WriteLine("do Memory.poke({0},{1});", keyValuePair.Key, keyValuePair.Value);
            }
        }

        private static IEnumerable<KeyValuePair<int, int>> BmpToData(Bitmap img)
        {
            var results = new Dictionary<int, int>();
            int[][] pixels = GetPixelArray(img);
            
            for (var y = 0; y < HeightInPixels; y++)
            {
                int[] lineOfPixels = pixels[y];
                for (var x = 0; x < WidthInPixels; x += WordLength)
                {
                    var builder = new StringBuilder(16, 16);
                    for (var i = 0; i < WordLength; i++)
                    {
                        builder.Append(lineOfPixels[x + i].ToString(CultureInfo.InvariantCulture));
                    }
                    char[] bits = builder.ToString().ToCharArray().Reverse().ToArray();

                    var word = Convert.ToInt16(new string(bits), 2);
                    // supplied hack compiler doesn't seem to allow the value -32768 (1000 0000 0000 0000)
                    if (word == -32768)
                    {
                        word = 0; // so lose one black pixel and set it to zero
                    }
                    // Cut down program size
                    // 1. only add results that are actually going to color some pixels
                    // 2. cut out half the rows
                    if ((word != 0) && (y % 2 == 0))
                    {
                        results.Add(ScreenMemoryMap + (((WidthInPixels * y) + x) / WordLength), word);
                    }
                }
            }

            return results;
        }

        private static int[][] GetPixelArray(Bitmap img)
        {
            var pixels = new int[HeightInPixels][];

            for (var y = 0; y < HeightInPixels; y++)
            {
                pixels[y] = new int[WidthInPixels];
                for (var x = 0; x < WidthInPixels; x++)
                {
                    if (x >= img.Width || y >= img.Height)
                    {
                        pixels[y][x] = 0;
                    }
                    else
                    {
                        Color pixelColor = img.GetPixel(x, y);
                        pixels[y][x] = pixelColor.ToArgb() == Color.Black.ToArgb() ? 1 : 0;    
                    }
                }
            }

            return pixels;
        }
    }
}
