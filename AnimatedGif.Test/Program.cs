using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace AnimatedGif.Test
{
    class Program
    {
        readonly static string gifName = "gif.gif";

        static void Main(string[] args)
        {
            for (int i = 0; i < 110; i += 2)
            {
                WriteGif(i);
                int t = TestTimings();
                Console.WriteLine($"{i}: {t}");
            }
            Console.ReadLine();
        }

        public static void WriteGif(int delay)
        {
            using var gif = AnimatedGif.Create("gif.gif", delay);

            var img1 = Image.FromFile("001.jpg");
            gif.AddFrame(img1, delay: -1, quality: GifQuality.Bit8);
            var img2 = Image.FromFile("002.jpg");
            gif.AddFrame(img2, delay: -1, quality: GifQuality.Bit8);
            var img3 = Image.FromFile("003.jpg");
            gif.AddFrame(img3, delay: -1, quality: GifQuality.Bit8);
        }

        public static int TestTimings()
        {
            using Image i = Image.FromFile(gifName);

            FrameDimension dimension = new FrameDimension(i.FrameDimensionsList[0]);
            int n = i.GetFrameCount(dimension);
            int[] timings = new int[n];
            for (int j = 0; j < n; j++)
            {
                var prop = i.GetPropertyItem(20736);
                timings[j] = (prop.Value[0] + prop.Value[1] * 256) * 10;
            }
            return (int)timings.Average();
        }
    }
}
